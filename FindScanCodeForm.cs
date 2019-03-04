using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FindScanCode {
    public partial class FindScanCodeForm : Form {
        public FindScanCodeForm() {
            InitializeComponent();
            if (!RegisterRawInput())
                throw new ApplicationException("Raw input 등록 실패");
        }

        protected override void WndProc(ref Message message) {
            ProcRawInput(ref message);
            base.WndProc(ref message);
        }

        // Raw Input 등록
        private bool RegisterRawInput() {
            RAWINPUTDEVICE[] rid = new RAWINPUTDEVICE[1];

            // 일반 키보드
            rid[0].usUsagePage = HIDUsagePage.Generic;
            rid[0].usUsage = HIDUsage.Keyboard;

            // 창이 백그라운드에 있어도 입력을 받으려면 아래 dwFlags 수정하기
            // rid[0].dwFlags = RawInputDeviceFlags.InputSink;
            rid[0].dwFlags = RawInputDeviceFlags.None;

            rid[0].hwndTarget = Handle;

            return RegisterRawInputDevices(rid, 1, Marshal.SizeOf(rid[0]));
        }

        // 메시지 처리
        public void ProcRawInput(ref Message message) {

            // 입력 메시지 일 때에만
            if (message.Msg != WM_INPUT)
                return;

            RAWINPUT input = new RAWINPUT();
            int size = Marshal.SizeOf(typeof(RAWINPUT));
            int outSize = size;
            if (GetRawInputData(message.LParam, RawInputCommand.Input, out input, ref outSize, Marshal.SizeOf(typeof(RAWINPUTHEADER))) != size)
                return;

            // 키보드 다운만 처리
            if (input.header.dwType != RawInputType.Keyboard)
                return;
            if (input.keyboard.Message != WM_KEYDOWN && input.keyboard.Message != WM_SYSKEYDOWN)
                return;

            // Keys.OemClear == 254 까지만 유효한 키입력으로 간주
            if (input.keyboard.VKey > (ushort)Keys.OemClear)
                return;

            lbVKey.Text = Enum.GetName(typeof(Keys), input.keyboard.VKey);

            if (input.keyboard.Flags == 2)
                lbScanCode.Text = string.Format("E0_{0:X2}", input.keyboard.MakeCode);
            else if (input.keyboard.Flags == 4)
                lbScanCode.Text = string.Format("E1_{0:X2}", input.keyboard.MakeCode);
            else
                lbScanCode.Text = string.Format("00_{0:X2}", input.keyboard.MakeCode);
        }

        // 아래는 Win32 API 호출을 위한 상수, 구조체, API 들

        private const uint WM_INPUT = 0x00FF;
        private const uint WM_KEYDOWN = 0x0100;
        private const uint WM_SYSKEYDOWN = 0x0104;

        public enum HIDUsagePage : ushort { Generic = 0x01 }
        public enum HIDUsage : ushort { Keyboard = 0x06 }
        [Flags()]
        public enum RawInputDeviceFlags {
            None = 0,
            InputSink = 0x00000100,
            NoHotKeys = 0x00000200,
            AppKeys = 0x00000400
        }
        public enum RawInputType {
            Mouse = 0,
            Keyboard = 1,
            HID = 2,
            Other = 3
        }
        public enum RawInputCommand {
            Input = 0x10000003,
            Header = 0x10000005
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RAWINPUTDEVICE {
            public HIDUsagePage usUsagePage;
            public HIDUsage usUsage;
            public RawInputDeviceFlags dwFlags;
            public IntPtr hwndTarget;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RAWINPUTHEADER {
            public RawInputType dwType;
            public int dwSize;
            public IntPtr hDevice;
            public IntPtr wParam;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RAWKEYBOARD {
            public ushort MakeCode;
            public ushort Flags;
            public ushort Reserved;
            public ushort VKey;
            public uint Message;
            public uint ExtraInformation;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RAWINPUT {
            public RAWINPUTHEADER header;
            public RAWKEYBOARD keyboard;
        }

        [DllImport("user32.dll")]
        public static extern bool RegisterRawInputDevices([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RAWINPUTDEVICE[] pRawInputDevices, int uiNumDevices, int cbSize);

        [DllImport("user32.dll")]
        public static extern int GetRawInputData(IntPtr hRawInput, RawInputCommand uiCommand, out RAWINPUT pData, ref int pcbSize, int cbSizeHeader);
    }
}

namespace FindScanCode
{
    partial class FindScanCodeForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            this.lbScanCode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbVKey = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(125, 24);
            label1.TabIndex = 0;
            label1.Text = "ScanCode:";
            // 
            // lbScanCode
            // 
            this.lbScanCode.AutoSize = true;
            this.lbScanCode.Location = new System.Drawing.Point(145, 13);
            this.lbScanCode.Name = "lbScanCode";
            this.lbScanCode.Size = new System.Drawing.Size(114, 24);
            this.lbScanCode.TabIndex = 1;
            this.lbScanCode.Text = "00000000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "VKey:";
            // 
            // lbVKey
            // 
            this.lbVKey.AutoSize = true;
            this.lbVKey.Location = new System.Drawing.Point(344, 13);
            this.lbVKey.Name = "lbVKey";
            this.lbVKey.Size = new System.Drawing.Size(270, 24);
            this.lbVKey.TabIndex = 3;
            this.lbVKey.Text = "00000000000000000000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 53);
            this.Controls.Add(this.lbVKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbScanCode);
            this.Controls.Add(label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FindScanCode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbScanCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbVKey;
    }
}



namespace OmokProgram
{
    partial class pnInRight
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbProgramTitle = new System.Windows.Forms.Label();
            this.lbCopyright = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.panel1.Controls.Add(this.lbProgramTitle);
            this.panel1.Controls.Add(this.lbCopyright);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 519);
            this.panel1.TabIndex = 2;
            // 
            // lbProgramTitle
            // 
            this.lbProgramTitle.AutoSize = true;
            this.lbProgramTitle.Font = new System.Drawing.Font("배달의민족 한나체 Pro", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbProgramTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbProgramTitle.Location = new System.Drawing.Point(16, 50);
            this.lbProgramTitle.Name = "lbProgramTitle";
            this.lbProgramTitle.Size = new System.Drawing.Size(192, 51);
            this.lbProgramTitle.TabIndex = 2;
            this.lbProgramTitle.Text = "오목대전";
            // 
            // lbCopyright
            // 
            this.lbCopyright.AutoSize = true;
            this.lbCopyright.Font = new System.Drawing.Font("맑은 고딕 Semilight", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbCopyright.Location = new System.Drawing.Point(16, 500);
            this.lbCopyright.Name = "lbCopyright";
            this.lbCopyright.Size = new System.Drawing.Size(203, 12);
            this.lbCopyright.TabIndex = 1;
            this.lbCopyright.Text = "ⓒ Best of the Best 10th 보안제품개발 이창모";
            // 
            // pnInRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "pnInRight";
            this.Size = new System.Drawing.Size(196, 519);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbProgramTitle;
        private System.Windows.Forms.Label lbCopyright;
    }
}

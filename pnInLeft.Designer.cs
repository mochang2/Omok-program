
namespace OmokProgram
{
    partial class pnInLeft
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
            this.pnOmokPicture = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(193)))), ((int)(((byte)(113)))));
            this.panel1.Controls.Add(this.pnOmokPicture);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 519);
            this.panel1.TabIndex = 1;
            // 
            // pnOmokPicture
            // 
            this.pnOmokPicture.BackgroundImage = global::OmokProgram.Properties.Resources.오목판ex;
            this.pnOmokPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnOmokPicture.Location = new System.Drawing.Point(41, 50);
            this.pnOmokPicture.Name = "pnOmokPicture";
            this.pnOmokPicture.Size = new System.Drawing.Size(398, 436);
            this.pnOmokPicture.TabIndex = 0;
            // 
            // pnInLeft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "pnInLeft";
            this.Size = new System.Drawing.Size(478, 519);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnOmokPicture;
    }
}

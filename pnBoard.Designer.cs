﻿
namespace OmokProgram
{
    partial class pnBoard
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
            this.pnSelectedSign = new System.Windows.Forms.Panel();
            this.pnGameBoard = new System.Windows.Forms.Panel();
            this.pnGameBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnSelectedSign
            // 
            this.pnSelectedSign.BackgroundImage = global::OmokProgram.Properties.Resources.selectedSign;
            this.pnSelectedSign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnSelectedSign.Location = new System.Drawing.Point(414, 6);
            this.pnSelectedSign.Margin = new System.Windows.Forms.Padding(6);
            this.pnSelectedSign.Name = "pnSelectedSign";
            this.pnSelectedSign.Size = new System.Drawing.Size(16, 16);
            this.pnSelectedSign.TabIndex = 1;
            this.pnSelectedSign.Visible = false;
            // 
            // pnGameBoard
            // 
            this.pnGameBoard.Controls.Add(this.pnSelectedSign);
            this.pnGameBoard.Location = new System.Drawing.Point(16, 40);
            this.pnGameBoard.Name = "pnGameBoard";
            this.pnGameBoard.Size = new System.Drawing.Size(470, 470);
            this.pnGameBoard.TabIndex = 2;
            this.pnGameBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnGameBoard_Paint);
            this.pnGameBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnGameBoard_MouseDown);
            // 
            // pnBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(188)))), ((int)(((byte)(107)))));
            this.Controls.Add(this.pnGameBoard);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "pnBoard";
            this.Size = new System.Drawing.Size(478, 519);
            this.pnGameBoard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnSelectedSign;
        private System.Windows.Forms.Panel pnGameBoard;
    }
}

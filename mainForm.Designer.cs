
namespace OmokProgram
{
    partial class mainForm
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnBg = new System.Windows.Forms.Panel();
            this.pnInLeft1 = new OmokProgram.pnInLeft();
            this.pnInRight = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMultiPlay = new System.Windows.Forms.Button();
            this.btnSinglePlay = new System.Windows.Forms.Button();
            this.lbProgramTitle = new System.Windows.Forms.Label();
            this.lbCopyright = new System.Windows.Forms.Label();
            this.pnBg.SuspendLayout();
            this.pnInRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBg
            // 
            this.pnBg.BackColor = System.Drawing.Color.Transparent;
            this.pnBg.BackgroundImage = global::OmokProgram.Properties.Resources.오목판bg;
            this.pnBg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnBg.Controls.Add(this.pnInLeft1);
            this.pnBg.Controls.Add(this.pnInRight);
            this.pnBg.Location = new System.Drawing.Point(0, 0);
            this.pnBg.Name = "pnBg";
            this.pnBg.Size = new System.Drawing.Size(724, 560);
            this.pnBg.TabIndex = 0;
            // 
            // pnInLeft1
            // 
            this.pnInLeft1.Location = new System.Drawing.Point(24, 20);
            this.pnInLeft1.Margin = new System.Windows.Forms.Padding(0);
            this.pnInLeft1.Name = "pnInLeft1";
            this.pnInLeft1.Size = new System.Drawing.Size(478, 519);
            this.pnInLeft1.TabIndex = 1;
            // 
            // pnInRight
            // 
            this.pnInRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.pnInRight.Controls.Add(this.btnExit);
            this.pnInRight.Controls.Add(this.btnMultiPlay);
            this.pnInRight.Controls.Add(this.btnSinglePlay);
            this.pnInRight.Controls.Add(this.lbProgramTitle);
            this.pnInRight.Controls.Add(this.lbCopyright);
            this.pnInRight.Location = new System.Drawing.Point(502, 20);
            this.pnInRight.Name = "pnInRight";
            this.pnInRight.Size = new System.Drawing.Size(196, 519);
            this.pnInRight.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("휴먼둥근헤드라인", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.Location = new System.Drawing.Point(32, 323);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 52);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "끝내기";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMultiPlay
            // 
            this.btnMultiPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMultiPlay.Font = new System.Drawing.Font("휴먼둥근헤드라인", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMultiPlay.Location = new System.Drawing.Point(32, 245);
            this.btnMultiPlay.Name = "btnMultiPlay";
            this.btnMultiPlay.Size = new System.Drawing.Size(140, 52);
            this.btnMultiPlay.TabIndex = 4;
            this.btnMultiPlay.Text = "멀티플레이";
            this.btnMultiPlay.UseVisualStyleBackColor = true;
            this.btnMultiPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnSinglePlay
            // 
            this.btnSinglePlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSinglePlay.Font = new System.Drawing.Font("휴먼둥근헤드라인", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSinglePlay.Location = new System.Drawing.Point(32, 167);
            this.btnSinglePlay.Name = "btnSinglePlay";
            this.btnSinglePlay.Size = new System.Drawing.Size(140, 52);
            this.btnSinglePlay.TabIndex = 3;
            this.btnSinglePlay.Text = "싱글플레이";
            this.btnSinglePlay.UseVisualStyleBackColor = true;
            this.btnSinglePlay.Click += new System.EventHandler(this.btnPlay_Click);
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
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 560);
            this.Controls.Add(this.pnBg);
            this.Name = "mainForm";
            this.Text = "오목대전";
            this.pnBg.ResumeLayout(false);
            this.pnInRight.ResumeLayout(false);
            this.pnInRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnInRight;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMultiPlay;
        private System.Windows.Forms.Button btnSinglePlay;
        private System.Windows.Forms.Label lbProgramTitle;
        private System.Windows.Forms.Label lbCopyright;
        private System.Windows.Forms.Panel pnBg;
        private pnInLeft pnInLeft1;
    }
}



namespace OmokProgram
{
    partial class MultiPlayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiPlayForm));
            this.lbTurn = new System.Windows.Forms.Label();
            this.btnReplay = new System.Windows.Forms.Button();
            this.lbResult = new System.Windows.Forms.Label();
            this.tbSeq = new System.Windows.Forms.TextBox();
            this.pnInRight1 = new OmokProgram.pnInRight();
            this.pnBackToHome = new OmokProgram.pnBackToHome();
            this.pnBoard = new OmokProgram.pnBoard();
            this.pnBg1 = new OmokProgram.pnBg();
            this.SuspendLayout();
            // 
            // lbTurn
            // 
            this.lbTurn.BackColor = System.Drawing.Color.Black;
            this.lbTurn.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbTurn.Font = new System.Drawing.Font("나눔고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTurn.Location = new System.Drawing.Point(532, 392);
            this.lbTurn.Name = "lbTurn";
            this.lbTurn.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.lbTurn.Size = new System.Drawing.Size(140, 40);
            this.lbTurn.TabIndex = 7;
            this.lbTurn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReplay
            // 
            this.btnReplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(234)))), ((int)(((byte)(206)))));
            this.btnReplay.CausesValidation = false;
            this.btnReplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReplay.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReplay.Font = new System.Drawing.Font("휴먼둥근헤드라인", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReplay.Location = new System.Drawing.Point(532, 392);
            this.btnReplay.Margin = new System.Windows.Forms.Padding(0);
            this.btnReplay.Name = "btnReplay";
            this.btnReplay.Size = new System.Drawing.Size(140, 52);
            this.btnReplay.TabIndex = 12;
            this.btnReplay.Text = "다시하기";
            this.btnReplay.UseVisualStyleBackColor = false;
            this.btnReplay.Visible = false;
            this.btnReplay.Click += new System.EventHandler(this.btnReplay_Click);
            // 
            // lbResult
            // 
            this.lbResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.lbResult.Font = new System.Drawing.Font("배달의민족 한나는 열한살", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbResult.Location = new System.Drawing.Point(510, 450);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(180, 50);
            this.lbResult.TabIndex = 13;
            this.lbResult.Text = "YOU DRAW";
            this.lbResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbResult.Visible = false;
            // 
            // tbSeq
            // 
            this.tbSeq.Location = new System.Drawing.Point(515, 130);
            this.tbSeq.Multiline = true;
            this.tbSeq.Name = "tbSeq";
            this.tbSeq.ReadOnly = true;
            this.tbSeq.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSeq.Size = new System.Drawing.Size(171, 245);
            this.tbSeq.TabIndex = 14;
            // 
            // pnInRight1
            // 
            this.pnInRight1.Location = new System.Drawing.Point(502, 20);
            this.pnInRight1.Margin = new System.Windows.Forms.Padding(0);
            this.pnInRight1.Name = "pnInRight1";
            this.pnInRight1.Size = new System.Drawing.Size(196, 519);
            this.pnInRight1.TabIndex = 3;
            // 
            // pnBackToHome
            // 
            this.pnBackToHome.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnBackToHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(193)))), ((int)(((byte)(113)))));
            this.pnBackToHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnBackToHome.BackgroundImage")));
            this.pnBackToHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnBackToHome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnBackToHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnBackToHome.Location = new System.Drawing.Point(24, 20);
            this.pnBackToHome.Margin = new System.Windows.Forms.Padding(0);
            this.pnBackToHome.Name = "pnBackToHome";
            this.pnBackToHome.Size = new System.Drawing.Size(45, 44);
            this.pnBackToHome.TabIndex = 0;
            this.pnBackToHome.Click += new System.EventHandler(this.pnBackToHome_Click);
            // 
            // pnBoard
            // 
            this.pnBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(188)))), ((int)(((byte)(107)))));
            this.pnBoard.Location = new System.Drawing.Point(24, 20);
            this.pnBoard.Margin = new System.Windows.Forms.Padding(0);
            this.pnBoard.Name = "pnBoard";
            this.pnBoard.Size = new System.Drawing.Size(478, 519);
            this.pnBoard.TabIndex = 2;
            // 
            // pnBg1
            // 
            this.pnBg1.Location = new System.Drawing.Point(0, 0);
            this.pnBg1.Margin = new System.Windows.Forms.Padding(0);
            this.pnBg1.Name = "pnBg1";
            this.pnBg1.Size = new System.Drawing.Size(724, 560);
            this.pnBg1.TabIndex = 1;
            // 
            // MultiPlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 560);
            this.Controls.Add(this.tbSeq);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.btnReplay);
            this.Controls.Add(this.lbTurn);
            this.Controls.Add(this.pnInRight1);
            this.Controls.Add(this.pnBackToHome);
            this.Controls.Add(this.pnBoard);
            this.Controls.Add(this.pnBg1);
            this.Name = "MultiPlayForm";
            this.Text = "MultiPlayForm";
            this.Load += new System.EventHandler(this.MultiPlayForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private pnBackToHome pnBackToHome;
        private pnBg pnBg1;
        private pnBoard pnBoard;
        private pnInRight pnInRight1;
        private System.Windows.Forms.Label lbTurn;
        private System.Windows.Forms.Button btnReplay;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.TextBox tbSeq;
    }
}
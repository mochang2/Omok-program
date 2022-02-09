
namespace OmokProgram
{
    partial class SinglePlayForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SinglePlayForm));
            this.pnShowColor = new System.Windows.Forms.Panel();
            this.lbTurn = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.hourGlassWrapper = new System.Windows.Forms.Button();
            this.btnPut = new System.Windows.Forms.Button();
            this.btnSurrender = new System.Windows.Forms.Button();
            this.btnReplay = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lbResult = new System.Windows.Forms.Label();
            this.pnBackToHome = new OmokProgram.pnBackToHome();
            this.pnBoard = new OmokProgram.pnBoard();
            this.pnInRight = new OmokProgram.pnInRight();
            this.pnBg = new OmokProgram.pnBg();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnShowColor
            // 
            this.pnShowColor.BackColor = System.Drawing.Color.White;
            this.pnShowColor.Location = new System.Drawing.Point(504, 124);
            this.pnShowColor.Name = "pnShowColor";
            this.pnShowColor.Size = new System.Drawing.Size(190, 52);
            this.pnShowColor.TabIndex = 5;
            this.pnShowColor.Paint += new System.Windows.Forms.PaintEventHandler(this.pnShowColor_Paint);
            // 
            // lbTurn
            // 
            this.lbTurn.BackColor = System.Drawing.Color.White;
            this.lbTurn.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbTurn.Font = new System.Drawing.Font("나눔고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTurn.Location = new System.Drawing.Point(532, 216);
            this.lbTurn.Name = "lbTurn";
            this.lbTurn.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.lbTurn.Size = new System.Drawing.Size(140, 40);
            this.lbTurn.TabIndex = 6;
            this.lbTurn.Text = "Your Turn";
            this.lbTurn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTime
            // 
            this.lbTime.BackColor = System.Drawing.Color.White;
            this.lbTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbTime.Font = new System.Drawing.Font("나눔고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTime.Location = new System.Drawing.Point(543, 296);
            this.lbTime.Name = "lbTime";
            this.lbTime.Padding = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.lbTime.Size = new System.Drawing.Size(105, 40);
            this.lbTime.TabIndex = 7;
            this.lbTime.Text = "16초";
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hourGlassWrapper
            // 
            this.hourGlassWrapper.BackgroundImage = global::OmokProgram.Properties.Resources.hourGlass;
            this.hourGlassWrapper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hourGlassWrapper.Enabled = false;
            this.hourGlassWrapper.Location = new System.Drawing.Point(543, 300);
            this.hourGlassWrapper.Name = "hourGlassWrapper";
            this.hourGlassWrapper.Size = new System.Drawing.Size(24, 33);
            this.hourGlassWrapper.TabIndex = 8;
            this.hourGlassWrapper.UseVisualStyleBackColor = true;
            // 
            // btnPut
            // 
            this.btnPut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(234)))), ((int)(((byte)(206)))));
            this.btnPut.CausesValidation = false;
            this.btnPut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPut.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPut.Font = new System.Drawing.Font("휴먼둥근헤드라인", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPut.Location = new System.Drawing.Point(510, 376);
            this.btnPut.Margin = new System.Windows.Forms.Padding(0);
            this.btnPut.Name = "btnPut";
            this.btnPut.Size = new System.Drawing.Size(80, 52);
            this.btnPut.TabIndex = 9;
            this.btnPut.Text = "착수";
            this.btnPut.UseVisualStyleBackColor = false;
            this.btnPut.Click += new System.EventHandler(this.btnPut_Click);
            // 
            // btnSurrender
            // 
            this.btnSurrender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(234)))), ((int)(((byte)(206)))));
            this.btnSurrender.CausesValidation = false;
            this.btnSurrender.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSurrender.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSurrender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSurrender.Font = new System.Drawing.Font("휴먼둥근헤드라인", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSurrender.Location = new System.Drawing.Point(608, 376);
            this.btnSurrender.Margin = new System.Windows.Forms.Padding(0);
            this.btnSurrender.Name = "btnSurrender";
            this.btnSurrender.Size = new System.Drawing.Size(80, 52);
            this.btnSurrender.TabIndex = 10;
            this.btnSurrender.Text = "기권";
            this.btnSurrender.UseVisualStyleBackColor = false;
            this.btnSurrender.Click += new System.EventHandler(this.btnSurrender_Click);
            // 
            // btnReplay
            // 
            this.btnReplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(234)))), ((int)(((byte)(206)))));
            this.btnReplay.CausesValidation = false;
            this.btnReplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReplay.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReplay.Font = new System.Drawing.Font("휴먼둥근헤드라인", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReplay.Location = new System.Drawing.Point(532, 210);
            this.btnReplay.Margin = new System.Windows.Forms.Padding(0);
            this.btnReplay.Name = "btnReplay";
            this.btnReplay.Size = new System.Drawing.Size(140, 52);
            this.btnReplay.TabIndex = 11;
            this.btnReplay.Text = "다시하기";
            this.btnReplay.UseVisualStyleBackColor = false;
            this.btnReplay.Visible = false;
            this.btnReplay.Click += new System.EventHandler(this.btnReplay_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lbResult
            // 
            this.lbResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.lbResult.Font = new System.Drawing.Font("배달의민족 한나는 열한살", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbResult.Location = new System.Drawing.Point(510, 380);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(180, 50);
            this.lbResult.TabIndex = 12;
            this.lbResult.Text = "YOU DRAW";
            this.lbResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbResult.Visible = false;
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
            this.pnBackToHome.TabIndex = 2;
            this.pnBackToHome.Click += new System.EventHandler(this.pnBackToHome_Click);
            // 
            // pnBoard
            // 
            this.pnBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(188)))), ((int)(((byte)(107)))));
            this.pnBoard.Location = new System.Drawing.Point(24, 20);
            this.pnBoard.Margin = new System.Windows.Forms.Padding(0);
            this.pnBoard.Name = "pnBoard";
            this.pnBoard.Size = new System.Drawing.Size(478, 519);
            this.pnBoard.TabIndex = 4;
            // 
            // pnInRight
            // 
            this.pnInRight.Location = new System.Drawing.Point(502, 20);
            this.pnInRight.Margin = new System.Windows.Forms.Padding(0);
            this.pnInRight.Name = "pnInRight";
            this.pnInRight.Size = new System.Drawing.Size(196, 519);
            this.pnInRight.TabIndex = 3;
            // 
            // pnBg
            // 
            this.pnBg.Location = new System.Drawing.Point(0, 0);
            this.pnBg.Margin = new System.Windows.Forms.Padding(0);
            this.pnBg.Name = "pnBg";
            this.pnBg.Size = new System.Drawing.Size(724, 560);
            this.pnBg.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(234)))), ((int)(((byte)(206)))));
            this.btnClose.CausesValidation = false;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("휴먼둥근헤드라인", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(532, 290);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 52);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "종료하기";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // SinglePlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 560);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.btnReplay);
            this.Controls.Add(this.btnSurrender);
            this.Controls.Add(this.btnPut);
            this.Controls.Add(this.hourGlassWrapper);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbTurn);
            this.Controls.Add(this.pnShowColor);
            this.Controls.Add(this.pnBackToHome);
            this.Controls.Add(this.pnBoard);
            this.Controls.Add(this.pnInRight);
            this.Controls.Add(this.pnBg);
            this.Name = "SinglePlayForm";
            this.Text = "SinglePlayForm";
            this.Load += new System.EventHandler(this.SinglePlayForm_Load);
            this.Resize += new System.EventHandler(this.SinglePlayForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private pnBackToHome pnBackToHome;
        private pnBg pnBg;
        private pnInRight pnInRight;
        private System.Windows.Forms.Panel pnShowColor;
        private System.Windows.Forms.Label lbTurn;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Button hourGlassWrapper;
        private System.Windows.Forms.Button btnPut;
        private System.Windows.Forms.Button btnSurrender;
        private System.Windows.Forms.Button btnReplay;
        private System.Windows.Forms.Timer timer;
        private pnBoard pnBoard;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Button btnClose;
    }
}
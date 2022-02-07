
namespace OmokProgram
{
    partial class SinglePlayOptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SinglePlayOptionForm));
            this.cbAILevel = new System.Windows.Forms.ComboBox();
            this.rbRenjuRule = new System.Windows.Forms.RadioButton();
            this.rbOpeningRule = new System.Windows.Forms.RadioButton();
            this.btnGameStart = new System.Windows.Forms.Button();
            this.pnBackToHome = new OmokProgram.pnBackToHome();
            this.pnInRight = new OmokProgram.pnInRight();
            this.pnInLeft = new OmokProgram.pnInLeft();
            this.pnBg = new OmokProgram.pnBg();
            this.rbBlack = new System.Windows.Forms.RadioButton();
            this.rbWhite = new System.Windows.Forms.RadioButton();
            this.pnRule = new System.Windows.Forms.Panel();
            this.pnColor = new System.Windows.Forms.Panel();
            this.pnRule.SuspendLayout();
            this.pnColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbAILevel
            // 
            this.cbAILevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAILevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAILevel.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbAILevel.FormattingEnabled = true;
            this.cbAILevel.Location = new System.Drawing.Point(532, 187);
            this.cbAILevel.MaxDropDownItems = 9;
            this.cbAILevel.Name = "cbAILevel";
            this.cbAILevel.Size = new System.Drawing.Size(140, 31);
            this.cbAILevel.TabIndex = 4;
            // 
            // rbRenjuRule
            // 
            this.rbRenjuRule.AutoSize = true;
            this.rbRenjuRule.Checked = true;
            this.rbRenjuRule.Font = new System.Drawing.Font("나눔고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbRenjuRule.Location = new System.Drawing.Point(104, 0);
            this.rbRenjuRule.Name = "rbRenjuRule";
            this.rbRenjuRule.Padding = new System.Windows.Forms.Padding(5);
            this.rbRenjuRule.Size = new System.Drawing.Size(88, 34);
            this.rbRenjuRule.TabIndex = 5;
            this.rbRenjuRule.TabStop = true;
            this.rbRenjuRule.Text = "렌주룰";
            this.rbRenjuRule.UseVisualStyleBackColor = true;
            // 
            // rbOpeningRule
            // 
            this.rbOpeningRule.AutoSize = true;
            this.rbOpeningRule.Enabled = false;
            this.rbOpeningRule.Font = new System.Drawing.Font("나눔고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbOpeningRule.Location = new System.Drawing.Point(0, 0);
            this.rbOpeningRule.Name = "rbOpeningRule";
            this.rbOpeningRule.Padding = new System.Windows.Forms.Padding(5);
            this.rbOpeningRule.Size = new System.Drawing.Size(104, 34);
            this.rbOpeningRule.TabIndex = 6;
            this.rbOpeningRule.TabStop = true;
            this.rbOpeningRule.Text = "오프닝룰";
            this.rbOpeningRule.UseVisualStyleBackColor = true;
            // 
            // btnGameStart
            // 
            this.btnGameStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(234)))), ((int)(((byte)(206)))));
            this.btnGameStart.CausesValidation = false;
            this.btnGameStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGameStart.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGameStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGameStart.Font = new System.Drawing.Font("휴먼둥근헤드라인", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGameStart.Location = new System.Drawing.Point(532, 398);
            this.btnGameStart.Margin = new System.Windows.Forms.Padding(0);
            this.btnGameStart.Name = "btnGameStart";
            this.btnGameStart.Size = new System.Drawing.Size(140, 52);
            this.btnGameStart.TabIndex = 7;
            this.btnGameStart.Text = "시작하기";
            this.btnGameStart.UseVisualStyleBackColor = false;
            this.btnGameStart.Click += new System.EventHandler(this.btnGameStart_Click);
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
            this.pnBackToHome.TabIndex = 3;
            this.pnBackToHome.Click += new System.EventHandler(this.pnBackToHome_Click);
            // 
            // pnInRight
            // 
            this.pnInRight.Location = new System.Drawing.Point(502, 20);
            this.pnInRight.Margin = new System.Windows.Forms.Padding(0);
            this.pnInRight.Name = "pnInRight";
            this.pnInRight.Size = new System.Drawing.Size(196, 519);
            this.pnInRight.TabIndex = 2;
            // 
            // pnInLeft
            // 
            this.pnInLeft.Location = new System.Drawing.Point(24, 20);
            this.pnInLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pnInLeft.Name = "pnInLeft";
            this.pnInLeft.Size = new System.Drawing.Size(478, 519);
            this.pnInLeft.TabIndex = 1;
            // 
            // pnBg
            // 
            this.pnBg.Location = new System.Drawing.Point(0, 0);
            this.pnBg.Margin = new System.Windows.Forms.Padding(0);
            this.pnBg.Name = "pnBg";
            this.pnBg.Size = new System.Drawing.Size(724, 560);
            this.pnBg.TabIndex = 0;
            this.pnBg.Load += new System.EventHandler(this.pnBg_Load);
            // 
            // rbBlack
            // 
            this.rbBlack.AutoSize = true;
            this.rbBlack.Checked = true;
            this.rbBlack.Font = new System.Drawing.Font("나눔고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbBlack.Location = new System.Drawing.Point(3, 0);
            this.rbBlack.Name = "rbBlack";
            this.rbBlack.Size = new System.Drawing.Size(46, 24);
            this.rbBlack.TabIndex = 8;
            this.rbBlack.TabStop = true;
            this.rbBlack.Text = "흑";
            this.rbBlack.UseVisualStyleBackColor = true;
            // 
            // rbWhite
            // 
            this.rbWhite.AutoSize = true;
            this.rbWhite.Font = new System.Drawing.Font("나눔고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbWhite.Location = new System.Drawing.Point(52, 0);
            this.rbWhite.Name = "rbWhite";
            this.rbWhite.Size = new System.Drawing.Size(46, 24);
            this.rbWhite.TabIndex = 9;
            this.rbWhite.TabStop = true;
            this.rbWhite.Text = "백";
            this.rbWhite.UseVisualStyleBackColor = true;
            // 
            // pnRule
            // 
            this.pnRule.Controls.Add(this.rbRenjuRule);
            this.pnRule.Controls.Add(this.rbOpeningRule);
            this.pnRule.Location = new System.Drawing.Point(502, 265);
            this.pnRule.Name = "pnRule";
            this.pnRule.Size = new System.Drawing.Size(190, 34);
            this.pnRule.TabIndex = 10;
            // 
            // pnColor
            // 
            this.pnColor.Controls.Add(this.rbBlack);
            this.pnColor.Controls.Add(this.rbWhite);
            this.pnColor.Location = new System.Drawing.Point(546, 328);
            this.pnColor.Name = "pnColor";
            this.pnColor.Size = new System.Drawing.Size(103, 24);
            this.pnColor.TabIndex = 11;
            // 
            // SinglePlayOptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 560);
            this.Controls.Add(this.pnColor);
            this.Controls.Add(this.pnRule);
            this.Controls.Add(this.btnGameStart);
            this.Controls.Add(this.cbAILevel);
            this.Controls.Add(this.pnBackToHome);
            this.Controls.Add(this.pnInRight);
            this.Controls.Add(this.pnInLeft);
            this.Controls.Add(this.pnBg);
            this.Name = "SinglePlayOptionForm";
            this.Text = "오목대전(싱글)";
            this.pnRule.ResumeLayout(false);
            this.pnRule.PerformLayout();
            this.pnColor.ResumeLayout(false);
            this.pnColor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private pnBg pnBg;
        private pnInLeft pnInLeft;
        private pnInRight pnInRight;
        private pnBackToHome pnBackToHome;
        private System.Windows.Forms.ComboBox cbAILevel;
        private System.Windows.Forms.RadioButton rbRenjuRule;
        private System.Windows.Forms.RadioButton rbOpeningRule;
        private System.Windows.Forms.Button btnGameStart;
        private System.Windows.Forms.RadioButton rbBlack;
        private System.Windows.Forms.RadioButton rbWhite;
        private System.Windows.Forms.Panel pnRule;
        private System.Windows.Forms.Panel pnColor;
    }
}
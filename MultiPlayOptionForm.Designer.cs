
namespace OmokProgram
{
    partial class MultiPlayOptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiPlayOptionForm));
            this.pnBg = new OmokProgram.pnBg();
            this.pnInLeft = new OmokProgram.pnInLeft();
            this.pnInRight = new OmokProgram.pnInRight();
            this.pnBackToHome = new OmokProgram.pnBackToHome();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.rbOpeningRule = new System.Windows.Forms.RadioButton();
            this.rbRenjuRule = new System.Windows.Forms.RadioButton();
            this.btnGameStart = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pnBg
            // 
            this.pnBg.Location = new System.Drawing.Point(0, 0);
            this.pnBg.Margin = new System.Windows.Forms.Padding(0);
            this.pnBg.Name = "pnBg";
            this.pnBg.Size = new System.Drawing.Size(724, 560);
            this.pnBg.TabIndex = 0;
            // 
            // pnInLeft
            // 
            this.pnInLeft.Location = new System.Drawing.Point(24, 20);
            this.pnInLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pnInLeft.Name = "pnInLeft";
            this.pnInLeft.Size = new System.Drawing.Size(478, 519);
            this.pnInLeft.TabIndex = 1;
            // 
            // pnInRight
            // 
            this.pnInRight.Location = new System.Drawing.Point(502, 20);
            this.pnInRight.Margin = new System.Windows.Forms.Padding(0);
            this.pnInRight.Name = "pnInRight";
            this.pnInRight.Size = new System.Drawing.Size(196, 519);
            this.pnInRight.TabIndex = 2;
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
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtIP.Location = new System.Drawing.Point(510, 172);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(182, 34);
            this.txtIP.TabIndex = 4;
            // 
            // rbOpeningRule
            // 
            this.rbOpeningRule.AutoSize = true;
            this.rbOpeningRule.Enabled = false;
            this.rbOpeningRule.Font = new System.Drawing.Font("나눔고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbOpeningRule.Location = new System.Drawing.Point(506, 265);
            this.rbOpeningRule.Name = "rbOpeningRule";
            this.rbOpeningRule.Padding = new System.Windows.Forms.Padding(5);
            this.rbOpeningRule.Size = new System.Drawing.Size(104, 34);
            this.rbOpeningRule.TabIndex = 5;
            this.rbOpeningRule.Text = "오프닝룰";
            this.rbOpeningRule.UseVisualStyleBackColor = true;
            // 
            // rbRenjuRule
            // 
            this.rbRenjuRule.AutoSize = true;
            this.rbRenjuRule.Checked = true;
            this.rbRenjuRule.Font = new System.Drawing.Font("나눔고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbRenjuRule.Location = new System.Drawing.Point(610, 265);
            this.rbRenjuRule.Name = "rbRenjuRule";
            this.rbRenjuRule.Padding = new System.Windows.Forms.Padding(5);
            this.rbRenjuRule.Size = new System.Drawing.Size(88, 34);
            this.rbRenjuRule.TabIndex = 6;
            this.rbRenjuRule.TabStop = true;
            this.rbRenjuRule.Text = "렌주룰";
            this.rbRenjuRule.UseVisualStyleBackColor = true;
            // 
            // btnGameStart
            // 
            this.btnGameStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(234)))), ((int)(((byte)(206)))));
            this.btnGameStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGameStart.Font = new System.Drawing.Font("휴먼둥근헤드라인", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGameStart.Location = new System.Drawing.Point(532, 343);
            this.btnGameStart.Name = "btnGameStart";
            this.btnGameStart.Size = new System.Drawing.Size(140, 52);
            this.btnGameStart.TabIndex = 7;
            this.btnGameStart.Text = "시작하기";
            this.btnGameStart.UseVisualStyleBackColor = false;
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPort.Location = new System.Drawing.Point(510, 212);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(182, 34);
            this.txtPort.TabIndex = 8;
            // 
            // MultiPlayOptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 560);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.btnGameStart);
            this.Controls.Add(this.rbRenjuRule);
            this.Controls.Add(this.rbOpeningRule);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.pnBackToHome);
            this.Controls.Add(this.pnInRight);
            this.Controls.Add(this.pnInLeft);
            this.Controls.Add(this.pnBg);
            this.Name = "MultiPlayOptionForm";
            this.Text = "오목대전(멀티)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private pnBg pnBg;
        private pnInLeft pnInLeft;
        private pnInRight pnInRight;
        private pnBackToHome pnBackToHome;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.RadioButton rbOpeningRule;
        private System.Windows.Forms.RadioButton rbRenjuRule;
        private System.Windows.Forms.Button btnGameStart;
        private System.Windows.Forms.TextBox txtPort;
    }
}
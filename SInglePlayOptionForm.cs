using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmokProgram
{
    public partial class SinglePlayOptionForm : Form
    {
        private bool closeProgram;
        private SinglePlayForm singlePlayForm = new SinglePlayForm();

        public SinglePlayOptionForm()
        {
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(closing);
            closeProgram = true;
        }

        private void pnBg_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 10; i++)
            {
                cbAILevel.Items.Add(i.ToString() + "단계");
            }
            cbAILevel.SelectedIndex = 0;
            rbRenjuRule.Select();
        }
        private void pnBackToHome_Click(object sender, EventArgs e)
        {
            closeProgram = false;
            Close();
            if (Application.OpenForms["mainForm"] != null)
                Application.OpenForms["mainForm"].WindowState = FormWindowState.Normal;
        }
        private void btnGameStart_Click(object sender, EventArgs e)
        {
            closeProgram = false;
            singlePlayForm.playerColor = rbBlack.Checked ? STONE.black : STONE.white;
            Close();
            singlePlayForm.Show();
        }

        private void closing(object sender, EventArgs e)
        {
            if (closeProgram) Application.Exit();
        }
    }
}

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
    public partial class mainForm : Form
    {
        private SinglePlayOptionForm singlePlayOptionForm;
        private MultiPlayOptionForm multiPlayOptionForm;

        public mainForm()
        {
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(closing);
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "btnSinglePlay":
                    singlePlayOptionForm = new SinglePlayOptionForm();
                    singlePlayOptionForm.mainFormMaximize += mainFormSizeNormal;
                    singlePlayOptionForm.Location = new Point(this.Location.X, this.Location.Y);
                    singlePlayOptionForm.Show();
                    break;
                case "btnMultiPlay":
                    multiPlayOptionForm = new MultiPlayOptionForm();
                    multiPlayOptionForm.mainFormMaximize += mainFormSizeNormal;
                    multiPlayOptionForm.Location = new Point(this.Location.X, this.Location.Y);
                    multiPlayOptionForm.Show();
                    break;
                default:
                    Application.Exit();
                    break;
            }
            this.WindowState = FormWindowState.Minimized;
            //this.ShowInTaskbar = false;  // 자연스럽지 않아서 지움
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void closing(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void mainFormSizeNormal(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            //this.ShowInTaskbar = true;
        }
    }
}

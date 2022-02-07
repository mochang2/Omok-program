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
    public partial class MultiPlayForm : Form
    {
        public delegate void mainFormMaximizeHandler(object sender, EventArgs e);
        public event mainFormMaximizeHandler mainFormNormal;
        private bool closeProgram;

        public MultiPlayForm()
        {
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(closing);
            closeProgram = true;
        }
        private void pnBackToHome_Click(object sender, EventArgs e)
        {
            closeProgram = false;
            Close();
            mainFormNormal(sender, e);
        }

        private void closing(object sender, EventArgs e)
        {
            if (closeProgram) Application.Exit();
        }
    }
}
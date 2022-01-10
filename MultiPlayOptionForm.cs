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
    public partial class MultiPlayOptionForm : Form
    {
        public delegate void mainFormMaximizeHandler(object sender, EventArgs e);
        public event mainFormMaximizeHandler mainFormMaximize;
        private bool closeProgram;

        private TextBox[] txtList;
        private const string IPPlaceholder = "IP";
        private const string portPlaceholder = "Port";

        public MultiPlayOptionForm()
        {
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(closing);
            closeProgram = true;

            txtList = new TextBox[] { txtIP, txtPort };
            foreach (var txt in txtList)
            {
                txt.ForeColor = Color.DarkGray;
                if (txt == txtIP) txt.Text = IPPlaceholder;
                else if (txt == txtPort) txt.Text = portPlaceholder;

                //txt.GotFocus += RemovePlaceholder;
                //txt.LostFocus += SetPlaceholder;
            }
        }
        private void pnBackToHome_Click(object sender, EventArgs e)
        {
            closeProgram = false;
            Close();
            mainFormMaximize(sender, e);
        }

        private void closing(object sender, EventArgs e)
        {
            if (closeProgram) Application.Exit();
        }

    }
}

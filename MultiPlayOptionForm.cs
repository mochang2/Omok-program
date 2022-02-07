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
        public event mainFormMaximizeHandler mainFormNormal;
        private bool closeProgram;
        public MultiPlayForm multiPlayForm;

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

                txt.GotFocus += RemovePlaceholder;
                txt.LostFocus += SetPlaceholder;
            }
        }
        private void RemovePlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text == IPPlaceholder || txt.Text == portPlaceholder)
            {
                txt.ForeColor = Color.Black;
                txt.Text = string.Empty;
            }
        }
        private void SetPlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.ForeColor = Color.DarkGray; //Placeholder 흐린 글씨
                if (txt == txtIP) txt.Text = IPPlaceholder;
                else if (txt == txtPort) txt.Text = portPlaceholder;
            }
        }

        private void pnBackToHome_Click(object sender, EventArgs e)
        {
            closeProgram = false;
            Close();
            mainFormNormal(sender, e);
        }
        private void btnGameStart_Click(object sender, EventArgs e)
        {
            // ip, port 조건 필요
            closeProgram = false;
            Close();
            multiPlayForm.Show();
        }

        private void closing(object sender, EventArgs e)
        {
            if (closeProgram) Application.Exit();
        }
    }
}

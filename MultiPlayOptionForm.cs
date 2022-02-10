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
        private bool closeProgram;
        public MultiPlayForm multiPlayForm;

        // connection
        private TextBox[] txtList;
        private const string IPPlaceholder = "IP";
        private const string portPlaceholder = "Port";
        private bool connection = false;  // 연결되면 true
        private bool ready = false; // ready 보내고 true
        // 이후에 multiplay game 띄우기


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
            if (Application.OpenForms["mainForm"] != null)
                Application.OpenForms["mainForm"].WindowState = FormWindowState.Normal;
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

    public class Protocol
    {
        public byte command;
        public byte turn;
        public byte data;

        public Protocol()
        {
            command = (byte)0;
            turn = (byte)0;
            data = (byte)0;
        }
    }
}

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
        // 순서(비동기 작업 x). public turn을 가지고 있다가
        // multi play option form에서 연결 성공하면 여기 turn에 저장하기.
        // 

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
            if (Application.OpenForms["mainForm"] != null)
                Application.OpenForms["mainForm"].WindowState = FormWindowState.Normal;
        }

        private void closing(object sender, EventArgs e)
        {
            if (closeProgram) Application.Exit();
        }
    }
}
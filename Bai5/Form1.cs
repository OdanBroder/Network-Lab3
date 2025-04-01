using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai5
{
    public partial class Form1: Form
    {
        private static bool isServerRunning = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isServerRunning)
            {
                MessageBox.Show("Server is already running!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isServerRunning = true;
            Server server = new Server();

            server.FormClosed += (s, args) => isServerRunning = false;
            server.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }
    }
}

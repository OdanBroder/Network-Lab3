using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace UDP_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            try
            {
                using (UdpClient udpClient = new UdpClient()) // tao ket noi
                {
                    Byte[] sendBytes = Encoding.UTF8.GetBytes(richTextBox1.Text);
                    string host = textBox_IP.Text.Trim();
                    int port = Int32.Parse(textBox_Port.Text.Trim());
                    udpClient.Send(sendBytes, sendBytes.Length, host, port);
                    richTextBox1.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

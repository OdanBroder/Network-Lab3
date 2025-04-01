using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace UDP_Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void server_Thread()
        {
            try
            {
                int port = Int32.Parse(textBox_Port.Text.Trim());
                richTextBox1.AppendText("Server is listening on port " + port + "\n");
                UdpClient udpClient = new UdpClient(port);

                while (true)
                {
                    IPEndPoint RemoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    Byte[] receiveBytes = udpClient.Receive(ref RemoteEndPoint);
                    string returnData = Encoding.UTF8.GetString(receiveBytes);
                    string mess = RemoteEndPoint.Address.ToString() + ": " + returnData + "\n";
                    richTextBox1.AppendText(mess);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }

        }
        private void button_Listen_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread thdUDPServer = new Thread(new ThreadStart(server_Thread));
            thdUDPServer.Start();
        }
    }
}

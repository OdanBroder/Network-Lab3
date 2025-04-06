using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai3
{
    public partial class Client : Form
    {
        private TcpClient tcpClient;
        private NetworkStream networkStream;

        public Client()
        {
            InitializeComponent();
        }

        private void StartConnect(object sender, EventArgs e)
        {
            if (tcpClient == null || !tcpClient.Connected)
            {
                tcpClient = new TcpClient();
            }
            else
            {
                MessageBox.Show("Already Connected");
                return;
            }

                IPEndPoint ipEndPoint = TCPInitConnect(textBoxIP.Text, textBoxPort.Text);
            if (ipEndPoint == null)
            {
                MessageBox.Show("Failed to create connection. Check IP and Port.");
                return;
            }

            try
            {
                tcpClient.Connect(ipEndPoint);
                networkStream = tcpClient.GetStream();
                MessageBox.Show("Connected to Server");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error: " + ex.Message);
            }
        }

        private async void SendMessage(object sender, EventArgs e)
        {
            if (tcpClient == null || !tcpClient.Connected || networkStream == null)
            {
                MessageBox.Show("Not connected to the server.");
                return;
            }

            try
            {
                Byte[] sendData = Encoding.UTF8.GetBytes(richTextBoxSend.Text + "\n");
                await networkStream.WriteAsync(sendData, 0, sendData.Length);

                string response = await ReadResponseAsync();
                richTextBoxReiceive.Text = response;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending or receiving message: " + ex.Message);
            }
        }

        private async Task<string> ReadResponseAsync()
        {
            Byte[] Data = new Byte[1024];
            int bytesRead = await networkStream.ReadAsync(Data, 0, Data.Length);
            if (bytesRead == 0)
            {
                throw new Exception("Server closed connection.");
            }
            return Encoding.UTF8.GetString(Data, 0, bytesRead);
        }


        private IPEndPoint TCPInitConnect(string IpAddress, string port)
        {
            if (!IPAddress.TryParse(IpAddress, out IPAddress IPserver))
            {
                MessageBox.Show("Invalid IP address: " + textBoxIP.Text);
                return null;
            }
            if (!int.TryParse(port, out int PortServer) || PortServer < 0 || PortServer > 65535)
            {
                MessageBox.Show("Invalid Port: " + textBoxPort.Text);
                return null;
            }
            return new IPEndPoint(IPserver, PortServer);
        }

        private Byte[] TCPreceive()
        {
            Byte[] Data = new Byte[1024];
            int bytesRead = networkStream.Read(Data, 0, Data.Length);
            Array.Resize(ref Data, bytesRead);
            return Data;
        }

        private void Disconnect(object sender, EventArgs e)
        {
            if (tcpClient != null && tcpClient.Connected)
            {
                Byte[] Data = Encoding.UTF8.GetBytes("quit\n");
                networkStream.Write(Data, 0, Data.Length);
                networkStream.Close();
                tcpClient.Close();
                tcpClient = null;
                MessageBox.Show("Disconnected to Server");
            }
            else
            {
                MessageBox.Show("Already disconnected.");
            }
        }
    }
}
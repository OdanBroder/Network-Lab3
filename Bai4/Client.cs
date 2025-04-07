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

        private async void StartConnect(object sender, EventArgs e)
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

            IPEndPoint ipEndPoint = TCPInitConnect("127.0.0.1", "1337");
            if (ipEndPoint == null)
            {
                MessageBox.Show("Failed to create connection. Check IP and Port.");
                return;
            }

            try
            {
                await tcpClient.ConnectAsync(ipEndPoint.Address, ipEndPoint.Port);
                networkStream = tcpClient.GetStream();
                MessageBox.Show("Connected to Server");

                _ = Task.Run(() => ReceiveMessagesAsync());
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
                Byte[] sendData = Encoding.UTF8.GetBytes(textBoxName.Text + ": " + richTextBoxSend.Text + "\n");
                await networkStream.WriteAsync(sendData, 0, sendData.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending message: " + ex.Message);
            }
        }

        private async Task ReceiveMessagesAsync()
        {
            Byte[] buffer = new Byte[1024];
            try
            {
                while (tcpClient.Connected)
                {
                    int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        throw new Exception("Server closed connection.");
                    }

                    string receivedText = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Invoke((MethodInvoker)(() =>
                    {
                        richTextBoxReiceive.AppendText(receivedText);
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error receiving message: " + ex.Message);
            }
        }

        private IPEndPoint TCPInitConnect(string IpAddress, string port)
        {
            if (!IPAddress.TryParse(IpAddress, out IPAddress IPserver))
            {
                MessageBox.Show("Invalid IP address: " + "127.0.0.1");
                return null;
            }
            if (!int.TryParse(port, out int PortServer) || PortServer < 0 || PortServer > 65535)
            {
                MessageBox.Show("Invalid Port: " + "1337");
                return null;
            }
            return new IPEndPoint(IPserver, PortServer);
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
                MessageBox.Show("Disconnected from Server");
            }
            else
            {
                MessageBox.Show("Already disconnected.");
            }
        }
    }
}

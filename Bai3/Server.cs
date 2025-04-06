using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Bai3
{
    public partial class Server : Form
    {
        private Socket listenerSocket;

        public Server()
        {
            InitializeComponent();
        }

        private void StartListen(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(StartUnsafeThread);
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        void StartUnsafeThread()
        {
            try
            {
                listenerSocket = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);

                if (!IPAddress.TryParse(textBoxIP.Text, out IPAddress IPserver))
                {
                    MessageBox.Show("Invalid IP address server");
                    return;
                }

                if (!int.TryParse(textBoxPort.Text, out int PortServer) || PortServer < 0 || PortServer > 65535)
                {
                    MessageBox.Show("Invalid port server");
                    return;
                }

                IPEndPoint ipepServer = new IPEndPoint(IPserver, PortServer);
                listenerSocket.Bind(ipepServer);
                listenerSocket.Listen(5);

                richTextBoxLogs.Invoke((MethodInvoker)(() =>
                {
                    richTextBoxLogs.AppendText("Server started...\n");
                }));

                while (true)
                {
                    Socket clientSocket = listenerSocket.Accept();
                    byte[] welcomeMessage = Encoding.ASCII.GetBytes("Hello client\n\n");
                    clientSocket.Send(welcomeMessage);
                    richTextBoxLogs.Text += "Receive\n";
                    Thread clientThread = new Thread(() => HandleClient(clientSocket));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server error: " + ex.Message);
            }
        }

        void HandleClient(Socket clientSocket)
        {
            try
            {
                richTextBoxLogs.Invoke((MethodInvoker)(() =>
                {
                    richTextBoxLogs.AppendText("New Client Connected\n");
                }));

                byte[] buffer = new byte[1024];

                while (true)
                {
                    int bytesReceived = clientSocket.Receive(buffer);
                    if (bytesReceived <= 0) break;

                    string receivedText = Encoding.UTF8.GetString(buffer, 0, bytesReceived);

                    richTextBoxLogs.Invoke((MethodInvoker)(() =>
                    {
                        richTextBoxLogs.AppendText(receivedText);
                    }));
                }
            }
            catch (SocketException)
            {
                richTextBoxLogs.Invoke((MethodInvoker)(() =>
                {
                    richTextBoxLogs.AppendText("Client disconnected unexpectedly.\n");
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Client error: " + ex.Message);
            }
            finally
            {
                clientSocket.Close();
                richTextBoxLogs.Invoke((MethodInvoker)(() =>
                {
                    richTextBoxLogs.AppendText("Client disconnected.\n");
                }));
            }
        }
    }
}

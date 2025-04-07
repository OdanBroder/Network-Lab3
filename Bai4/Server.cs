using System;
using System.Collections.Generic;
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
        private List<Socket> clientSockets = new List<Socket>();
        private readonly object clientListLock = new object();

        public Server()
        {
            InitializeComponent();
            richTextBoxLogs.Text = "Server running on 127.0.0.1:1337\n";
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

                if (!IPAddress.TryParse("127.0.0.1", out IPAddress IPserver))
                {
                    MessageBox.Show("Invalid IP address server");
                    return;
                }

                if (!int.TryParse("1337", out int PortServer) || PortServer < 0 || PortServer > 65535)
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
                    lock (clientListLock)
                    {
                        clientSockets.Add(clientSocket);
                    }
                    byte[] welcomeMessage = Encoding.ASCII.GetBytes("Hello client, you've connected to the server\n\n");
                    clientSocket.Send(welcomeMessage);
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
                IPEndPoint remoteEndPoint = clientSocket.RemoteEndPoint as IPEndPoint;
                string clientIP = remoteEndPoint.Address.ToString();
                int clientPort = remoteEndPoint.Port;

                richTextBoxLogs.Invoke((MethodInvoker)(() =>
                {
                    richTextBoxLogs.AppendText($"New Client Connected from {clientIP}:{clientPort}\n");
                }));

                byte[] buffer = new byte[1024];

                while (true)
                {
                    int bytesReceived = clientSocket.Receive(buffer);
                    if (bytesReceived <= 0) break;

                    string receivedText = Encoding.UTF8.GetString(buffer, 0, bytesReceived);

                    richTextBoxLogs.Invoke((MethodInvoker)(() =>
                    {
                        richTextBoxLogs.AppendText($"{clientIP}:{clientPort}: " + receivedText);
                    }));

                    BroadcastMessage($"{clientIP}:{clientPort}: " + receivedText, clientSocket);
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
                lock (clientListLock)
                {
                    clientSockets.Remove(clientSocket);
                }
                clientSocket.Close();
                richTextBoxLogs.Invoke((MethodInvoker)(() =>
                {
                    richTextBoxLogs.AppendText("Client disconnected.\n");
                }));
            }
        }

        void BroadcastMessage(string message, Socket excludeSocket)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message + "\n");
            lock (clientListLock)
            {
                foreach (Socket clientSocket in clientSockets)
                {
                    if (clientSocket != excludeSocket)
                    {
                        try
                        {
                            clientSocket.Send(messageBytes);
                        }
                        catch (SocketException)
                        {
                            // Handle the case where the client has disconnected
                            clientSockets.Remove(clientSocket);
                            clientSocket.Close();
                        }
                    }
                }
            }
        }
    }
}

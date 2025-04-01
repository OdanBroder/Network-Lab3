using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace TCP_Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void StartUnsafeThread()
        {
            int bytesReceived = 0;
            byte[] recv = new byte[1024];
            Socket clientSocket; // tạo socket bên gửi 

            /*Tạo socket bên nhận, socket này là socket lắng nghe các kết nối tới nó tại địa chỉ IP 
            của máy và port 8080.Đây là 1 TCP / IP socket.
            */
            Socket listenerSocket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
                );
            IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            listenerSocket.Bind(ipepServer);
            listenerSocket.Listen(1);// Bắt đầu lắng nghe 
            richTextBox1.AppendText("Telnet running on 127.0.0.1: 8080" + "\n");
            clientSocket = listenerSocket.Accept(); // Nhận dữ liệu
            
            try
            {
                while (true)
                {
                    string text = "";
                    bytesReceived = clientSocket.Receive(recv);
                    if (bytesReceived == 0) break;
                           
                    text = Encoding.UTF8.GetString(recv, 0 , bytesReceived);
                     
                    richTextBox1.AppendText(text);
                }
            }
            catch (SocketException se)
            {
                richTextBox1.AppendText(se.Message + "\n");
            }
            finally
            {
                richTextBox1.AppendText("Close connection!" + "\n");
                clientSocket.Close();
                listenerSocket.Close();
            }
        }
    private void button_Listen_Click(object sender, EventArgs e)
        {
            //Xử lý lỗi InvalidOperationException 
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.Start();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace The_Application_Of_Asymetric_Cipher
{
    public partial class Server_Advanced : Form
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Server_Advanced()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            textNote.ReadOnly = true;
            textMessage.ReadOnly = true;
            this.Size = new Size(818, 687);
            panel_Server.Dock = DockStyle.Fill;
            StartToListen();
        }
        // Khởi tạo các tham số cần thiết cho kết nối mạng và mã hóa.
        private TcpListener server;
        private TcpClient client;
        private NetworkStream stream;
        private RSAParameters rsaPa;

        // Tạo một lớp để lưu trữ các kết nối và khóa công khai của Client.
        public class KeyTCPClient
        {
            public TcpClient tcpClient { get; set; }
            public int port;
            public KeyTCPClient(TcpClient tCli, int p)
            {
                this.tcpClient = tCli;
                this.port = p;
            }
        }
        List<KeyTCPClient> clients = new List<KeyTCPClient>();

        private void StartToListen()    // Lắng nghe kết nối từ Client.
        {
            try
            {
                server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8081);
                server.Start();
                textNote.AppendText("Server running on 127.0.0.1: 8081\n" + Environment.NewLine);
                Task.Run(() => AcceptClients());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void AcceptClients()    // Chấp nhận kết nối.
        {
            while (true)
            {
                try
                {
                    client = server.AcceptTcpClient();
                    KeyTCPClient keyTcpCli = new KeyTCPClient(client, 0);
                    clients.Add(keyTcpCli);
                    Task.Run(() => HandleClientMessages(client));
                }
                catch { }
            }
        }
        void AddMessageToChatWindow(string message, int temp) // Thêm tin vào khung chat
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (temp == 1)
                    textMessage.AppendText($"{message}{Environment.NewLine}");
                else if (temp == 2)
                    textNote.AppendText($"{message}{Environment.NewLine}");
            });
        }

        KeyTCPClient GetKeyTCPClientFromTCPClient(TcpClient cli)    //Hàm để trả về đối tượng của danh sách các Client
        {
            foreach (var client in clients)
            {
                if (client.tcpClient == cli)
                    return client;
            }
            return null;
        }
        void HandleClientMessages(TcpClient client) // Nhận dữ liệu từ Client.
        {
            byte[] buffer = new byte[1024 * 6];
            int bytesRead;
            while (true)
            {
                try
                {
                    stream = client.GetStream();
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        AddMessageToChatWindow("Disconnected from " + client.Client.RemoteEndPoint.ToString(), 2);
                        break;
                    }
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    // Nếu dữ liệu gửi tới là khóa công khai của Client mới thì gửi broadcast cho các Client còn lại.
                    if (message.Contains("New client connected from 127.0.0.1"))
                    {
                        var posLineBreak = message.IndexOf('\n');
                        IPEndPoint iP = (IPEndPoint)client.Client.RemoteEndPoint;
                        var connectMessage = $"{message.Substring(0, posLineBreak)}{":"}{iP.Port.ToString()}";
                        foreach (var cli in clients)
                        {
                            if (client == cli.tcpClient)
                            {
                                cli.port = iP.Port;
                            }
                        }
                        BroadcastMessage(message.Replace(message.Substring(0, posLineBreak), connectMessage), client);
                        AddMessageToChatWindow("New client connected from " + client.Client.RemoteEndPoint.ToString(), 2);
                    }
                    // Nếu dữ liệu gửi tới là khóa công khai của Client cũ thì gửi cho Client mới
                    else if (message.Contains("Send key for 127.0.0.1"))
                    {
                        var posLineBreak = message.IndexOf('\n');
                        var posColon = message.IndexOf(':');
                        var receiverPort = int.Parse(message.Substring(posColon + 1, posLineBreak - posColon - 1));
                        foreach (var cli in clients)
                        {
                            if (receiverPort == cli.port)
                            {
                                buffer = Encoding.UTF8.GetBytes(message);
                                NetworkStream netStream = cli.tcpClient.GetStream();
                                netStream.Write(buffer, 0, buffer.Length);
                            }
                        }
                    }
                    else   // Nếu dữ liệu được gửi đến là tin nhắn, tiến hành broadcast
                    {
                        AddMessageToChatWindow(message, 1);
                        BroadcastMessage(message, client);
                    }
                }
                catch { break; }
            }
        }

        void BroadcastMessage(string message, TcpClient sender) // Broadcast tin nhắn
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            foreach (KeyTCPClient receiver in clients)
            {
                try
                {
                    if (receiver.tcpClient != sender)
                    {
                        NetworkStream netStream = receiver.tcpClient.GetStream();
                        netStream.Write(buffer, 0, buffer.Length);
                    }
                }
                catch { }
            }
        }
        public string RSAEncrypt(string plainText, RSAParameters key)   // Mã hóa thông tin để gửi đi
        {
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            csp.ImportParameters(key);
            var buffer = Encoding.UTF8.GetBytes(plainText);
            var cypher = csp.Encrypt(buffer, false);
            return Convert.ToBase64String(cypher);
        }

        public string RSADecrypt(string cipherText, RSAParameters key)  // Giải mã thông tin từ Client gửi đến
        {
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            var buffer = Convert.FromBase64String(cipherText);
            csp.ImportParameters(key);
            var plainText = csp.Decrypt(buffer, false);
            return Encoding.UTF8.GetString(plainText);
        }

        private void Server_Advanced_FormClosed(object sender, FormClosedEventArgs e)
        {
            clients.Clear();
            server.Stop();
        }
    }
}

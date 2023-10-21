using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace The_Application_Of_Asymetric_Cipher
{
    public partial class Server : Form
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Server()
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
            public RSAParameters publicKey { get; set; }
            public int port;
            public KeyTCPClient(TcpClient tCli, RSAParameters key, int p)
            {
                this.tcpClient = tCli;
                this.publicKey = key;
                this.port = p;
            }
        }
        List<KeyTCPClient> clients = new List<KeyTCPClient>();

        private void StartToListen()    // Lắng nghe kết nối từ Client.
        {
            try
            {
                server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
                server.Start();
                textNote.AppendText("Server running on 127.0.0.1: 8080\n" + Environment.NewLine);
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
                    KeyTCPClient keyTcpCli = new KeyTCPClient(client, rsaPa, 0);
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
                if (client.tcpClient == cli) return client;
            return null;
        }
        void HandleClientMessages(TcpClient client) // Nhận dữ liệu từ Client.
        {
            byte[] buffer = new byte[1024 * 4];
            int bytesRead;
            String plainText = "";
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
                    // Nếu dữ liệu gửi tới là khóa công khai, tiến hành lưu trữ.
                    if (message.Contains("New client connected from 127.0.0.1"))
                    {
                        var posLineBreak = message.IndexOf('\n');
                        IPEndPoint iP = (IPEndPoint)client.Client.RemoteEndPoint;
                        var string_rsaPa = message.Substring(posLineBreak + 1);
                        rsaPa = StringToKey(string_rsaPa);
                        foreach (var cli in clients)
                        {
                            if (client == cli.tcpClient)
                            {
                                cli.publicKey = rsaPa;
                                cli.port = iP.Port;
                            }
                        }
                        AddMessageToChatWindow("New client connected from " + client.Client.RemoteEndPoint.ToString(), 2);
                    }
                    else   // Nếu dữ liệu được gửi đến là tin nhắn, tiến hành broadcast
                    {
                        plainText = RSADecrypt(message, GetKeyTCPClientFromTCPClient(client).publicKey);
                        AddMessageToChatWindow(plainText, 1);
                        BroadcastMessage(plainText, client);
                    }
                }
                catch { this.Close(); break; }
            }
        }

        void BroadcastMessage(string message, TcpClient sender) // Broadcast tin nhắn
        {
            String cipherText;
            byte[] buffer;
            foreach (KeyTCPClient receiver in clients)
            {
                try
                {
                    if (receiver.tcpClient != sender)
                    {
                        cipherText = RSAEncrypt(message, receiver.publicKey);
                        buffer = Encoding.UTF8.GetBytes(cipherText);
                        NetworkStream netStream = receiver.tcpClient.GetStream();
                        netStream.Write(buffer, 0, buffer.Length);
                    }
                }
                catch { }
            }
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            server.Stop();
            foreach (var client in clients)
            {
                client.tcpClient.Close();
            }
            clients.Clear();
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
        private RSAParameters StringToKey(string keyString) // Chuyển từ chuỗi sang khóa
        {
            var xs = new XmlSerializer(typeof(RSAParameters));
            var key = (RSAParameters)xs.Deserialize(new StringReader(keyString));
            return key;
        }
    }
}

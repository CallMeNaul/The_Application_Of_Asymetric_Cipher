using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace The_Application_Of_Asymetric_Cipher
{
    public partial class Client_Advanced : Form
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Client_Advanced(int num)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
            client_Num = num;
            CheckForIllegalCrossThreadCalls = false;
            textDisplayMessage.ReadOnly = true;
            SetState(true);
            this.Text = "Client " + num.ToString();
            InitKey();
        }
        public int client_Num;
        // Tạo các biến cho việc kết nối 
        TcpClient client;
        NetworkStream stream;
        RSAParameters rsaPa;
        byte[] buffer = new byte[1024 * 5];
        // Tạo lớp để lưu trữ khóa của các Client khác
        public class KeyTCPClient
        {
            public int port { get; set; }
            public RSAParameters rsa { get; set; }
            public KeyTCPClient(int p, RSAParameters r)
            {
                this.port = p;
                this.rsa = r;
            }
        }
        List<KeyTCPClient> clients = new List<KeyTCPClient>();
        void SetState(bool value)   // Tạo trạng thái của giao diện: Đăng nhập và Chat
        {
            if (value)  // Đăng nhập
            {
                this.Height = 195;
                this.Width = 340;
                panel_Login.Dock = DockStyle.Fill;
                panel_Chat.Visible = false;
            }
            else     // Chat
            {
                panel_Login.Visible = false;
                panel_Chat.Visible = true;
                this.Height = 497;
                this.Width = 818;
                panel_Chat.Dock = DockStyle.Fill;
                grb_Chat.Text = "Name: " + textName.Text;
            }
        }
        void GetConnection()    // Khởi tạo kết nối tới Server
        {
            try
            {
                client = new TcpClient("127.0.0.1", 8081);
                stream = client.GetStream();
                string message = "New client connected from 127.0.0.1 " + textName.Text + "\n" + publicKey;
                Thread rec = new Thread(ReceiveMessage);
                rec.IsBackground = true;
                rec.Start();
                byte[] keyByte = Encoding.UTF8.GetBytes(message);
                keyByte.CopyTo(buffer, 0);
                stream.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
                return;
            }
        }

        void DisconnectFrom() // Ngắt kết nối
        {
            if (client != null) client.Close();
            if (stream != null) stream.Close();
        }

        void SendMessage()  // Gửi tin nhắn
        {
            try
            {
                string message = textName.Text + ": " + textMessage.Text;
                string encryptedMessage = RSAEncrypt(message, privateKey);
                byte[] buffer = Encoding.UTF8.GetBytes(encryptedMessage);
                stream.Write(buffer, 0, buffer.Length);
                AddMessageToChatWindow(message);
                textMessage.Text = String.Empty;
            }
            catch { }
        }

        void AddMessageToChatWindow(string message) // Thêm tin vào khung chat
        {
            this.Invoke((MethodInvoker)delegate
            {
                textDisplayMessage.AppendText($"{message}{Environment.NewLine}");
            });
        }
        void ReceiveMessage()   // Nhận tin
        {
            byte[] buffer = new byte[1024 * 6];
            int bytesRead;
            String plainText = "";
            while (true)
            {
                try
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    // Nếu gói tin được gửi đến bao gồm kết nối từ Client mới hoặc gửi khóa cho Client hiện tại
                    if (message.Contains("New client connected from 127.0.0.1")
                        || message.Contains("Send key for 127.0.0.1"))
                    {
                        // Tiến hành lưu trữ
                        var posLineBreak = message.IndexOf('\n');
                        var posColon = message.IndexOf(':');
                        var port = int.Parse(message.Substring(posColon + 1, posLineBreak - posColon - 1));
                        rsaPa = StringToKey(message.Substring(posLineBreak + 1));
                        if (!clients.Contains(new KeyTCPClient(port, rsaPa)))
                            clients.Add(new KeyTCPClient(port, rsaPa));
                        Array.Clear(buffer);
                        //Vì Server không lưu khóa nên phải gửi khóa của Client này cho Client mới vào
                        if (message.Contains("New client connected from 127.0.0.1"))
                        {
                            var sendKeyMessage = "Send key for 127.0.0.1:" + port.ToString() + "\n" + publicKey;
                            var keyByte = Encoding.UTF8.GetBytes(sendKeyMessage);
                            keyByte.CopyTo(buffer, 0);
                            stream.Write(buffer, 0, buffer.Length);
                        }
                    }
                    //  Nếu gói tin là tin nhắn bình thường thì tiến hành giải mã và thêm vào khung chat
                    else
                    {
                        foreach (var item in clients)
                        {
                            try
                            {
                                plainText = RSADecrypt(message, KeytoString(item.rsa));
                                if (plainText != "") break;
                            }
                            catch { }
                        }
                        AddMessageToChatWindow(plainText);
                    }
                }
                catch { break; }
            }
            this.Close();
            return;
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if (textMessage.Text != "")
                SendMessage();
        }
        private void btn_Join_Click(object sender, EventArgs e)
        {
            if (textName.Text == String.Empty)
            {
                MessageBox.Show("Please enter your name!", "Missing Name Field", MessageBoxButtons.OK);
                return;
            }
            Thread cnt = new Thread(() => GetConnection());
            cnt.IsBackground = true;
            cnt.Start();
            SetState(false);
        }
        private void Client_Advanced_FormClosed(object sender, FormClosedEventArgs e) { DisconnectFrom(); }
        // Tạo các biến cho quá trình mã hóa
        private RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        private RSACryptoServiceProvider deCsp;
        private String publicKey;
        private String privateKey;

        public void InitKey()   // Tạo 2 khóa bí mật và công khai
        {
            privateKey = KeytoString(csp.ExportParameters(false));
            publicKey = KeytoString(csp.ExportParameters(true));
        }

        public string RSAEncrypt(string plainText, String key)   // Mã hóa thông tin
        {
            var buffer = Encoding.UTF8.GetBytes(plainText);
            var cypher = csp.Encrypt(buffer, false);
            return Convert.ToBase64String(cypher);
        }

        public string RSADecrypt(string cipherText, String key)  // Giải mã thông tin
        {
            deCsp = new RSACryptoServiceProvider();
            deCsp.FromXmlString(key);
            var buffer = Convert.FromBase64String(cipherText);
            var plainText = deCsp.Decrypt(buffer, false);
            return Encoding.UTF8.GetString(plainText);
        }

        private string KeytoString(RSAParameters key)   // Chuyển từ khóa sang chuỗi
        {
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, key);
            return sw.ToString();
        }
        private RSAParameters StringToKey(string keyString) // Chuỗi từ chuỗi sang khóa
        {
            var xs = new XmlSerializer(typeof(RSAParameters));
            var key = (RSAParameters)xs.Deserialize(new StringReader(keyString));
            return key;
        }
    }
}

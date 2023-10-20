using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace The_Application_Of_Asymetric_Cipher
{
    public partial class Client : Form
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Client(int num)
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
        TcpClient client;
        NetworkStream stream;
        byte[] buffer = new byte[1024 * 4];
        bool isLogin = false;

        void SetState(bool value)   // Tạo trạng thái của giao diện: Đăng nhập và Chat
        {
            if (value)  // Đăng nhập
            {
                panel_Login.Dock = DockStyle.Fill;
                this.Height = 195;
                this.Width = 340;
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
                client = new TcpClient("127.0.0.1", 8080);
                stream = client.GetStream();
                string message = "New client connected from 127.0.0.1 " + textName.Text + "\n";
                Thread rec = new Thread(ReceiveMessage);
                rec.IsBackground = true;
                rec.Start();
                byte[] flag = Encoding.UTF8.GetBytes(message);
                byte[] keyByte = Encoding.UTF8.GetBytes(publicKey);
                flag.CopyTo(buffer, 0);
                keyByte.CopyTo(buffer, flag.Length);
                stream.Write(buffer, 0, buffer.Length);
            }
            catch (Exception)
            {
                MessageBox.Show("Disconnected from Server", "System Notification", MessageBoxButtons.OK);
                client.Close();
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
            textDisplayMessage.AppendText($"{message}{Environment.NewLine}");
        }
        void ReceiveMessage()   // Nhận tin
        {
            byte[] buffer = new byte[1024 * 4];
            int bytesRead;
            while (true)
            {
                try
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    String plainText = RSADecrypt(message, privateKey);
                    AddMessageToChatWindow(plainText);
                }
                catch
                {
                    DisconnectFrom();
                    return;
                }
            }
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e) { DisconnectFrom(); }

        private void btSend_Click(object sender, EventArgs e) 
        {
            if(textMessage.Text != "")
                SendMessage();
        }

        private void btn_Join_Click(object sender, EventArgs e)
        {
            if (textName.Text == String.Empty)
            {
                MessageBox.Show("Please enter your name!", "Missing Name Field", MessageBoxButtons.OK);
                return;
            }
            SetState(false);
            Thread cnt = new Thread(new ThreadStart(() => GetConnection()));
            cnt.IsBackground = true;
            cnt.Start();
            isLogin = true;
        }
        // Tạo các biến cho quá trình mã hóa
        private RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
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
            var buffer = Convert.FromBase64String(cipherText);
            var plainText = csp.Decrypt(buffer, false);
            return Encoding.UTF8.GetString(plainText);
        }

        private string KeytoString(RSAParameters key)
        {
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, key);
            return sw.ToString();
        }
    }
}

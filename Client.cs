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
            CheckForIllegalCrossThreadCalls = false;
            textDisplayMessage.ReadOnly = true;
            SetState(true);
            this.Text = "Client " + num.ToString();
            InitKey();
        }
        // Tạo các tham số cho việc kết nối và lưu trữ khóa công khai của các Client khác
        TcpClient client;
        List<RSAParameters> keyList = new List<RSAParameters>();
        NetworkStream stream;
        byte[] buffer = new byte[1024 * 4];
        
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
                string message = "New client connected from: 127.0.0.1 " + textName.Text + "\n";
                stream = client.GetStream();
                Thread rec = new Thread(ReceiveMessage);
                rec.IsBackground = true;
                rec.Start();
                byte[] flag = Encoding.UTF8.GetBytes(message);
                byte[] keyByte = RSAParametersToBytes(_publicKey);
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
            if (client != null)
                client.Close();
            if (stream != null)
                stream.Close();
            keyList.Clear();
        }

        void SendMessage()  // Gửi tin nhắn
        {
            if (!client.Connected)
            {
                MessageBox.Show("Disconnected from Server", "System Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            string message = textName.Text + ": " + textMessage.Text;
            byte[] buffer = Encoding.UTF8.GetBytes(RSAEncrypt(message, _privateKey));
            stream.Write(buffer, 0, buffer.Length);
            textDisplayMessage.Text = String.Concat(textDisplayMessage.Text, message);
            textDisplayMessage.AppendText(Environment.NewLine);
            textMessage.Text = String.Empty;
        }

        void AddMessageToChatWindow(string message) // Thêm tin vào khung chat
        {
            textDisplayMessage.Text = String.Concat(textDisplayMessage.Text, message);
            textDisplayMessage.AppendText(Environment.NewLine);
        }

        bool isAllZero(byte[] buffer)   // Kiểm tra chuỗi 0 toàn bộ
        {
            foreach (byte b in buffer)
                if (b != 0) return false;
            return true;
        }
        void ReceiveMessage()   // Nhận tin
        {
            byte[] buffer = new byte[1024 * 4];
            int bytesRead;
            RSAParameters rsaPa;
            while (true)
            {
                try
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    if (isAllZero(buffer)) continue;
                    if (message.Contains("New client connected from: 127.0.0.1"))
                    {
                        var posSlN = Array.IndexOf(buffer, (byte)10);
                        var data = new byte[2048];  //Khóa có độ dài 2048 byte nên để độ dài mảng là 2048
                        data = buffer[(posSlN + 1)..(buffer.Length - 1)];
                        rsaPa = BytesToRSAParameters(data);
                        if (!keyList.Contains(rsaPa))
                            keyList.Add(rsaPa);
                        Array.Clear(buffer);
                    }
                    else
                    {
                        String plainText = "";
                        foreach (var item in keyList)
                        {
                            try
                            {
                                plainText = RSADecrypt(message, item);
                            }
                            catch { }
                        }
                        AddMessageToChatWindow(plainText);
                    }
                }
                catch
                {
                    MessageBox.Show("Disconnected from Server", "System Notification", MessageBoxButtons.OK);
                    DisconnectFrom();
                    return;
                }
            }
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisconnectFrom();
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void btn_Join_Click(object sender, EventArgs e)
        {
            SetState(false);
            Thread cnt = new Thread(GetConnection);
            cnt.IsBackground = true;
            cnt.Start();
        }
        // Tạo các biến cho quá trình mã hóa
        private RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        private RSAParameters _publicKey;
        private RSAParameters _privateKey;
        public void InitKey()   // Tạo 2 khóa bí mật và công khai
        {
            _privateKey = csp.ExportParameters(false);
            _publicKey = csp.ExportParameters(true);
        }

        public string RSAEncrypt(string plainText, RSAParameters key)   // Mã hóa thông tin
        {
            csp = new RSACryptoServiceProvider();
            csp.ImportParameters(key);
            var buffer = Encoding.UTF8.GetBytes(plainText);
            var cypher = csp.Encrypt(buffer, false);
            return Convert.ToBase64String(cypher);
        }

        public string RSADecrypt(string cipherText, RSAParameters key)  // Giải mã thông tin
        {
            var buffer = Convert.FromBase64String(cipherText);
            csp.ImportParameters(key);
            var plainText = csp.Decrypt(buffer, false);
            return Encoding.UTF8.GetString(plainText);
        }
        // Chuyển từ khóa công khai thành dữ liệu kiểu byte.
        public static byte[] RSAParametersToBytes(RSAParameters parameters)
        {
            List<byte> bytesList = new List<byte>();
            // Modulus
            if (parameters.Modulus != null)
                bytesList.AddRange(parameters.Modulus);
            // Exponent
            if (parameters.Exponent != null)
                bytesList.AddRange(parameters.Exponent);
            // P
            if (parameters.P != null)
                bytesList.AddRange(parameters.P);
            // Q
            if (parameters.Q != null)
                bytesList.AddRange(parameters.Q);
            // DP
            if (parameters.DP != null)
                bytesList.AddRange(parameters.DP);
            // DQ
            if (parameters.DQ != null)
                bytesList.AddRange(parameters.DQ);
            // InverseQ
            if (parameters.InverseQ != null)
                bytesList.AddRange(parameters.InverseQ);
            // D
            if (parameters.D != null)
                bytesList.AddRange(parameters.D);
            return bytesList.ToArray();
        }
        // Chuyển từ dữ liệu kiểu byte nhận được thành khóa công khai.
        public static RSAParameters BytesToRSAParameters(byte[] bytes)
        {
            RSAParameters parameters = new RSAParameters();
            // Modulus
            int start = 0, length = 256;
            parameters.Modulus = new byte[256];
            Array.Copy(bytes, start, parameters.Modulus, 0, length);
            // Exponent
            start += length;
            length = 3;
            parameters.Exponent = new byte[length];
            Array.Copy(bytes, start, parameters.Exponent, 0, length);
            // P
            start += length;
            length = 128;
            parameters.P = new byte[length];
            Array.Copy(bytes, start, parameters.P, 0, length);
            // Q
            start += length;
            length = 128;
            parameters.Q = new byte[length];
            Array.Copy(bytes, start, parameters.Q, 0, length);
            // DP
            start += length;
            length = 128;
            parameters.DP = new byte[length];
            Array.Copy(bytes, start, parameters.DP, 0, length);
            // DQ
            start += length;
            length = 128;
            parameters.DQ = new byte[length];
            Array.Copy(bytes, start, parameters.DQ, 0, length);
            // InverseQ
            start += length;
            length = 128;
            parameters.InverseQ = new byte[length];
            Array.Copy(bytes, start, parameters.InverseQ, 0, length);
            // D
            start += length;
            length = 256;
            parameters.D = new byte[length];
            Array.Copy(bytes, start, parameters.D, 0, length);
            return parameters;
        }
    }
}

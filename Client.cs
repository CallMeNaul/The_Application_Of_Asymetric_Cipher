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
            
            //RSAParametersToBytes(_publicKey).ToString();
        }
        //public String RandomString(Random random, int length)
        //{
        //    const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
        //    return new string(Enumerable.Repeat(chars, length)
        //      .Select(s => s[random.Next(s.Length)]).ToArray());
        //}
        String publicKey = String.Empty, privateKey = String.Empty;
        TcpClient client;
        List<RSAParameters> keyList = new List<RSAParameters>();
        NetworkStream stream;
        byte[] buffer = new byte[1024 * 4];
        void SetState(bool value)
        {
            if (value)
            {
                panel_Login.Dock = DockStyle.Fill;
                this.Height = 195;
                this.Width = 340;
                panel_Chat.Visible = false;
            }
            else
            {
                panel_Login.Visible = false;
                panel_Chat.Visible = true;
                this.Height = 497;
                this.Width = 818;
                panel_Chat.Dock = DockStyle.Fill;
                grb_Chat.Text = "Name: " + textName.Text;
            }
        }
        void GetConnection()
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
                //MessageBox.Show("Disconnected from Server", "System Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                client.Close();
            }
        }

        void DisconnectFrom()
        {
            if (client != null)
                client.Close();
            if (stream != null)
                stream.Close();
            keyList.Clear();
        }

        void SendMessage()
        {
            //if (!client.Connected)
            {
                //MessageBox.Show("Disconnected from Server", "System Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close();
                //return;
            }
            string message = textName.Text + ": " + textMessage.Text;
            byte[] buffer = Encoding.UTF8.GetBytes(RSAEncrypt(message, _privateKey));
            stream.Write(buffer, 0, buffer.Length);
            textDisplayMessage.Text = String.Concat(textDisplayMessage.Text, message);
            textDisplayMessage.AppendText(Environment.NewLine);
            textMessage.Text = String.Empty;
        }

        void AddMessageToChatWindow(string message)
        {
            textDisplayMessage.Text = String.Concat(textDisplayMessage.Text, message);
            textDisplayMessage.AppendText(Environment.NewLine);
        }

        bool isAllZero(byte[] buffer)
        {
            foreach (byte b in buffer)
            {
                if (b != 0) return false;
            }
            return true;
        }
        void ReceiveMessage()
        {
            byte[] buffer = new byte[1024 * 4];
            int bytesRead;
            RSAParameters rsaPa;
            while (true)
            {
                try
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    //if (bytesRead == 0) break;
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    if (isAllZero(buffer)) continue;
                    if (message.Contains("New client connected from: 127.0.0.1"))
                    {
                        var posSlN = Array.IndexOf(buffer, (byte)10);
                        var data = new byte[2048];
                        data = buffer[(posSlN + 1)..(buffer.Length - 1)];
                        rsaPa = BytesToRSAParameters(data);
                        if (!keyList.Contains(rsaPa))
                            keyList.Add(rsaPa);
                        //MessageBox.Show(GetRSAPublicKey(rsaPa));
                        Array.Clear(buffer);
                    }
                    else
                    {
                        String ss = "";
                        foreach (var item in keyList)
                        {
                            try
                            {
                                ss = RSADecrypt(message, item);
                            }
                            catch { }
                        }
                        AddMessageToChatWindow(ss);
                    }

                }
                catch
                {
                    //MessageBox.Show("Disconnected from Server", "System Notification", MessageBoxButtons.OK);
                    //DisconnectFrom();
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

        private RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        private RSAParameters _publicKey;
        private RSAParameters _privateKey;
        public void InitKey()
        {
            _privateKey = csp.ExportParameters(false);
            _publicKey = csp.ExportParameters(true);
        }
        public string GetRSAPublicKey(RSAParameters key)
        {
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, key);
            return sw.ToString();
        }

        public string RSAEncrypt(string plainText, RSAParameters key)
        {
            csp = new RSACryptoServiceProvider();
            csp.ImportParameters(key);
            var buffer = Encoding.UTF8.GetBytes(plainText);
            var cypher = csp.Encrypt(buffer, false);
            return Convert.ToBase64String(cypher);
        }

        public string RSADecrypt(string cipherText, RSAParameters key)
        {
            var buffer = Convert.FromBase64String(cipherText);
            csp.ImportParameters(key);
            var plainText = csp.Decrypt(buffer, false);
            return Encoding.UTF8.GetString(plainText);
        }
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
        public static RSAParameters BytesToRSAParameters(byte[] bytes)
        {
            RSAParameters parameters = new RSAParameters();

            // Modulus
            int start = 0;
            int length = 256;//BitConverter.ToInt32(bytes, start);
            parameters.Modulus = new byte[256];
            Array.Copy(bytes, start, parameters.Modulus, 0, length);

            // Exponent
            start += length;
            length = 3;// BitConverter.ToInt32(bytes, start);
            parameters.Exponent = new byte[length];
            Array.Copy(bytes, start, parameters.Exponent, 0, length);

            // P
            start += length;
            length = 128;// BitConverter.ToInt32(bytes, start);
            parameters.P = new byte[length];
            Array.Copy(bytes, start, parameters.P, 0, length);

            // Q
            start += length;
            length = 128;// BitConverter.ToInt32(bytes, start);
            parameters.Q = new byte[length];
            Array.Copy(bytes, start, parameters.Q, 0, length);

            // DP
            start += length;
            length = 128;//BitConverter.ToInt32(bytes, start);
            parameters.DP = new byte[length];
            Array.Copy(bytes, start, parameters.DP, 0, length);

            // DQ
            start += length;
            length = 128;// BitConverter.ToInt32(bytes, start);
            parameters.DQ = new byte[length];
            Array.Copy(bytes, start, parameters.DQ, 0, length);

            // InverseQ
            start += length;
            length = 128;// BitConverter.ToInt32(bytes, start);
            parameters.InverseQ = new byte[length];
            Array.Copy(bytes, start, parameters.InverseQ, 0, length);

            // D
            start += length;
            length = 256;// BitConverter.ToInt32(bytes, start);
            parameters.D = new byte[length];
            Array.Copy(bytes, start, parameters.D, 0, length);

            return parameters;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1="";
            foreach (var item in keyList)
            {
                publicKey = GetRSAPublicKey(item);
                s1 += publicKey;
            }
            MessageBox.Show(s1);
            MessageBox.Show(GetRSAPublicKey(_publicKey));
        }
    }
}

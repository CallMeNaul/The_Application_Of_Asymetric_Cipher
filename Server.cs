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
            btn_Listen.Enabled = false;
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
            public KeyTCPClient(TcpClient tCli, RSAParameters key)
            {
                this.tcpClient = tCli;
                this.publicKey = key;
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
                client = server.AcceptTcpClient();
                KeyTCPClient keyTcpCli = new KeyTCPClient(client, rsaPa);
                clients.Add(keyTcpCli);
                Task.Run(() => HandleClientMessages(client));
            }
        }
        void HandleClientMessages(TcpClient client) // Nhận dữ liệu từ Client.
        {
            byte[] buffer = new byte[1024 * 4];
            int bytesRead;
            while (true)
            {
                stream = client.GetStream();
                try
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    var mes = message.Split('\n');
        // Nếu dữ liệu gửi tới là khóa công khai, tiến hành lưu trữ và broadcast cho các Client còn lại.
                    if (message.Contains("New client connected from: 127.0.0.1"))
                    {
                        var posSlN = Array.IndexOf(buffer, (byte)10);
                        var data = new byte[2048];
                        data = buffer[(posSlN + 1)..(buffer.Length - 1)];
                        rsaPa = BytesToRSAParameters(data);
                        foreach (var cli in clients)
                        {
                            if (client == cli.tcpClient)
                            {
                                cli.publicKey = rsaPa;
                            }
                        }
                        this.Invoke((MethodInvoker)delegate
                        {
                            textNote.AppendText(mes[0] + Environment.NewLine);
                        });
                        string keys = "New client connected from: 127.0.0.1\n";
                        for (int i = 0; i < clients.Count - 1; i++)
                        {
        //Gửi khóa công khai của những Client còn lại cho chính nó.
                            byte[] flag = Encoding.UTF8.GetBytes(keys);
                            flag.CopyTo(buffer, 0);
                            var kEY = RSAParametersToBytes(clients[i].publicKey);
                            kEY.CopyTo(buffer, flag.Length);
                            stream.Write(buffer, 0, buffer.Length);
        //Gửi khóa công khai của chính nó cho những Client còn lại.
                            flag.CopyTo(buffer, 0);
                            kEY = RSAParametersToBytes(rsaPa);
                            kEY.CopyTo(buffer, flag.Length);
                            NetworkStream netStream = clients[i].tcpClient.GetStream();
                            netStream.Write(buffer, 0, buffer.Length);
                        }
                    }
                    else   // Nếu dữ liệu được gửi đến là tin nhắn, tiến hành broadcast
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            textMessage.AppendText(mes[0] + Environment.NewLine);
                        });
                        BroadcastMessage(message, client);
                    }
                }
                catch
                {
                    KeyTCPClient cli = new KeyTCPClient(client, rsaPa);
                    clients.Remove(cli);
                    break;
                }
            }
        }

        void BroadcastMessage(string message, TcpClient sender) // Broadcast tin nhắn
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            foreach (KeyTCPClient receiver in clients)
            {
                if (receiver.tcpClient != sender)
                {
                    NetworkStream netStream = receiver.tcpClient.GetStream();
                    netStream.Write(buffer, 0, buffer.Length);
                }
            }
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            clients.Clear();
            server.Stop();
        }

        private void btn_Listen_Click(object sender, EventArgs e)
        {
            if (!btn_Stop.Enabled)
                btn_Stop.Enabled = true;
            btn_Listen.Enabled = false;
            StartToListen();
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            if (!btn_Listen.Enabled)
                btn_Listen.Enabled = true;
            btn_Stop.Enabled = false;
            clients.Clear();
            server.Stop();
        }
        // Chuyển từ khóa công khai thành dữ liệu kiểu byte.
        public static byte[] RSAParametersToBytes(RSAParameters parameters)
        {
            List<byte> bytesList = new List<byte>();
            // Modulus: Tích P và Q
            if (parameters.Modulus != null)
                bytesList.AddRange(parameters.Modulus);
            // Exponent: e
            if (parameters.Exponent != null)
                bytesList.AddRange(parameters.Exponent);
            // P: Số nguyên tố
            if (parameters.P != null)
                bytesList.AddRange(parameters.P);
            // Q: Số nguyên tố khác P
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

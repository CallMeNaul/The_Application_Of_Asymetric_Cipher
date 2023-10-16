using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Application_Of_Asymetric_Cipher
{
    public partial class Client : Form
    {
        public Client(int num)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            SetState(true);
            this.Text = "Client " + num.ToString();
        }

        TcpClient client = null;
        NetworkStream stream;
        byte[] buffer = new byte[1024];

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
        void Connect()
        {
            try
            {
                client = new TcpClient("127.0.0.1", 8080);
                string message = "New client connected from: 127.0.0.1 " + textName.Text + "\n";
                stream = client.GetStream();
                Thread rec = new Thread(Receive);
                rec.IsBackground = true;
                rec.Start();
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                stream.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Disconnected from Server", "System Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                client.Close();
            }
        }

        void Disconnect()
        {
            if (client != null)
                client.Close();
            if (stream != null)
                stream.Close();
        }

        void Send()
        {
            if (!client.Connected)
            {
                MessageBox.Show("Disconnected from Server", "System Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            string message = textName.Text + ": " + textMessage.Text;
            byte[] buffer = Encoding.UTF8.GetBytes(message);
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

        void Receive()
        {
            byte[] buffer = new byte[1024];
            int bytesRead;
            while (true)
            {
                try
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    AddMessageToChatWindow(message);
                }
                catch
                {
                    MessageBox.Show("Disconnected from Server", "System Notification", MessageBoxButtons.OK);
                    Disconnect();
                    return;
                }
            }
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Disconnect();
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            Send();
        }

        private void btn_Join_Click(object sender, EventArgs e)
        {
            SetState(false);
            Thread cnt = new Thread(Connect);
            cnt.IsBackground = true;
            cnt.Start();
        }
    }
}

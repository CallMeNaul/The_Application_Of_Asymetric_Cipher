using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Application_Of_Asymetric_Cipher
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            btn_Listen.Enabled = false;
            textNote.ReadOnly = true;
            textMessage.ReadOnly = true;
            this.Size = new Size(818, 687);
            panel_Server.Dock = DockStyle.Fill;
            Listen();
        }

        TcpListener server = null;
        TcpClient client;
        List<TcpClient> clients = new List<TcpClient>();
        NetworkStream stream;

        void Listen()
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
        void AcceptClients()
        {
            while (true)
            {
                client = server.AcceptTcpClient();
                clients.Add(client);
                Task.Run(() => HandleClientMessages(client));
            }
        }
        void HandleClientMessages(TcpClient client)
        {

            byte[] buffer = new byte[1024];
            int bytesRead;

            while (true)
            {
                stream = client.GetStream();
                try
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    if (message.Contains("New client connected from: 127.0.0.1"))
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            textNote.AppendText(message + Environment.NewLine);
                        });
                    }
                    else
                    {
                        BroadcastMessage(message, client);
                        this.Invoke((MethodInvoker)delegate
                        {
                            textMessage.AppendText(message + Environment.NewLine);
                        });
                    }
                }
                catch
                {
                    clients.Remove(client);
                    break;
                }
            }
        }

        void BroadcastMessage(string message, TcpClient sender)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            foreach (TcpClient receiver in clients)
            {
                if (receiver != sender)
                {
                    NetworkStream netStream = receiver.GetStream();
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
            Listen();
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            if (!btn_Listen.Enabled)
                btn_Listen.Enabled = true;
            btn_Stop.Enabled = false;
            clients.Clear();
            server.Stop();
        }
    }
}

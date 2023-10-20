namespace The_Application_Of_Asymetric_Cipher
{
    partial class Client_Advanced
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textDisplayMessage = new TextBox();
            textMessage = new TextBox();
            textName = new TextBox();
            btSend = new Button();
            grb_Login = new GroupBox();
            label3 = new Label();
            btn_Join = new Button();
            panel_Login = new Panel();
            panel_Top_Login = new Panel();
            panel_btn_Join = new Panel();
            panel_Chat = new Panel();
            grb_Chat = new GroupBox();
            grb_Message = new GroupBox();
            panel_ChatBar = new Panel();
            grb_Login.SuspendLayout();
            panel_Login.SuspendLayout();
            panel_Top_Login.SuspendLayout();
            panel_btn_Join.SuspendLayout();
            panel_Chat.SuspendLayout();
            grb_Chat.SuspendLayout();
            grb_Message.SuspendLayout();
            panel_ChatBar.SuspendLayout();
            SuspendLayout();
            // 
            // textDisplayMessage
            // 
            textDisplayMessage.Dock = DockStyle.Fill;
            textDisplayMessage.Font = new Font("Monotype Corsiva", 13.8F, FontStyle.Italic, GraphicsUnit.Point);
            textDisplayMessage.Location = new Point(4, 30);
            textDisplayMessage.Margin = new Padding(4);
            textDisplayMessage.Multiline = true;
            textDisplayMessage.Name = "textDisplayMessage";
            textDisplayMessage.ScrollBars = ScrollBars.Vertical;
            textDisplayMessage.Size = new Size(984, 431);
            textDisplayMessage.TabIndex = 9;
            // 
            // textMessage
            // 
            textMessage.Dock = DockStyle.Fill;
            textMessage.Font = new Font("Monotype Corsiva", 13.8F, FontStyle.Italic, GraphicsUnit.Point);
            textMessage.Location = new Point(0, 0);
            textMessage.Margin = new Padding(4);
            textMessage.Multiline = true;
            textMessage.Name = "textMessage";
            textMessage.PlaceholderText = "Type text";
            textMessage.Size = new Size(852, 32);
            textMessage.TabIndex = 8;
            // 
            // textName
            // 
            textName.Dock = DockStyle.Fill;
            textName.Font = new Font("Monotype Corsiva", 12F, FontStyle.Italic, GraphicsUnit.Point);
            textName.Location = new Point(4, 57);
            textName.Margin = new Padding(4);
            textName.Name = "textName";
            textName.Size = new Size(392, 30);
            textName.TabIndex = 7;
            // 
            // btSend
            // 
            btSend.Dock = DockStyle.Right;
            btSend.Font = new Font("Monotype Corsiva", 13.8F, FontStyle.Italic, GraphicsUnit.Point);
            btSend.ForeColor = Color.Black;
            btSend.Location = new Point(852, 0);
            btSend.Margin = new Padding(4);
            btSend.Name = "btSend";
            btSend.Size = new Size(140, 32);
            btSend.TabIndex = 6;
            btSend.Text = "Send";
            btSend.UseVisualStyleBackColor = true;
            btSend.Click += btSend_Click;
            // 
            // grb_Login
            // 
            grb_Login.Controls.Add(textName);
            grb_Login.Controls.Add(label3);
            grb_Login.Dock = DockStyle.Top;
            grb_Login.Font = new Font("Monotype Corsiva", 13.8F, FontStyle.Italic, GraphicsUnit.Point);
            grb_Login.ForeColor = Color.Cyan;
            grb_Login.Location = new Point(0, 0);
            grb_Login.Margin = new Padding(4);
            grb_Login.Name = "grb_Login";
            grb_Login.Padding = new Padding(4);
            grb_Login.Size = new Size(400, 101);
            grb_Login.TabIndex = 12;
            grb_Login.TabStop = false;
            grb_Login.Text = "Chat in LAN";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Monotype Corsiva", 13.8F, FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = Color.Cyan;
            label3.Location = new Point(4, 30);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(165, 27);
            label3.TabIndex = 8;
            label3.Text = "Insert Your Name:";
            // 
            // btn_Join
            // 
            btn_Join.Dock = DockStyle.Right;
            btn_Join.Font = new Font("Monotype Corsiva", 13.8F, FontStyle.Italic, GraphicsUnit.Point);
            btn_Join.ForeColor = Color.Black;
            btn_Join.Location = new Point(282, 0);
            btn_Join.Margin = new Padding(4);
            btn_Join.Name = "btn_Join";
            btn_Join.Size = new Size(118, 39);
            btn_Join.TabIndex = 9;
            btn_Join.Text = "Login";
            btn_Join.UseVisualStyleBackColor = true;
            btn_Join.Click += btn_Join_Click;
            // 
            // panel_Login
            // 
            panel_Login.Controls.Add(panel_Top_Login);
            panel_Login.Font = new Font("Monotype Corsiva", 12F, FontStyle.Italic, GraphicsUnit.Point);
            panel_Login.Location = new Point(31, 35);
            panel_Login.Margin = new Padding(4);
            panel_Login.Name = "panel_Login";
            panel_Login.Size = new Size(400, 148);
            panel_Login.TabIndex = 15;
            // 
            // panel_Top_Login
            // 
            panel_Top_Login.Controls.Add(panel_btn_Join);
            panel_Top_Login.Controls.Add(grb_Login);
            panel_Top_Login.Dock = DockStyle.Top;
            panel_Top_Login.Location = new Point(0, 0);
            panel_Top_Login.Margin = new Padding(4);
            panel_Top_Login.Name = "panel_Top_Login";
            panel_Top_Login.Size = new Size(400, 146);
            panel_Top_Login.TabIndex = 0;
            // 
            // panel_btn_Join
            // 
            panel_btn_Join.Controls.Add(btn_Join);
            panel_btn_Join.Dock = DockStyle.Bottom;
            panel_btn_Join.Location = new Point(0, 107);
            panel_btn_Join.Margin = new Padding(4);
            panel_btn_Join.Name = "panel_btn_Join";
            panel_btn_Join.Size = new Size(400, 39);
            panel_btn_Join.TabIndex = 16;
            // 
            // panel_Chat
            // 
            panel_Chat.Controls.Add(grb_Chat);
            panel_Chat.Font = new Font("Monotype Corsiva", 12F, FontStyle.Italic, GraphicsUnit.Point);
            panel_Chat.Location = new Point(40, 211);
            panel_Chat.Margin = new Padding(4);
            panel_Chat.Name = "panel_Chat";
            panel_Chat.Size = new Size(1000, 536);
            panel_Chat.TabIndex = 16;
            // 
            // grb_Chat
            // 
            grb_Chat.Controls.Add(grb_Message);
            grb_Chat.Controls.Add(panel_ChatBar);
            grb_Chat.Dock = DockStyle.Fill;
            grb_Chat.Font = new Font("Monotype Corsiva", 16.2F, FontStyle.Italic, GraphicsUnit.Point);
            grb_Chat.ForeColor = Color.Cyan;
            grb_Chat.Location = new Point(0, 0);
            grb_Chat.Margin = new Padding(4);
            grb_Chat.Name = "grb_Chat";
            grb_Chat.Padding = new Padding(4);
            grb_Chat.Size = new Size(1000, 536);
            grb_Chat.TabIndex = 0;
            grb_Chat.TabStop = false;
            // 
            // grb_Message
            // 
            grb_Message.Controls.Add(textDisplayMessage);
            grb_Message.Dock = DockStyle.Fill;
            grb_Message.Font = new Font("Monotype Corsiva", 13.8F, FontStyle.Italic, GraphicsUnit.Point);
            grb_Message.ForeColor = Color.Cyan;
            grb_Message.Location = new Point(4, 35);
            grb_Message.Margin = new Padding(4);
            grb_Message.Name = "grb_Message";
            grb_Message.Padding = new Padding(4);
            grb_Message.Size = new Size(992, 465);
            grb_Message.TabIndex = 10;
            grb_Message.TabStop = false;
            grb_Message.Text = "Message";
            // 
            // panel_ChatBar
            // 
            panel_ChatBar.Controls.Add(textMessage);
            panel_ChatBar.Controls.Add(btSend);
            panel_ChatBar.Dock = DockStyle.Bottom;
            panel_ChatBar.Location = new Point(4, 500);
            panel_ChatBar.Margin = new Padding(4);
            panel_ChatBar.Name = "panel_ChatBar";
            panel_ChatBar.Size = new Size(992, 32);
            panel_ChatBar.TabIndex = 16;
            // 
            // Client_Advanced
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(1081, 748);
            Controls.Add(panel_Login);
            Controls.Add(panel_Chat);
            Name = "Client_Advanced";
            Text = "Client_Advanced";
            FormClosed += Client_Advanced_FormClosed;
            grb_Login.ResumeLayout(false);
            grb_Login.PerformLayout();
            panel_Login.ResumeLayout(false);
            panel_Top_Login.ResumeLayout(false);
            panel_btn_Join.ResumeLayout(false);
            panel_Chat.ResumeLayout(false);
            grb_Chat.ResumeLayout(false);
            grb_Message.ResumeLayout(false);
            grb_Message.PerformLayout();
            panel_ChatBar.ResumeLayout(false);
            panel_ChatBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textDisplayMessage;
        private TextBox textMessage;
        private TextBox textName;
        private Button btSend;
        private GroupBox grb_Login;
        private Label label3;
        private Button btn_Join;
        private Panel panel_Login;
        private Panel panel_Top_Login;
        private Panel panel_btn_Join;
        private Panel panel_Chat;
        private GroupBox grb_Chat;
        private GroupBox grb_Message;
        private Panel panel_ChatBar;
    }
}
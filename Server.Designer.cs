namespace The_Application_Of_Asymetric_Cipher
{
    partial class Server
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
            btn_Listen = new Button();
            textMessage = new TextBox();
            grb_Message = new GroupBox();
            button1 = new Button();
            panel_Top = new Panel();
            panel_Monitor = new Panel();
            panel_Notification = new Panel();
            grb_Notification = new GroupBox();
            textNote = new TextBox();
            panel_Button = new Panel();
            btn_Stop = new Button();
            panel_Server = new Panel();
            grb_Message.SuspendLayout();
            panel_Top.SuspendLayout();
            panel_Monitor.SuspendLayout();
            panel_Notification.SuspendLayout();
            grb_Notification.SuspendLayout();
            panel_Button.SuspendLayout();
            panel_Server.SuspendLayout();
            SuspendLayout();
            // 
            // btn_Listen
            // 
            btn_Listen.Font = new Font("Monotype Corsiva", 12F, FontStyle.Italic, GraphicsUnit.Point);
            btn_Listen.ForeColor = Color.Black;
            btn_Listen.Location = new Point(14, 31);
            btn_Listen.Name = "btn_Listen";
            btn_Listen.Size = new Size(173, 39);
            btn_Listen.TabIndex = 3;
            btn_Listen.Text = "Listen";
            btn_Listen.UseVisualStyleBackColor = true;
            btn_Listen.Click += btn_Listen_Click;
            // 
            // textMessage
            // 
            textMessage.Dock = DockStyle.Fill;
            textMessage.Location = new Point(0, 0);
            textMessage.Multiline = true;
            textMessage.Name = "textMessage";
            textMessage.ScrollBars = ScrollBars.Vertical;
            textMessage.Size = new Size(794, 453);
            textMessage.TabIndex = 2;
            // 
            // grb_Message
            // 
            grb_Message.Controls.Add(button1);
            grb_Message.Controls.Add(panel_Top);
            grb_Message.Controls.Add(panel_Monitor);
            grb_Message.Dock = DockStyle.Fill;
            grb_Message.Font = new Font("Monotype Corsiva", 12F, FontStyle.Italic, GraphicsUnit.Point);
            grb_Message.ForeColor = Color.Cyan;
            grb_Message.Location = new Point(0, 0);
            grb_Message.Name = "grb_Message";
            grb_Message.Size = new Size(800, 637);
            grb_Message.TabIndex = 4;
            grb_Message.TabStop = false;
            grb_Message.Text = "Message";
            // 
            // button1
            // 
            button1.Location = new Point(467, 3);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 7;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel_Top
            // 
            panel_Top.Controls.Add(textMessage);
            panel_Top.Dock = DockStyle.Fill;
            panel_Top.Location = new Point(3, 26);
            panel_Top.Name = "panel_Top";
            panel_Top.Size = new Size(794, 453);
            panel_Top.TabIndex = 6;
            // 
            // panel_Monitor
            // 
            panel_Monitor.Controls.Add(panel_Notification);
            panel_Monitor.Controls.Add(panel_Button);
            panel_Monitor.Dock = DockStyle.Bottom;
            panel_Monitor.Location = new Point(3, 479);
            panel_Monitor.Name = "panel_Monitor";
            panel_Monitor.Size = new Size(794, 155);
            panel_Monitor.TabIndex = 5;
            // 
            // panel_Notification
            // 
            panel_Notification.Controls.Add(grb_Notification);
            panel_Notification.Dock = DockStyle.Fill;
            panel_Notification.Location = new Point(0, 0);
            panel_Notification.Name = "panel_Notification";
            panel_Notification.Size = new Size(592, 155);
            panel_Notification.TabIndex = 1;
            // 
            // grb_Notification
            // 
            grb_Notification.Controls.Add(textNote);
            grb_Notification.Dock = DockStyle.Fill;
            grb_Notification.Font = new Font("Monotype Corsiva", 12F, FontStyle.Italic, GraphicsUnit.Point);
            grb_Notification.ForeColor = Color.Cyan;
            grb_Notification.Location = new Point(0, 0);
            grb_Notification.Name = "grb_Notification";
            grb_Notification.Size = new Size(592, 155);
            grb_Notification.TabIndex = 5;
            grb_Notification.TabStop = false;
            grb_Notification.Text = "Notification";
            // 
            // textNote
            // 
            textNote.Dock = DockStyle.Fill;
            textNote.Location = new Point(3, 26);
            textNote.Multiline = true;
            textNote.Name = "textNote";
            textNote.ScrollBars = ScrollBars.Vertical;
            textNote.Size = new Size(586, 126);
            textNote.TabIndex = 0;
            // 
            // panel_Button
            // 
            panel_Button.Controls.Add(btn_Listen);
            panel_Button.Controls.Add(btn_Stop);
            panel_Button.Dock = DockStyle.Right;
            panel_Button.Location = new Point(592, 0);
            panel_Button.Name = "panel_Button";
            panel_Button.Size = new Size(202, 155);
            panel_Button.TabIndex = 0;
            // 
            // btn_Stop
            // 
            btn_Stop.Font = new Font("Monotype Corsiva", 12F, FontStyle.Italic, GraphicsUnit.Point);
            btn_Stop.ForeColor = Color.Black;
            btn_Stop.Location = new Point(14, 86);
            btn_Stop.Name = "btn_Stop";
            btn_Stop.Size = new Size(173, 39);
            btn_Stop.TabIndex = 6;
            btn_Stop.Text = "Stop";
            btn_Stop.UseVisualStyleBackColor = true;
            btn_Stop.Click += btn_Stop_Click;
            // 
            // panel_Server
            // 
            panel_Server.BackColor = Color.MidnightBlue;
            panel_Server.Controls.Add(grb_Message);
            panel_Server.Location = new Point(0, 0);
            panel_Server.Name = "panel_Server";
            panel_Server.Size = new Size(800, 637);
            panel_Server.TabIndex = 7;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 640);
            Controls.Add(panel_Server);
            Name = "Server";
            Text = "Server";
            FormClosed += Server_FormClosed;
            grb_Message.ResumeLayout(false);
            panel_Top.ResumeLayout(false);
            panel_Top.PerformLayout();
            panel_Monitor.ResumeLayout(false);
            panel_Notification.ResumeLayout(false);
            grb_Notification.ResumeLayout(false);
            grb_Notification.PerformLayout();
            panel_Button.ResumeLayout(false);
            panel_Server.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Listen;
        private TextBox textMessage;
        private GroupBox grb_Message;
        private GroupBox grb_Notification;
        private TextBox textNote;
        private Button btn_Stop;
        private Panel panel_Server;
        private Panel panel_Monitor;
        private Panel panel_Notification;
        private Panel panel_Button;
        private Panel panel_Top;
        private Button button1;
    }
}
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
            textMessage = new TextBox();
            grb_Message = new GroupBox();
            panel_Top = new Panel();
            panel_Monitor = new Panel();
            panel_Notification = new Panel();
            grb_Notification = new GroupBox();
            textNote = new TextBox();
            panel_Server = new Panel();
            grb_Message.SuspendLayout();
            panel_Top.SuspendLayout();
            panel_Monitor.SuspendLayout();
            panel_Notification.SuspendLayout();
            grb_Notification.SuspendLayout();
            panel_Server.SuspendLayout();
            SuspendLayout();
            // 
            // textMessage
            // 
            textMessage.Dock = DockStyle.Fill;
            textMessage.Location = new Point(0, 0);
            textMessage.Multiline = true;
            textMessage.Name = "textMessage";
            textMessage.ScrollBars = ScrollBars.Vertical;
            textMessage.Size = new Size(794, 450);
            textMessage.TabIndex = 2;
            // 
            // grb_Message
            // 
            grb_Message.Controls.Add(panel_Top);
            grb_Message.Controls.Add(panel_Monitor);
            grb_Message.Dock = DockStyle.Fill;
            grb_Message.Font = new Font("Monotype Corsiva", 13.8F, FontStyle.Italic, GraphicsUnit.Point);
            grb_Message.ForeColor = Color.Cyan;
            grb_Message.Location = new Point(0, 0);
            grb_Message.Name = "grb_Message";
            grb_Message.Size = new Size(800, 637);
            grb_Message.TabIndex = 4;
            grb_Message.TabStop = false;
            grb_Message.Text = "Message";
            // 
            // panel_Top
            // 
            panel_Top.Controls.Add(textMessage);
            panel_Top.Dock = DockStyle.Fill;
            panel_Top.Location = new Point(3, 29);
            panel_Top.Name = "panel_Top";
            panel_Top.Size = new Size(794, 450);
            panel_Top.TabIndex = 6;
            // 
            // panel_Monitor
            // 
            panel_Monitor.Controls.Add(panel_Notification);
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
            panel_Notification.Size = new Size(794, 155);
            panel_Notification.TabIndex = 1;
            // 
            // grb_Notification
            // 
            grb_Notification.Controls.Add(textNote);
            grb_Notification.Dock = DockStyle.Fill;
            grb_Notification.Font = new Font("Monotype Corsiva", 13.8F, FontStyle.Italic, GraphicsUnit.Point);
            grb_Notification.ForeColor = Color.Cyan;
            grb_Notification.Location = new Point(0, 0);
            grb_Notification.Name = "grb_Notification";
            grb_Notification.Size = new Size(794, 155);
            grb_Notification.TabIndex = 5;
            grb_Notification.TabStop = false;
            grb_Notification.Text = "Notification";
            // 
            // textNote
            // 
            textNote.Dock = DockStyle.Fill;
            textNote.Location = new Point(3, 29);
            textNote.Multiline = true;
            textNote.Name = "textNote";
            textNote.ScrollBars = ScrollBars.Vertical;
            textNote.Size = new Size(788, 123);
            textNote.TabIndex = 0;
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
            panel_Server.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TextBox textMessage;
        private GroupBox grb_Message;
        private GroupBox grb_Notification;
        private TextBox textNote;
        private Panel panel_Server;
        private Panel panel_Monitor;
        private Panel panel_Notification;
        private Panel panel_Top;
    }
}
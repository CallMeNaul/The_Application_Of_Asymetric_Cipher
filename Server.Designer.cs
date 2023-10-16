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
            btListen = new Button();
            textMessage = new TextBox();
            SuspendLayout();
            // 
            // btListen
            // 
            btListen.Location = new Point(55, 65);
            btListen.Name = "btListen";
            btListen.Size = new Size(173, 73);
            btListen.TabIndex = 3;
            btListen.Text = "Listen";
            btListen.UseVisualStyleBackColor = true;
            // 
            // textMessage
            // 
            textMessage.Location = new Point(287, 59);
            textMessage.Multiline = true;
            textMessage.Name = "textMessage";
            textMessage.Size = new Size(459, 333);
            textMessage.TabIndex = 2;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btListen);
            Controls.Add(textMessage);
            Name = "Server";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btListen;
        private TextBox textMessage;
    }
}
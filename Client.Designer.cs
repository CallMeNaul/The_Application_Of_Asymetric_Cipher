namespace The_Application_Of_Asymetric_Cipher
{
    partial class Client
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
            btConnect = new Button();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // textDisplayMessage
            // 
            textDisplayMessage.Location = new Point(67, 27);
            textDisplayMessage.Multiline = true;
            textDisplayMessage.Name = "textDisplayMessage";
            textDisplayMessage.Size = new Size(666, 221);
            textDisplayMessage.TabIndex = 9;
            // 
            // textMessage
            // 
            textMessage.Location = new Point(67, 362);
            textMessage.Name = "textMessage";
            textMessage.Size = new Size(416, 27);
            textMessage.TabIndex = 8;
            // 
            // textName
            // 
            textName.Location = new Point(67, 293);
            textName.Name = "textName";
            textName.Size = new Size(320, 27);
            textName.TabIndex = 7;
            // 
            // btSend
            // 
            btSend.Location = new Point(514, 362);
            btSend.Name = "btSend";
            btSend.Size = new Size(193, 62);
            btSend.TabIndex = 6;
            btSend.Text = "Send";
            btSend.UseVisualStyleBackColor = true;
            // 
            // btConnect
            // 
            btConnect.Location = new Point(518, 290);
            btConnect.Name = "btConnect";
            btConnect.Size = new Size(185, 53);
            btConnect.TabIndex = 5;
            btConnect.Text = "Connect";
            btConnect.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 330);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 11;
            label2.Text = "Message";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 261);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 10;
            label1.Text = "Name";
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textDisplayMessage);
            Controls.Add(textMessage);
            Controls.Add(textName);
            Controls.Add(btSend);
            Controls.Add(btConnect);
            Name = "Client";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textDisplayMessage;
        private TextBox textMessage;
        private TextBox textName;
        private Button btSend;
        private Button btConnect;
        private Label label2;
        private Label label1;
    }
}
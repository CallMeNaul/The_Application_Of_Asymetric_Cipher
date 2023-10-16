﻿namespace The_Application_Of_Asymetric_Cipher
{
    partial class SecureChat
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_Server = new Button();
            btn_Client = new Button();
            panel_Body = new Panel();
            panel_Bottom_Button = new Panel();
            panel_Right_Pillar = new Panel();
            panel_Left_Pillar = new Panel();
            panel_icon_cli = new Panel();
            panel_icon_sv = new Panel();
            panel_Top_Button = new Panel();
            panel_Column = new Panel();
            panel_All = new Panel();
            panel_Bottom_Button.SuspendLayout();
            panel_Right_Pillar.SuspendLayout();
            panel_Left_Pillar.SuspendLayout();
            panel_Column.SuspendLayout();
            panel_All.SuspendLayout();
            SuspendLayout();
            // 
            // btn_Server
            // 
            btn_Server.BackColor = Color.MidnightBlue;
            btn_Server.Dock = DockStyle.Top;
            btn_Server.FlatAppearance.BorderSize = 0;
            btn_Server.FlatStyle = FlatStyle.Flat;
            btn_Server.Font = new Font("Monotype Corsiva", 19.8000011F, FontStyle.Italic, GraphicsUnit.Point);
            btn_Server.ForeColor = Color.Cyan;
            btn_Server.Location = new Point(0, 0);
            btn_Server.Name = "btn_Server";
            btn_Server.Size = new Size(168, 220);
            btn_Server.TabIndex = 0;
            btn_Server.Text = "Server";
            btn_Server.TextAlign = ContentAlignment.MiddleLeft;
            btn_Server.UseVisualStyleBackColor = false;
            btn_Server.Click += btn_Server_Click;
            // 
            // btn_Client
            // 
            btn_Client.BackColor = Color.MidnightBlue;
            btn_Client.Dock = DockStyle.Top;
            btn_Client.FlatAppearance.BorderSize = 0;
            btn_Client.FlatStyle = FlatStyle.Flat;
            btn_Client.Font = new Font("Monotype Corsiva", 19.8000011F, FontStyle.Italic, GraphicsUnit.Point);
            btn_Client.ForeColor = Color.Cyan;
            btn_Client.Location = new Point(0, 220);
            btn_Client.Name = "btn_Client";
            btn_Client.Size = new Size(168, 220);
            btn_Client.TabIndex = 1;
            btn_Client.Text = "Client";
            btn_Client.TextAlign = ContentAlignment.MiddleLeft;
            btn_Client.UseVisualStyleBackColor = false;
            btn_Client.Click += btn_Client_Click;
            // 
            // panel_Body
            // 
            panel_Body.BackColor = Color.MidnightBlue;
            panel_Body.Dock = DockStyle.Fill;
            panel_Body.Location = new Point(0, 0);
            panel_Body.Name = "panel_Body";
            panel_Body.Size = new Size(758, 544);
            panel_Body.TabIndex = 2;
            // 
            // panel_Bottom_Button
            // 
            panel_Bottom_Button.Controls.Add(panel_Right_Pillar);
            panel_Bottom_Button.Controls.Add(panel_Left_Pillar);
            panel_Bottom_Button.Dock = DockStyle.Fill;
            panel_Bottom_Button.Location = new Point(0, 104);
            panel_Bottom_Button.Name = "panel_Bottom_Button";
            panel_Bottom_Button.Size = new Size(214, 440);
            panel_Bottom_Button.TabIndex = 4;
            // 
            // panel_Right_Pillar
            // 
            panel_Right_Pillar.Controls.Add(btn_Client);
            panel_Right_Pillar.Controls.Add(btn_Server);
            panel_Right_Pillar.Dock = DockStyle.Right;
            panel_Right_Pillar.Location = new Point(46, 0);
            panel_Right_Pillar.Name = "panel_Right_Pillar";
            panel_Right_Pillar.Size = new Size(168, 440);
            panel_Right_Pillar.TabIndex = 2;
            // 
            // panel_Left_Pillar
            // 
            panel_Left_Pillar.Controls.Add(panel_icon_cli);
            panel_Left_Pillar.Controls.Add(panel_icon_sv);
            panel_Left_Pillar.Dock = DockStyle.Left;
            panel_Left_Pillar.Location = new Point(0, 0);
            panel_Left_Pillar.Name = "panel_Left_Pillar";
            panel_Left_Pillar.Size = new Size(46, 440);
            panel_Left_Pillar.TabIndex = 7;
            // 
            // panel_icon_cli
            // 
            panel_icon_cli.BackgroundImage = Properties.Resources.cli_removebg_preview;
            panel_icon_cli.BackgroundImageLayout = ImageLayout.Zoom;
            panel_icon_cli.Dock = DockStyle.Top;
            panel_icon_cli.Location = new Point(0, 220);
            panel_icon_cli.Name = "panel_icon_cli";
            panel_icon_cli.Size = new Size(46, 220);
            panel_icon_cli.TabIndex = 5;
            panel_icon_cli.Click += panel_icon_cli_Click;
            // 
            // panel_icon_sv
            // 
            panel_icon_sv.BackgroundImage = Properties.Resources.sv_removebg_preview;
            panel_icon_sv.BackgroundImageLayout = ImageLayout.Zoom;
            panel_icon_sv.Dock = DockStyle.Top;
            panel_icon_sv.Location = new Point(0, 0);
            panel_icon_sv.Name = "panel_icon_sv";
            panel_icon_sv.Size = new Size(46, 220);
            panel_icon_sv.TabIndex = 6;
            panel_icon_sv.Click += panel_icon_sv_Click;
            // 
            // panel_Top_Button
            // 
            panel_Top_Button.Dock = DockStyle.Top;
            panel_Top_Button.Location = new Point(0, 0);
            panel_Top_Button.Name = "panel_Top_Button";
            panel_Top_Button.Size = new Size(214, 104);
            panel_Top_Button.TabIndex = 3;
            // 
            // panel_Column
            // 
            panel_Column.BackColor = Color.MidnightBlue;
            panel_Column.Controls.Add(panel_Bottom_Button);
            panel_Column.Controls.Add(panel_Top_Button);
            panel_Column.Dock = DockStyle.Right;
            panel_Column.Location = new Point(758, 0);
            panel_Column.Name = "panel_Column";
            panel_Column.Size = new Size(214, 544);
            panel_Column.TabIndex = 3;
            // 
            // panel_All
            // 
            panel_All.Controls.Add(panel_Body);
            panel_All.Controls.Add(panel_Column);
            panel_All.Dock = DockStyle.Fill;
            panel_All.Location = new Point(0, 0);
            panel_All.Name = "panel_All";
            panel_All.Size = new Size(972, 544);
            panel_All.TabIndex = 4;
            // 
            // SecureChat
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(972, 544);
            Controls.Add(panel_All);
            Font = new Font("Monotype Corsiva", 9F, FontStyle.Italic, GraphicsUnit.Point);
            Name = "SecureChat";
            Text = "SecureChat";
            panel_Bottom_Button.ResumeLayout(false);
            panel_Right_Pillar.ResumeLayout(false);
            panel_Left_Pillar.ResumeLayout(false);
            panel_Column.ResumeLayout(false);
            panel_All.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Server;
        private Button btn_Client;
        private Panel panel_Body;
        private Panel panel_Column;
        private Panel panel_Right_Pillar;
        private Panel panel_Top_Button;
        private Panel panel_icon_sv;
        private Panel panel_icon_cli;
        private Panel panel_Left_Pillar;
        private Panel panel_Bottom_Button;
        private Panel panel_All;
    }
}
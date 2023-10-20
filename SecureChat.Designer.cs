namespace The_Application_Of_Asymetric_Cipher
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
            panel_icon_cl_off = new Panel();
            btn_icon_cli = new Button();
            panel_icon_sv = new Panel();
            btn_icon_sv_off = new Button();
            panel_Bottom_Button = new Panel();
            panel_Right_Pillar = new Panel();
            btn_Exit = new Button();
            panel_Left_Pillar = new Panel();
            panel1 = new Panel();
            panel_Top_Button = new Panel();
            label2 = new Label();
            panel_Column = new Panel();
            panel_All = new Panel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel_icon_cl_off.SuspendLayout();
            panel_icon_sv.SuspendLayout();
            panel_Bottom_Button.SuspendLayout();
            panel_Right_Pillar.SuspendLayout();
            panel_Left_Pillar.SuspendLayout();
            panel_Top_Button.SuspendLayout();
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
            btn_Server.Size = new Size(168, 150);
            btn_Server.TabIndex = 0;
            btn_Server.Text = "Server";
            btn_Server.TextAlign = ContentAlignment.MiddleLeft;
            btn_Server.UseVisualStyleBackColor = false;
            btn_Server.Click += btn_Server_Click;
            btn_Server.MouseEnter += btn_Server_MouseEnter;
            btn_Server.MouseLeave += btn_Server_MouseLeave;
            // 
            // btn_Client
            // 
            btn_Client.BackColor = Color.MidnightBlue;
            btn_Client.Dock = DockStyle.Top;
            btn_Client.FlatAppearance.BorderSize = 0;
            btn_Client.FlatStyle = FlatStyle.Flat;
            btn_Client.Font = new Font("Monotype Corsiva", 19.8000011F, FontStyle.Italic, GraphicsUnit.Point);
            btn_Client.ForeColor = Color.Cyan;
            btn_Client.Location = new Point(0, 150);
            btn_Client.Name = "btn_Client";
            btn_Client.Size = new Size(168, 150);
            btn_Client.TabIndex = 1;
            btn_Client.Text = "Client";
            btn_Client.TextAlign = ContentAlignment.MiddleLeft;
            btn_Client.UseVisualStyleBackColor = true;
            btn_Client.Click += btn_Client_Click;
            btn_Client.MouseEnter += btn_Client_MouseEnter;
            btn_Client.MouseLeave += btn_Client_MouseLeave;
            // 
            // panel_Body
            // 
            panel_Body.BackColor = Color.MidnightBlue;
            panel_Body.BackgroundImage = Properties.Resources.NAMECARD_16;
            panel_Body.BackgroundImageLayout = ImageLayout.Stretch;
            panel_Body.Dock = DockStyle.Fill;
            panel_Body.Location = new Point(0, 0);
            panel_Body.Name = "panel_Body";
            panel_Body.Size = new Size(759, 544);
            panel_Body.TabIndex = 2;
            // 
            // panel_icon_cl_off
            // 
            panel_icon_cl_off.BackgroundImage = Properties.Resources.cli_off_removebg_preview;
            panel_icon_cl_off.BackgroundImageLayout = ImageLayout.Zoom;
            panel_icon_cl_off.Controls.Add(btn_icon_cli);
            panel_icon_cl_off.Dock = DockStyle.Top;
            panel_icon_cl_off.Location = new Point(0, 150);
            panel_icon_cl_off.Name = "panel_icon_cl_off";
            panel_icon_cl_off.Size = new Size(46, 150);
            panel_icon_cl_off.TabIndex = 0;
            // 
            // btn_icon_cli
            // 
            btn_icon_cli.BackColor = Color.MidnightBlue;
            btn_icon_cli.BackgroundImage = Properties.Resources.cli_removebg_preview;
            btn_icon_cli.BackgroundImageLayout = ImageLayout.Zoom;
            btn_icon_cli.Dock = DockStyle.Fill;
            btn_icon_cli.Enabled = false;
            btn_icon_cli.FlatStyle = FlatStyle.Flat;
            btn_icon_cli.Location = new Point(0, 0);
            btn_icon_cli.Name = "btn_icon_cli";
            btn_icon_cli.Size = new Size(46, 150);
            btn_icon_cli.TabIndex = 7;
            btn_icon_cli.UseVisualStyleBackColor = false;
            btn_icon_cli.Visible = false;
            btn_icon_cli.Click += btn_Client_Click;
            btn_icon_cli.MouseEnter += btn_Client_MouseEnter;
            btn_icon_cli.MouseLeave += btn_Client_MouseLeave;
            // 
            // panel_icon_sv
            // 
            panel_icon_sv.BackgroundImage = Properties.Resources.sv_removebg_preview;
            panel_icon_sv.BackgroundImageLayout = ImageLayout.Zoom;
            panel_icon_sv.Controls.Add(btn_icon_sv_off);
            panel_icon_sv.Dock = DockStyle.Top;
            panel_icon_sv.Location = new Point(0, 0);
            panel_icon_sv.Name = "panel_icon_sv";
            panel_icon_sv.Size = new Size(46, 150);
            panel_icon_sv.TabIndex = 0;
            panel_icon_sv.Click += btn_Server_Click;
            panel_icon_sv.MouseEnter += btn_Server_MouseEnter;
            panel_icon_sv.MouseLeave += btn_Server_MouseLeave;
            // 
            // btn_icon_sv_off
            // 
            btn_icon_sv_off.BackColor = Color.MidnightBlue;
            btn_icon_sv_off.BackgroundImage = Properties.Resources.sv_off_removebg_preview;
            btn_icon_sv_off.BackgroundImageLayout = ImageLayout.Zoom;
            btn_icon_sv_off.CausesValidation = false;
            btn_icon_sv_off.Dock = DockStyle.Fill;
            btn_icon_sv_off.FlatStyle = FlatStyle.Flat;
            btn_icon_sv_off.Location = new Point(0, 0);
            btn_icon_sv_off.Name = "btn_icon_sv_off";
            btn_icon_sv_off.Size = new Size(46, 150);
            btn_icon_sv_off.TabIndex = 7;
            btn_icon_sv_off.UseVisualStyleBackColor = true;
            // 
            // panel_Bottom_Button
            // 
            panel_Bottom_Button.Controls.Add(panel_Right_Pillar);
            panel_Bottom_Button.Controls.Add(panel_Left_Pillar);
            panel_Bottom_Button.Dock = DockStyle.Fill;
            panel_Bottom_Button.Location = new Point(0, 104);
            panel_Bottom_Button.Name = "panel_Bottom_Button";
            panel_Bottom_Button.Size = new Size(213, 440);
            panel_Bottom_Button.TabIndex = 4;
            // 
            // panel_Right_Pillar
            // 
            panel_Right_Pillar.Controls.Add(btn_Exit);
            panel_Right_Pillar.Controls.Add(btn_Client);
            panel_Right_Pillar.Controls.Add(btn_Server);
            panel_Right_Pillar.Dock = DockStyle.Right;
            panel_Right_Pillar.Location = new Point(45, 0);
            panel_Right_Pillar.Name = "panel_Right_Pillar";
            panel_Right_Pillar.Size = new Size(168, 440);
            panel_Right_Pillar.TabIndex = 2;
            // 
            // btn_Exit
            // 
            btn_Exit.BackColor = Color.MidnightBlue;
            btn_Exit.Dock = DockStyle.Top;
            btn_Exit.FlatAppearance.BorderSize = 0;
            btn_Exit.FlatStyle = FlatStyle.Flat;
            btn_Exit.Font = new Font("Monotype Corsiva", 19.8000011F, FontStyle.Italic, GraphicsUnit.Point);
            btn_Exit.ForeColor = Color.Cyan;
            btn_Exit.Location = new Point(0, 300);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(168, 140);
            btn_Exit.TabIndex = 2;
            btn_Exit.Text = "Exit";
            btn_Exit.TextAlign = ContentAlignment.MiddleLeft;
            btn_Exit.UseVisualStyleBackColor = false;
            btn_Exit.Click += btn_Exit_Click;
            btn_Exit.MouseEnter += btn_Exit_MouseEnter;
            btn_Exit.MouseLeave += panel1_MouseLeave;
            // 
            // panel_Left_Pillar
            // 
            panel_Left_Pillar.Controls.Add(panel1);
            panel_Left_Pillar.Controls.Add(panel_icon_cl_off);
            panel_Left_Pillar.Controls.Add(panel_icon_sv);
            panel_Left_Pillar.Dock = DockStyle.Left;
            panel_Left_Pillar.Location = new Point(0, 0);
            panel_Left_Pillar.Name = "panel_Left_Pillar";
            panel_Left_Pillar.Size = new Size(46, 440);
            panel_Left_Pillar.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.crossx_removebg_preview;
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 300);
            panel1.Name = "panel1";
            panel1.Size = new Size(46, 140);
            panel1.TabIndex = 1;
            panel1.Click += btn_Exit_Click;
            panel1.MouseEnter += btn_Exit_MouseEnter;
            panel1.MouseLeave += panel1_MouseLeave;
            // 
            // panel_Top_Button
            // 
            panel_Top_Button.BackColor = Color.MidnightBlue;
            panel_Top_Button.BackgroundImageLayout = ImageLayout.Stretch;
            panel_Top_Button.Controls.Add(label2);
            panel_Top_Button.Dock = DockStyle.Top;
            panel_Top_Button.Location = new Point(0, 0);
            panel_Top_Button.Name = "panel_Top_Button";
            panel_Top_Button.Size = new Size(213, 104);
            panel_Top_Button.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Monotype Corsiva", 28.2F, FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Window;
            label2.Location = new Point(19, 23);
            label2.Name = "label2";
            label2.Size = new Size(178, 56);
            label2.TabIndex = 0;
            label2.Text = "Nhóm 10";
            // 
            // panel_Column
            // 
            panel_Column.BackColor = Color.MidnightBlue;
            panel_Column.Controls.Add(panel_Bottom_Button);
            panel_Column.Controls.Add(panel_Top_Button);
            panel_Column.Dock = DockStyle.Right;
            panel_Column.Location = new Point(759, 0);
            panel_Column.Name = "panel_Column";
            panel_Column.Size = new Size(213, 544);
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
            panel_icon_cl_off.ResumeLayout(false);
            panel_icon_sv.ResumeLayout(false);
            panel_Bottom_Button.ResumeLayout(false);
            panel_Right_Pillar.ResumeLayout(false);
            panel_Left_Pillar.ResumeLayout(false);
            panel_Top_Button.ResumeLayout(false);
            panel_Top_Button.PerformLayout();
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
        private Panel panel_Left_Pillar;
        private Panel panel_Bottom_Button;
        private Panel panel_All;
        private Panel panel_icon_sv;
        private Panel panel_icon_cl_off;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label1;
        private Button btn_icon_sv_off;
        private Button btn_icon_cli;
        private Label label2;
        private Button btn_Exit;
        private Panel panel1;
    }
}
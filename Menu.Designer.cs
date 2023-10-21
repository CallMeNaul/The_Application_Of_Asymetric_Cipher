namespace The_Application_Of_Asymetric_Cipher
{
    partial class Menu
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
            panel_Top = new Panel();
            panel_Advanced = new Panel();
            panel_Top_Advanced = new Panel();
            panel_Bottom_Top_Advanced = new Panel();
            btn_Advanced = new Button();
            btn_ad = new Button();
            panel_Basic = new Panel();
            panel_Bottom_Basic = new Panel();
            btn_Basic = new Button();
            btn_bs = new Button();
            panel_Options = new Panel();
            panel_Fill = new Panel();
            panel_Chat = new Panel();
            panel_Exit = new Panel();
            panel_Exit_Right = new Panel();
            panel_label = new Panel();
            label_Back = new Label();
            panel_Exit_Image = new Panel();
            panel_Advanced.SuspendLayout();
            panel_Top_Advanced.SuspendLayout();
            panel_Bottom_Top_Advanced.SuspendLayout();
            panel_Basic.SuspendLayout();
            panel_Bottom_Basic.SuspendLayout();
            panel_Options.SuspendLayout();
            panel_Fill.SuspendLayout();
            panel_Chat.SuspendLayout();
            panel_Exit.SuspendLayout();
            panel_Exit_Right.SuspendLayout();
            panel_label.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Top
            // 
            panel_Top.BackgroundImage = Properties.Resources.GROUPCARD10;
            panel_Top.BackgroundImageLayout = ImageLayout.Stretch;
            panel_Top.Dock = DockStyle.Top;
            panel_Top.Location = new Point(0, 0);
            panel_Top.Name = "panel_Top";
            panel_Top.Size = new Size(818, 147);
            panel_Top.TabIndex = 0;
            // 
            // panel_Advanced
            // 
            panel_Advanced.BackColor = Color.Transparent;
            panel_Advanced.Controls.Add(panel_Top_Advanced);
            panel_Advanced.Dock = DockStyle.Bottom;
            panel_Advanced.Location = new Point(0, 200);
            panel_Advanced.Name = "panel_Advanced";
            panel_Advanced.Size = new Size(818, 150);
            panel_Advanced.TabIndex = 5;
            // 
            // panel_Top_Advanced
            // 
            panel_Top_Advanced.Controls.Add(panel_Bottom_Top_Advanced);
            panel_Top_Advanced.Dock = DockStyle.Top;
            panel_Top_Advanced.Location = new Point(0, 0);
            panel_Top_Advanced.Name = "panel_Top_Advanced";
            panel_Top_Advanced.Size = new Size(818, 78);
            panel_Top_Advanced.TabIndex = 4;
            // 
            // panel_Bottom_Top_Advanced
            // 
            panel_Bottom_Top_Advanced.Controls.Add(btn_Advanced);
            panel_Bottom_Top_Advanced.Controls.Add(btn_ad);
            panel_Bottom_Top_Advanced.Dock = DockStyle.Bottom;
            panel_Bottom_Top_Advanced.Location = new Point(0, 0);
            panel_Bottom_Top_Advanced.Name = "panel_Bottom_Top_Advanced";
            panel_Bottom_Top_Advanced.Size = new Size(818, 78);
            panel_Bottom_Top_Advanced.TabIndex = 4;
            // 
            // btn_Advanced
            // 
            btn_Advanced.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_Advanced.BackColor = Color.Black;
            btn_Advanced.FlatStyle = FlatStyle.Popup;
            btn_Advanced.Font = new Font("Ravie", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Advanced.ForeColor = SystemColors.Window;
            btn_Advanced.Location = new Point(356, 22);
            btn_Advanced.Name = "btn_Advanced";
            btn_Advanced.Size = new Size(449, 55);
            btn_Advanced.TabIndex = 2;
            btn_Advanced.Text = "ADVANCED";
            btn_Advanced.UseVisualStyleBackColor = false;
            btn_Advanced.Click += btn_Advanced_Click;
            // 
            // btn_ad
            // 
            btn_ad.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_ad.BackColor = Color.Gray;
            btn_ad.CausesValidation = false;
            btn_ad.Enabled = false;
            btn_ad.FlatStyle = FlatStyle.Popup;
            btn_ad.Location = new Point(799, 28);
            btn_ad.Name = "btn_ad";
            btn_ad.Size = new Size(19, 44);
            btn_ad.TabIndex = 3;
            btn_ad.UseVisualStyleBackColor = false;
            // 
            // panel_Basic
            // 
            panel_Basic.BackColor = Color.Transparent;
            panel_Basic.Controls.Add(panel_Bottom_Basic);
            panel_Basic.Dock = DockStyle.Top;
            panel_Basic.Location = new Point(0, 0);
            panel_Basic.Name = "panel_Basic";
            panel_Basic.Size = new Size(818, 150);
            panel_Basic.TabIndex = 4;
            // 
            // panel_Bottom_Basic
            // 
            panel_Bottom_Basic.Controls.Add(btn_Basic);
            panel_Bottom_Basic.Controls.Add(btn_bs);
            panel_Bottom_Basic.Dock = DockStyle.Bottom;
            panel_Bottom_Basic.Location = new Point(0, 72);
            panel_Bottom_Basic.Name = "panel_Bottom_Basic";
            panel_Bottom_Basic.Size = new Size(818, 78);
            panel_Bottom_Basic.TabIndex = 2;
            // 
            // btn_Basic
            // 
            btn_Basic.BackColor = Color.Black;
            btn_Basic.FlatStyle = FlatStyle.Popup;
            btn_Basic.Font = new Font("Ravie", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Basic.ForeColor = SystemColors.Window;
            btn_Basic.Location = new Point(15, 0);
            btn_Basic.Name = "btn_Basic";
            btn_Basic.Size = new Size(449, 55);
            btn_Basic.TabIndex = 0;
            btn_Basic.Text = "BASIC";
            btn_Basic.UseVisualStyleBackColor = false;
            btn_Basic.Click += btn_Basic_Click;
            // 
            // btn_bs
            // 
            btn_bs.BackColor = Color.Gray;
            btn_bs.CausesValidation = false;
            btn_bs.Enabled = false;
            btn_bs.FlatStyle = FlatStyle.Popup;
            btn_bs.Location = new Point(-3, 6);
            btn_bs.Name = "btn_bs";
            btn_bs.Size = new Size(19, 44);
            btn_bs.TabIndex = 1;
            btn_bs.UseVisualStyleBackColor = false;
            // 
            // panel_Options
            // 
            panel_Options.Controls.Add(panel_Fill);
            panel_Options.Controls.Add(panel_Top);
            panel_Options.Location = new Point(0, 2);
            panel_Options.Name = "panel_Options";
            panel_Options.Size = new Size(818, 497);
            panel_Options.TabIndex = 2;
            // 
            // panel_Fill
            // 
            panel_Fill.BackgroundImage = Properties.Resources.Scrapbook_Cover;
            panel_Fill.Controls.Add(panel_Advanced);
            panel_Fill.Controls.Add(panel_Basic);
            panel_Fill.Dock = DockStyle.Fill;
            panel_Fill.Location = new Point(0, 147);
            panel_Fill.Name = "panel_Fill";
            panel_Fill.Size = new Size(818, 350);
            panel_Fill.TabIndex = 1;
            // 
            // panel_Chat
            // 
            panel_Chat.Controls.Add(panel_Exit);
            panel_Chat.Location = new Point(43, 532);
            panel_Chat.Name = "panel_Chat";
            panel_Chat.Size = new Size(383, 144);
            panel_Chat.TabIndex = 3;
            // 
            // panel_Exit
            // 
            panel_Exit.BackColor = Color.MidnightBlue;
            panel_Exit.Controls.Add(panel_Exit_Right);
            panel_Exit.Dock = DockStyle.Bottom;
            panel_Exit.Location = new Point(0, 94);
            panel_Exit.Name = "panel_Exit";
            panel_Exit.Size = new Size(383, 50);
            panel_Exit.TabIndex = 4;
            // 
            // panel_Exit_Right
            // 
            panel_Exit_Right.BackColor = Color.MidnightBlue;
            panel_Exit_Right.Controls.Add(panel_label);
            panel_Exit_Right.Controls.Add(panel_Exit_Image);
            panel_Exit_Right.Dock = DockStyle.Right;
            panel_Exit_Right.Location = new Point(170, 0);
            panel_Exit_Right.Name = "panel_Exit_Right";
            panel_Exit_Right.Size = new Size(213, 50);
            panel_Exit_Right.TabIndex = 4;
            // 
            // panel_label
            // 
            panel_label.Controls.Add(label_Back);
            panel_label.Dock = DockStyle.Fill;
            panel_label.Font = new Font("Monotype Corsiva", 19.8000011F, FontStyle.Italic, GraphicsUnit.Point);
            panel_label.ForeColor = Color.Cyan;
            panel_label.Location = new Point(56, 0);
            panel_label.Name = "panel_label";
            panel_label.Size = new Size(157, 50);
            panel_label.TabIndex = 4;
            panel_label.Click += panel_label_Click;
            panel_label.MouseEnter += panel_label_MouseEnter;
            panel_label.MouseLeave += panel_label_MouseLeave;
            // 
            // label_Back
            // 
            label_Back.AutoSize = true;
            label_Back.Dock = DockStyle.Fill;
            label_Back.Location = new Point(0, 0);
            label_Back.Name = "label_Back";
            label_Back.Size = new Size(79, 41);
            label_Back.TabIndex = 0;
            label_Back.Text = "Back";
            label_Back.Click += panel_label_Click;
            label_Back.MouseEnter += panel_label_MouseEnter;
            label_Back.MouseLeave += panel_label_MouseLeave;
            // 
            // panel_Exit_Image
            // 
            panel_Exit_Image.BackgroundImage = Properties.Resources.crossx_removebg_preview;
            panel_Exit_Image.BackgroundImageLayout = ImageLayout.Zoom;
            panel_Exit_Image.Dock = DockStyle.Left;
            panel_Exit_Image.Location = new Point(0, 0);
            panel_Exit_Image.Name = "panel_Exit_Image";
            panel_Exit_Image.Size = new Size(56, 50);
            panel_Exit_Image.TabIndex = 5;
            panel_Exit_Image.Click += panel_label_Click;
            panel_Exit_Image.MouseEnter += panel_label_MouseEnter;
            panel_Exit_Image.MouseLeave += panel_label_MouseLeave;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(967, 957);
            Controls.Add(panel_Chat);
            Controls.Add(panel_Options);
            Name = "Menu";
            Text = "Menu";
            SizeChanged += Menu_SizeChanged;
            panel_Advanced.ResumeLayout(false);
            panel_Top_Advanced.ResumeLayout(false);
            panel_Bottom_Top_Advanced.ResumeLayout(false);
            panel_Basic.ResumeLayout(false);
            panel_Bottom_Basic.ResumeLayout(false);
            panel_Options.ResumeLayout(false);
            panel_Fill.ResumeLayout(false);
            panel_Chat.ResumeLayout(false);
            panel_Exit.ResumeLayout(false);
            panel_Exit_Right.ResumeLayout(false);
            panel_label.ResumeLayout(false);
            panel_label.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Top;
        private Button btn_Basic;
        private Button btn_bs;
        private Panel panel_Basic;
        private Panel panel_Advanced;
        private Panel panel_Bottom_Basic;
        private Panel panel_Top_Advanced;
        private Panel panel_Options;
        private Panel panel_Fill;
        private Panel panel_Chat;
        private Panel panel_Exit;
        private Panel panel_Exit_Right;
        private Panel panel_Exit_Image;
        private Panel panel_label;
        private Label label_Back;
        private Button btn_Advanced;
        private Button btn_ad;
        private Panel panel_Bottom_Top_Advanced;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Application_Of_Asymetric_Cipher
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.Size = new Size(990, 651);
            panel_Options.Dock = DockStyle.Fill;
            panel_Chat.Visible = false;
        }
        void ChangeUI(bool decision)
        {
            if (decision)
            {
                panel_Options.Visible = false;
                panel_Chat.Visible = true;
            }
            else
            {
                panel_Chat.Visible = false;
                panel_Options.Visible = true;
                panel_Chat.Visible = false;
                if (currentFormChild != null)
                {
                    currentFormChild.Close();
                }
                currentFormChild = new Form();
            }
        }

        private void btn_Basic_Click(object sender, EventArgs e)
        {
            ChangeUI(true);
            btn_bs.BackColor = Color.Blue;
            btn_ad.BackColor = Color.Gray;
            OpenChildForm(new SecureChat());
            this.Text = "Menu: Secure Chat";
        }

        private void btn_Advanced_Click(object sender, EventArgs e)
        {
            btn_bs.BackColor = Color.Gray;
            btn_ad.BackColor = Color.Blue;
            ChangeUI(true);
            OpenChildForm(new SecureChat_Advanced());
            this.Text = "Menu: Advanced Secure Chat";
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            this.Size = new Size(990, 651);
            panel_Chat.Dock = DockStyle.Fill;
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Chat.Controls.Add(childForm);
            panel_Chat.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Menu_SizeChanged(object sender, EventArgs e)
        {
            panel_Options.Visible = false;
            panel_Top.Height = this.Height / 3;
            panel_Top.Width = this.Width / 3;
            btn_Basic.Width = this.Width / 2;
            btn_Advanced.Width = this.Width / 2;
            btn_Advanced.Location = new Point(btn_ad.Location.X - btn_Advanced.Width, btn_Advanced.Location.Y);
            panel_Options.Visible = true;
        }

        private void panel_label_Click(object sender, EventArgs e)
        {
            ChangeUI(false);
            this.Text = "Menu";
        }
        private void MousingButtonBack() { panel_label.BackColor = Color.CornflowerBlue; }
        private void DisMousingButtonBack() { panel_label.BackColor = Color.MidnightBlue; }
        private void panel_label_MouseEnter(object sender, EventArgs e) { MousingButtonBack(); }
        private void panel_label_MouseLeave(object sender, EventArgs e) { DisMousingButtonBack(); }
    }
}

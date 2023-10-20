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
            this.Size = new Size(818, 497);
            panel_Options.Dock = DockStyle.Fill;
        }

        private void btn_Basic_Click(object sender, EventArgs e)
        {
            btn_bs.BackColor = Color.Blue;
            btn_ad.BackColor = Color.Gray;
            panel_Options.Visible = false;
            OpenChildForm(new SecureChat());
            this.Text += ": Secure Chat";
        }

        private void btn_Advanced_Click(object sender, EventArgs e)
        {
            btn_ad.BackColor = Color.Blue;
            btn_bs.BackColor = Color.Gray;
            panel_Options.Visible = false;
            OpenChildForm(new SecureChat_Advanced());
            this.Text += ": Advanced Secure Chat";
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            this.Size = new Size(990, 591);
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
    }
}

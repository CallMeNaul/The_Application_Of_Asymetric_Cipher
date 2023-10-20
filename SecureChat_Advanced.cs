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
    public partial class SecureChat_Advanced : Form
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public SecureChat_Advanced()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
            btn_Client.Enabled = false;
            panel_icon_cli.Enabled = false;
            panel_icon_sv_off.Visible = false;
            panel_icon_cl_off.Visible = true;
        }
        static int numClient = 1;
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childForm);
            panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void OpenServer()
        {
            OpenChildForm(new Server_Advanced());
            btn_Server.Enabled = false;
            panel_icon_sv.Enabled = false;
            btn_Client.Enabled = true;
            panel_icon_cli.Enabled = true;
            panel_icon_sv_off.Visible = true;
            panel_icon_cl_off.Visible = false;
        }

        private void OpenClient()
        {
            Client_Advanced cl = new Client_Advanced(numClient++);
            cl.Show();
        }
        private void btn_Server_Click(object sender, EventArgs e)
        {
            OpenServer();
        }

        private void btn_Client_Click(object sender, EventArgs e)
        {
            OpenClient();
        }

        private void panel_icon_sv_Click(object sender, EventArgs e)
        {
            OpenServer();
        }

        private void panel_icon_cli_Click(object sender, EventArgs e)
        {
            OpenClient();
        }
    }
}

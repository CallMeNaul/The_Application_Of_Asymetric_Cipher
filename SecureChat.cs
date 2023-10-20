namespace The_Application_Of_Asymetric_Cipher
{
    public partial class SecureChat : Form
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public SecureChat()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();

            btn_Client.Enabled = false;
            btn_icon_cli.Visible = false;
            panel_icon_cl_off.Visible = true;

            btn_icon_sv_off.Visible = false;
            panel_icon_sv.Visible = true;

        }

        static int numClient = 1;
        private Form currentFormChild;
        private bool clickedServerButton = false;
        private bool clickedClientButton = false;
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
        private void MousingButtonServer() { btn_Server.BackColor = Color.CornflowerBlue; }
        private void DisMousingButtonServer()
        {
            if (!clickedServerButton)
                btn_Server.BackColor = Color.MidnightBlue;
            else
                btn_Server.BackColor = Color.Gold;
        }
        private void MousingButtonExit() { btn_Exit.BackColor = Color.CornflowerBlue; }
        private void DisMousingButtonExit() { btn_Exit.BackColor = Color.MidnightBlue; }
        private void MousingButtonClient() { btn_Client.BackColor = Color.CornflowerBlue; }
        private void DisMousingButtonClient()
        {
            if (!clickedClientButton)
                btn_Client.BackColor = Color.MidnightBlue;
            else
                btn_Client.BackColor = Color.Gold;
        }

        private void OpenServer()
        {
            OpenChildForm(new Server());
            btn_Server.Enabled = false;
            btn_icon_sv_off.Enabled = false;
            panel_icon_sv.Visible = true;
            panel_icon_sv.Enabled = false;
            btn_Server.BackColor = Color.Gold;
            clickedServerButton = true;

            btn_Client.Enabled = true;
            btn_icon_cli.Visible = true;
            btn_icon_cli.Enabled = true;
            btn_icon_sv_off.Visible = true;
        }

        private void OpenClient()
        {
            Client cl = new Client(numClient++);
            cl.Show();
            clickedClientButton = true;
            btn_Server.BackColor = Color.MidnightBlue;
            panel_icon_sv.BackColor = Color.MidnightBlue;
            btn_Client.BackColor = Color.Gold;
        }

        private void btn_Server_Click(object sender, EventArgs e) { OpenServer(); }
        private void btn_Client_Click(object sender, EventArgs e) { OpenClient(); }

        private void btn_Server_MouseEnter(object sender, EventArgs e) { MousingButtonServer(); }
        private void btn_Server_MouseLeave(object sender, EventArgs e) { DisMousingButtonServer(); }

        private void btn_Client_MouseEnter(object sender, EventArgs e) { MousingButtonClient(); }
        private void btn_Client_MouseLeave(object sender, EventArgs e) { DisMousingButtonClient(); }

        private void btn_Exit_Click(object sender, EventArgs e) { this.Close(); }

        private void btn_Exit_MouseEnter(object sender, EventArgs e) { MousingButtonExit(); }
        private void panel1_MouseLeave(object sender, EventArgs e) { DisMousingButtonExit(); }
    }
}
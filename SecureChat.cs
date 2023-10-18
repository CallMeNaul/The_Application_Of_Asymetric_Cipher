namespace The_Application_Of_Asymetric_Cipher
{
    public partial class SecureChat : Form
    {
        public SecureChat()
        {
            InitializeComponent();
            btn_Client.Enabled = false;
            panel_icon_cli.Enabled = false;
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
            OpenChildForm(new Server());
            btn_Server.Enabled = false;
            panel_icon_sv.Enabled = false;
            btn_Client.Enabled = true;
            panel_icon_cli.Enabled = true;
            panel_icon_sv.BackgroundImage = new Bitmap(new FileStream(
                "sv_off-removebg-preview.png", FileMode.Open));
        }

        private void OpenClient()
        {
            Client cl = new Client(numClient++);
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
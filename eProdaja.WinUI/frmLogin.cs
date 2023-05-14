namespace eProdaja.WinUI {
    public partial class frmLogin : Form {

        private readonly APIService _api = new APIService("Korisnici");
        public frmLogin() { InitializeComponent(); }
        private void frmLogin_Load(object sender, EventArgs e) { }

        private async void btnLogin_Click(object sender, EventArgs e) {

            APIService.username = txtUsername.Text;
            APIService.password = txtPassword.Text;

            try {
                var rez = await _api.Get<dynamic>();

                //frmKorisnici forma = new frmKorisnici();
                //forma.Show();
                mdiForm forma = new mdiForm();
                forma.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show("Wrong usermae or password"); }
        }
    }
}
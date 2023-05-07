namespace eProdaja.WinUI {
    public partial class Form1 : Form {
        public Form1() { InitializeComponent(); }
        public APIService KorisniciService { get; set; } = new APIService("Korisnici");

        private void Form1_Load(object sender, EventArgs e) { }

        private async void btnShow_Click(object sender, EventArgs e) {
            var list = await KorisniciService.Get<dynamic>();
        }
    }
}
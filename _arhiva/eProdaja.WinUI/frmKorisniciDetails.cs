using eProdaja.Model;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace eProdaja.WinUI {
    public partial class frmKorisniciDetails : Form {
        public APIService KorisniciService { get; set; } = new APIService("Korisnici");
        public APIService RoleService { get; set; } = new APIService("Uloge");
        private Korisnici _model = null;
        public frmKorisniciDetails(Korisnici model = null) { 
            InitializeComponent();
            _model = model;
        }
        private async void frmKorisniciDetails_Load(object sender, EventArgs e) {
            await LoadRoles();
            if (_model != null)
                UcitajPodatke();
        }

        private void UcitajPodatke() {
            txtIme.Text = _model.Ime;
            txtPrezime.Text = _model.Prezime;
            txtEmail.Text = _model.Email;
            txtUsername.Text = _model.KorisnickoIme;
            cbStatus.Checked = _model.Status.GetValueOrDefault(false);
        }

        private async Task LoadRoles() {
            var roles = await RoleService.Get<List<Uloge>>();
            clbUloge.DataSource = roles;
            clbUloge.DisplayMember = "Naziv";
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e) {
            var roleList = clbUloge.CheckedItems.Cast<Uloge>().ToList();
            var roleIdList = roleList.Select(x => x.UlogaId).ToList();

            if (_model == null) {
                KorisniciInsertRequest insertRequers = new KorisniciInsertRequest() {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Email = txtEmail.Text,
                    KorisnickoIme = txtUsername.Text,
                    Password = txtPassword.Text,
                    PasswordPotvrda = txtPasswordConf.Text,
                    Status = cbStatus.Checked,
                    UlogeIdList = roleIdList
                };
                var user = await KorisniciService.Post<Korisnici>(insertRequers);
            }
            else {
                KorisniciUpdateRequest updateRequest = new KorisniciUpdateRequest() {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    PasswordPotvrda = txtPasswordConf.Text,
                    Status = cbStatus.Checked,
                };
                _model = await KorisniciService.Put<Korisnici>(_model.KorisnikId, updateRequest);
            }
        }
    }
}

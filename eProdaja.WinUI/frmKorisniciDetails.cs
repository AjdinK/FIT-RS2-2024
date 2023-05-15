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

namespace eProdaja.WinUI {
    public partial class frmKorisniciDetails : Form {
        public APIService KorisniciService { get; set; } = new APIService("Korisnici");
        public APIService RoleService { get; set; } = new APIService("Uloge");

        public frmKorisniciDetails() { InitializeComponent(); }
        private async void frmKorisniciDetails_Load(object sender, EventArgs e) {
            await LoadRoles();
        }

        private async Task LoadRoles() {
            var roles = await RoleService.Get<List<Uloge>>();
            clbUloge.DataSource = roles;
            clbUloge.DisplayMember = "Naziv";
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e) {
            var roleList = clbUloge.CheckedItems.Cast<Uloge>().ToList();
            var roleIdList = roleList.Select(x => x.UlogaId).ToList();
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
    }
}

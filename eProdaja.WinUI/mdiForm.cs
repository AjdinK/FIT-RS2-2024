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
    public partial class mdiForm : Form {
        public mdiForm() { InitializeComponent(); }

        private void pretregaToolStripMenuItem_Click(object sender, EventArgs e) {
            frmKorisnici forma = new frmKorisnici();
            forma.ShowDialog();
        }

        private void noviKorisnikToolStripMenuItem_Click(object sender, EventArgs e) {
            frmKorisniciDetails forma = new frmKorisniciDetails();
            forma.ShowDialog();

        }
    }
}

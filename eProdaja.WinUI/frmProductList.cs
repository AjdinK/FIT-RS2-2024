using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl;
using Flurl.Http;

namespace eProdaja.WinUI {
    public partial class frmProductList : Form {

        public APIService ProductService { get; set; } = new APIService("Proizvodi");

        public frmProductList() { InitializeComponent(); }

        private void btnShow_Click(object sender, EventArgs e) {
            var list = ProductService.Get<dynamic>().Result;
            var rez = ProductService.Get<dynamic>().Result;
        }

        private void frmProductList_Load(object sender, EventArgs e) {

        }
    }
}

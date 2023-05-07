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

        private async void btnShow_Click(object sender, EventArgs e) {
            var list = await ProductService.Get<dynamic>();
            var rez = await ProductService.GetById<dynamic>(14);
        }

        private void frmProductList_Load(object sender, EventArgs e) {}
    }
}

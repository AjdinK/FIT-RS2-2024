using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model.SearchObjects {
    public class JediniceMjereSearchObject {

        public string Naziv { get; set; }
        public int? JediniceMjereId { get; set; }

        public int? Page { get; set; }
        public int? PageSize { get; set; }

    }
}

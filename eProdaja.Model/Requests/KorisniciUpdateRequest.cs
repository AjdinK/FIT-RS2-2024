using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eProdaja.Model.Requests {
    public class KorisniciUpdateRequest {
        [Required(AllowEmptyStrings = false)]
        public string Ime { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Prezime { get; set; }

        [EmailAddress()]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Telefon { get; set; }
        public string Password { get; set; }
        public string PasswordPotvrda { get; set; }
        public bool? Status { get; set; }
    }
}

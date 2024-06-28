namespace eProdaja.Model.Requests
{
    public class KorisniciInsertRequest
    {

        public string Ime { get; set; } = null!;

        public string Prezime { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Telefon { get; set; } = null!;

        public string KorisnickoIme { get; set; } = null!;

        public bool Status { get; set; }
        
        public string Lozinka { get; set; } = null!;
        
        public string LozinkaPotvrda { get; set; } = null!;
        
    }
}
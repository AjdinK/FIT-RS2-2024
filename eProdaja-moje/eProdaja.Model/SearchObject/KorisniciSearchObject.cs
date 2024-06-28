namespace eProdaja.Model.SearchObject
{
    public class KorisniciSearchObject : BaseSearchObject
    {

        public string? Ime { get; set; }

        public string? Prezime { get; set; }

        public string? Email { get; set; }

        public string? Telefon { get; set; }

        public string? KorisnickoIme { get; set; }

        public bool? Status { get; set; }
        
        public bool? IsUlogeIncluded { get; set; }
        
    }
}
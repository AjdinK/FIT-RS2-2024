namespace eProdaja.Model.Requests
{
    public class ProizvodiInsertRequest
    {

        public string Naziv { get; set; } = null!;

        public string Sifra { get; set; } = null!;

        public decimal Cijena { get; set; }

        public int VrstaId { get; set; }

        public int JedinicaMjereId { get; set; }

        // public byte[]? Slika { get; set;
        // public byte[]? SlikaThumb { get; set; }

        public bool? Status { get; set; }

        public string? StateMachine { get; set; }   
    }
}
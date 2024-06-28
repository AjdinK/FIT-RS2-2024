namespace eProdaja.Model.Requests
{
    public class ProizvodiUpdateRequest
    {
        public string Naziv { get; set; } = null!;

        public decimal Cijena { get; set; }

        public int VrstaId { get; set; }

        public int JedinicaMjereId { get; set; }
        
        public bool? Status { get; set; }

        public string? StateMachine { get; set; }      
    }
}
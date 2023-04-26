using eProdaja.Model;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers {
    
    public class ProizvodiController : BaseController<Model.Proizvodi> {

        public ProizvodiController(IService<Model.Proizvodi> service) : base(service) {
          
        }
    }
}

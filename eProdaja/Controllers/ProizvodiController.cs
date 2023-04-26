using eProdaja.Model;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers {
    
    public class ProizvodiController : BaseController<Model.Proizvodi , ProizvodiSearchObject> {

        public ProizvodiController(IService<Model.Proizvodi , ProizvodiSearchObject> service) : base(service) {
          
        }


    }
}

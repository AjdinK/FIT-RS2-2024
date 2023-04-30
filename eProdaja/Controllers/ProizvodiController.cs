using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers {
    
    public class ProizvodiController : BaseCRUDController<Model.Proizvodi , ProizvodiSearchObject , ProizvodiInsertRequest , ProizvodiInsertRequest> {

        public ProizvodiController(IProizvodiService service)
            : base(service) {
          
        }
    }
}

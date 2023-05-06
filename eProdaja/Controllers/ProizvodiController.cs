using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;

namespace eProdaja.Controllers {

    public class ProizvodiController : BaseCRUDController<Model.Proizvodi , ProizvodiSearchObject , ProizvodiInsertRequest , ProizvodiUpdateRequest> {
        public ProizvodiController(IProizvodiService service) : base(service) {}
    }
}

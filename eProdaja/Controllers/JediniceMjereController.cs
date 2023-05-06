using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;

namespace eProdaja.Controllers {

    public class JediniceMjereController : BaseCRUDController<Model.JediniceMjere, JediniceMjereSearchObject , JediniceMjereUpsertRequest , JediniceMjereUpsertRequest> {
        public JediniceMjereController(IJediniceMjereService service) : base(service) {}
    }
}

using eProdaja.DataBase;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers {

    public class JediniceMjereController : BaseCRUDController<Model.JediniceMjere, JediniceMjereSearchObject , JediniceMjereUpsertRequest , JediniceMjereUpsertRequest> {
        public JediniceMjereController(IJediniceMjereService service) : base(service) {}

        [AllowAnonymous]
        public override IEnumerable<Model.JediniceMjere> Get([FromQuery] JediniceMjereSearchObject search = null) {
            return base.Get(search);
        }

        [AllowAnonymous]
        public override Model.JediniceMjere GetByID(int id) {
            return base.GetByID(id);
        }
    }
}

using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class VrsteProizvodumController : BaseCRUDController<VrsteProizvodum, VrsteProizvodumSearchObject, VrsteProizvodumUpsertRequest, VrsteProizvodumUpsertRequest>
    {
        
        public VrsteProizvodumController(IVrsteProizvodumService service)
        : base(service) {
        }

        [Authorize(Roles = "Administrator")]
        public override VrsteProizvodum Insert(VrsteProizvodumUpsertRequest request)
        {
            return base.Insert(request);
        }

        [AllowAnonymous]
        public override PagedResult<VrsteProizvodum> GetList([FromQuery] VrsteProizvodumSearchObject searchObject)
        {
            return base.GetList(searchObject);
        }

    }
}

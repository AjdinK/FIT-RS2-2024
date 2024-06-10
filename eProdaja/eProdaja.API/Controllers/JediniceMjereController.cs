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
    public class JediniceMjereController : BaseController<JediniceMjere, JediniceMjereSearchObject>
    {
        
        public JediniceMjereController(IJediniceMjereService service)
        : base(service) {
        }

    }
}

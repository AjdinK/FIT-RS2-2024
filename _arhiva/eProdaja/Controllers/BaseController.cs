using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers {
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BaseController <T , TSearch> : ControllerBase where T : class where TSearch : class {
        public IService <T ,TSearch> Service {get;set;}
        public BaseController(IService<T , TSearch> service) {Service = service;}

        [HttpGet]
        public virtual IEnumerable<T> Get([FromQuery]TSearch search  = null) {return Service.Get(search);}

        [HttpGet("{id}")]
        public virtual T GetByID(int id) {return Service.GetByID(id);}
    }
}

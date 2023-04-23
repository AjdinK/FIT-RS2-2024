using eProdaja.Model;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ProizvodiController : ControllerBase {

        private readonly IService<Model.Proizvodi> _service;

        public ProizvodiController(IService<Model.Proizvodi> service) {
           _service = service;
        }

        [HttpGet]
        public IEnumerable<Model.Proizvodi> Get() {
            return _service.Get();
        }


        [HttpGet("{id}")]
        public Model.Proizvodi GetByID(int id) {

            return _service.GetByID(id);

        }


    }
}

using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers {

    [ApiController]
    [Route("[controller]")]

    public class JediniceMjereController : ControllerBase {

        private readonly IJediniceMjereService _service;

        public JediniceMjereController(IJediniceMjereService service) {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Model.JediniceMjere> Get() {
            return _service.Get();
        }


        [HttpGet("{id}")]
        public Model.JediniceMjere GetByID(int id) {

            return _service.GetByID(id);

        }

    }
}

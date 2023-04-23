using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers {

    [ApiController]
    [Route("[controller]")]

    public class JediniceMjereController : ControllerBase {

        private readonly IService<Model.JediniceMjere> _service;

        public JediniceMjereController(IService<Model.JediniceMjere> service) {
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

using eProdaja.Model;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ProizvodiController : ControllerBase {

        private readonly IProizvodiService _proizvodiService;

        public ProizvodiController(IProizvodiService proizvodiService) {
            _proizvodiService = proizvodiService;
        }

        [HttpGet]
        public IEnumerable<Model.Proizvodi> Get() {
            return _proizvodiService.Get();
        }


        [HttpGet("{id}")]
        public Model.Proizvodi GetByID(int id) {

            return _proizvodiService.GetByID(id);

        }


    }
}

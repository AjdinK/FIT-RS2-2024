using eProdaja.DataBase;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers {

    public class JediniceMjereController : BaseController<Model.JediniceMjere> {

        public JediniceMjereController(IService<Model.JediniceMjere> service) : base(service) {
           
        }
    }
}

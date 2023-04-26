using eProdaja.DataBase;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers {

    public class JediniceMjereController : BaseController<Model.JediniceMjere,object> {

        public JediniceMjereController(IService<Model.JediniceMjere , object> service) : base(service) {
           
        }
    }
}

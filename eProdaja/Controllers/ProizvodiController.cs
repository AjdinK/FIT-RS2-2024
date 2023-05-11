using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers {
    public class ProizvodiController : BaseCRUDController<Model.Proizvodi , ProizvodiSearchObject , ProizvodiInsertRequest , ProizvodiUpdateRequest> {
        public IProizvodiService Service { get; set; }
        public ProizvodiController(IProizvodiService service) : base(service) { Service = service; }

        [HttpPut("{id}/Activate")]
        public Model.Proizvodi Activate (int id) {
            var rez = Service.Activate(id);
            return rez;
        }
        [HttpPut("{id}/AllowedActions")]
        public List<string> AllowedActions (int id) {
            var rez = Service.AllowedActions(id);
            return rez; }
    }
}

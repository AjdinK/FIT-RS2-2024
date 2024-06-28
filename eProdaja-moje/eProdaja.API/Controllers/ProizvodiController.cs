using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObject;
using eProdaja.Services;

namespace eProdaja.API.Controllers;

public class ProizvodiController : BaseCrudController<Model.Proizvodi , ProizvodiSearchObject,ProizvodiInsertRequest,ProizvodiUpdateRequest>
{
    protected IProizvodi _service;
    
    public ProizvodiController(IProizvodi service) : base(service)
    {
        _service = service;
    }
}
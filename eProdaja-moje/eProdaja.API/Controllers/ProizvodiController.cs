using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObject;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProizvodiController : BaseCrudController<Proizvodi, ProizvodiSearchObject, ProizvodiInsertRequest,
    ProizvodiUpdateRequest>
{
    protected IProizvodi _service;

    public ProizvodiController(IProizvodi service) : base(service)
    {
        _service = service;
    }

    [HttpPatch("{id}/Activate")]
    public Proizvodi Activate(int id)
    {
        return _service.Activate(id);
    }

    [HttpPatch("{id}/Edit")]
    public Proizvodi Edit(int id)
    {
        return _service.Edit(id);
    }

    [HttpPatch("{id}/Hide")]
    public Proizvodi Hide(int id)
    {
        return _service.Hide(id);
    }

    [HttpGet("{id}/GetAllowedActions")]
    public List<string> GetAllowedActions(int id)
    {
        return _service.GetAllowedActions(id);
    }
}
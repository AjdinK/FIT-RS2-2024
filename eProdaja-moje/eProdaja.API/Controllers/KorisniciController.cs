using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObject;
using eProdaja.Services;

namespace eProdaja.API.Controllers;

public class KorisniciController : BaseCrudController<Model.Korisnici , KorisniciSearchObject,KorisniciInsertRequest, KorisniciUpdateRequest>
{
    protected IKorisnici _service { get; set; }

    public KorisniciController(IKorisnici service) : base(service)
    {
        _service = service;
    }
}
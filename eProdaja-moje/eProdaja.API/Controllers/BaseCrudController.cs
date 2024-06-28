using eProdaja.Model.SearchObject;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.API.Controllers;
[ApiController]
[Route("[controller]")]
public class BaseCrudController <TModel , TSearch , TInsert , TUpdate> : BaseController<TModel , TSearch > where TModel : class where TSearch : BaseSearchObject where TInsert : class where TUpdate : class
{
    protected readonly ICrudService<TModel , TSearch , TInsert , TUpdate> _service;
    public BaseCrudController(ICrudService<TModel , TSearch , TInsert , TUpdate> service) : base(service)
    {
        _service = service;
    }

    [HttpPost]
    public TModel Insert([FromBody] TInsert insert)
    {
        return _service.Insert(insert);
    }

    [HttpPut]
    public TModel Update([FromQuery]int id, TUpdate update)
    {
        return _service.Update(id ,update);
    }
    
    [HttpDelete]
    public TModel Delete([FromQuery]int id)
    {
        return _service.Delete(id);
    }
}
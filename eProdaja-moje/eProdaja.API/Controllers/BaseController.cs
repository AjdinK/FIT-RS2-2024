using eProdaja.Model;
using eProdaja.Model.SearchObject;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.API.Controllers;
[ApiController]
[Route ("[controller]")]

public class BaseController <TModel , TSearch> : ControllerBase where TModel : class where TSearch : BaseSearchObject
{
    protected IService<TModel, TSearch> _service;

    public BaseController(IService<TModel, TSearch> service)
    {
        _service = service;
    }

    [HttpGet]
    public PagedList<TModel> GetAll([FromQuery] TSearch search)
    {
        return _service.GetAll(search);
    }

    [HttpGet("{id}")]
    public TModel GetById(int id)
    {
        return _service.GetById(id);
    }

}
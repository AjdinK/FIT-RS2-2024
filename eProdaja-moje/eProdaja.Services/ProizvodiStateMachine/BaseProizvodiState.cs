using eProdaja.Model.Requests;
using eProdaja.Services.Database;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Proizvodi = eProdaja.Model.Proizvodi;

namespace eProdaja.Services.ProizvodiStateMachine;

public class BaseProizvodiState
{
    public BaseProizvodiState(EProdajaContext context, IMapper mapper, IServiceProvider service)
    {
        _context = context;
        _mapper = mapper;
        _service = service;
    }

    protected EProdajaContext _context { get; set; }
    protected IMapper _mapper { get; set; }
    protected IServiceProvider _service { get; set; }

    public virtual Proizvodi Insert(ProizvodiInsertRequest insert)
    {
        throw new NotImplementedException();
    }

    public virtual Proizvodi Update(int id, ProizvodiUpdateRequest update)
    {
        throw new NotImplementedException();
    }

    public virtual Proizvodi Activate(int id)
    {
        throw new NotImplementedException();
    }

    public virtual Proizvodi Edit(int id)
    {
        throw new NotImplementedException();
    }

    public virtual Proizvodi Hide(int id)
    {
        throw new NotImplementedException();
    }

    public virtual List<string> GetAllowedActions(Database.Proizvodi entitiy)
    {
        throw new NotImplementedException();
    }


    public BaseProizvodiState CreateState(string stateName)
    {
        switch (stateName)
        {
            case "initial":
                return _service.GetService<InitialProizvodiState>();
            case "draft":
                return _service.GetService<DraftProizvodiState>();
            case "active":
                return _service.GetService<ActiveProizvodiState>();
            case "hide":
                return _service.GetService<HiddenProizvodiState>();
            default:
                throw new NotImplementedException();
        }
    }
}
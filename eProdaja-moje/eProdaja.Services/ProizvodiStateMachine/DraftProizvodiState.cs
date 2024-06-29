using eProdaja.Model.Requests;
using eProdaja.Services.Database;
using MapsterMapper;
using Proizvodi = eProdaja.Model.Proizvodi;

namespace eProdaja.Services.ProizvodiStateMachine;

public class DraftProizvodiState : BaseProizvodiState 
{
    public DraftProizvodiState(EProdajaContext context, IMapper mapper, IServiceProvider service)
        : base(context, mapper, service)
    {
    }

    public override Proizvodi Update(int id, ProizvodiUpdateRequest update)
    {
        var entity = _context.Proizvodis.Find(id);
        _mapper.Map(update, entity);
        _context.SaveChanges();
        return _mapper.Map<Model.Proizvodi>(entity);
    }

    public override Proizvodi Activate(int id)
    {
        var entity = _context.Proizvodis.Find(id);
        entity.StateMachine = "active";
        _context.SaveChanges();
        return _mapper.Map<Model.Proizvodi>(entity);
    }

    public override Proizvodi Hide(int id)
    {
        var entity = _context.Proizvodis.Find(id);
        entity.StateMachine = "hide";
        _context.SaveChanges();
        return _mapper.Map<Model.Proizvodi>(entity);
    }

    public override List<string> GetAllowedActions(Database.Proizvodi entitiy)
    {
        return new List <string>()
        {
            nameof(Update),
            nameof(Activate),
            nameof(Hide),
        };
    }
}
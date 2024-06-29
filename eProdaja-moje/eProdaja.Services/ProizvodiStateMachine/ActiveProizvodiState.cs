using eProdaja.Services.Database;
using MapsterMapper;
using Proizvodi = eProdaja.Model.Proizvodi;

namespace eProdaja.Services.ProizvodiStateMachine;

public class ActiveProizvodiState : BaseProizvodiState
{
    public ActiveProizvodiState(EProdajaContext context, IMapper mapper, IServiceProvider service)
        : base(context, mapper, service)
    {
    }

    public override Proizvodi Edit(int id)
    {
        var entity = _context.Proizvodis.Find(id);
        entity.StateMachine = "draft";
        _context.SaveChanges();
        return _mapper.Map<Proizvodi>(entity);
    }

    public override List<string> GetAllowedActions(Database.Proizvodi entitiy)
    {
        return new List<string>
        {
            nameof(Edit)
        };
    }
}
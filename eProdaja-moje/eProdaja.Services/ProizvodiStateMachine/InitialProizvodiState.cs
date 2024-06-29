using eProdaja.Model.Requests;
using eProdaja.Services.Database;
using MapsterMapper;
using Proizvodi = eProdaja.Model.Proizvodi;

namespace eProdaja.Services.ProizvodiStateMachine;

public class InitialProizvodiState : BaseProizvodiState
{
    public InitialProizvodiState(EProdajaContext context, IMapper mapper, IServiceProvider service)
        : base(context, mapper, service)
    {
    }

    public override Proizvodi Insert(ProizvodiInsertRequest insert)
    {
        var entity = _mapper.Map<Database.Proizvodi>(insert);
        entity.StateMachine = "draft";
        _context.Proizvodis.Add(entity);
        _context.SaveChanges();
        return _mapper.Map<Model.Proizvodi>(entity);
    }

    public override List<string> GetAllowedActions(Database.Proizvodi entitiy)
    {
        return new List<string>()
        {
            nameof(Insert),
        };
    }
}
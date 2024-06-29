using eProdaja.Model.Requests;
using eProdaja.Model.SearchObject;
using eProdaja.Services.Database;
using eProdaja.Services.ProizvodiStateMachine;
using MapsterMapper;
using Proizvodi = eProdaja.Model.Proizvodi;

namespace eProdaja.Services;

public class ProizvodiService : CrudBaseService<Proizvodi, ProizvodiSearchObject, Database.Proizvodi,
    ProizvodiInsertRequest, ProizvodiUpdateRequest>, IProizvodi
{
    public ProizvodiService(EProdajaContext context, IMapper mapper, BaseProizvodiState baseProizvodiState) : base(
        context, mapper)
    {
        _baseProizvodiState = baseProizvodiState;
    }

    protected BaseProizvodiState _baseProizvodiState { get; set; }

    public override Proizvodi Insert(ProizvodiInsertRequest insert)
    {
        var state = _baseProizvodiState.CreateState("initial");
        return state.Insert(insert);
    }

    public override Proizvodi Update(int id, ProizvodiUpdateRequest update)
    {
        var entity = _context.Proizvodis.Find(id);
        var state = _baseProizvodiState.CreateState(entity.StateMachine);
        return state.Update(id, update);
    }

    public Proizvodi Activate(int id)
    {
        var entity = _context.Proizvodis.Find(id);
        var state = _baseProizvodiState.CreateState(entity.StateMachine);
        return state.Activate(id);
    }

    public Proizvodi Edit(int id)
    {
        var entity = _context.Proizvodis.Find(id);
        var state = _baseProizvodiState.CreateState(entity.StateMachine);
        return state.Edit(id);
    }

    public Proizvodi Hide(int id)
    {
        var entity = _context.Proizvodis.Find(id);
        var state = _baseProizvodiState.CreateState(entity.StateMachine);
        return state.Hide(id);
    }

    public List<string> GetAllowedActions(int id)
    {
        if (id <= 0)
        {
            var state = _baseProizvodiState.CreateState("initial");
            return state.GetAllowedActions(null);
        }
        else
        {
            var entity = _context.Proizvodis.Find(id);
            var state = _baseProizvodiState.CreateState(entity.StateMachine);
            return state.GetAllowedActions(entity);
        }
    }

    protected override IQueryable<Database.Proizvodi> AddFilter(IQueryable<Database.Proizvodi> query,
        ProizvodiSearchObject search)
    {
        var filterQuery = base.AddFilter(query, search);

        if (!string.IsNullOrWhiteSpace(search?.Naziv))
            filterQuery = filterQuery.Where(x => x.Naziv.ToLower().Contains(search.Naziv.ToLower()));

        if (!string.IsNullOrWhiteSpace(search?.Sifra)) filterQuery = filterQuery.Where(x => x.Sifra == search.Sifra);
        return filterQuery;
    }
}
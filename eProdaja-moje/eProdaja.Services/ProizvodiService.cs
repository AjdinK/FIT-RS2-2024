using eProdaja.Model.Requests;
using eProdaja.Model.SearchObject;
using eProdaja.Services.Database;
using MapsterMapper;

namespace eProdaja.Services;

public class ProizvodiService : CrudBaseService<Model.Proizvodi , ProizvodiSearchObject , Database.Proizvodi, ProizvodiInsertRequest,ProizvodiUpdateRequest>, IProizvodi
{
    public ProizvodiService(EProdajaContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override IQueryable<Proizvodi> AddFilter(IQueryable<Proizvodi> query, ProizvodiSearchObject search)
    {
        
       var filterQuery =  base.AddFilter(query, search);

       if (!string.IsNullOrWhiteSpace(search?.Naziv))
       {
           filterQuery = filterQuery.Where(x => x.Naziv.ToLower().Contains(search.Naziv.ToLower()));
       }
       
       if (!string.IsNullOrWhiteSpace(search?.Sifra))
       {
           filterQuery = filterQuery.Where(x => x.Sifra == search.Sifra);
       }
       
       return filterQuery;
    }
}
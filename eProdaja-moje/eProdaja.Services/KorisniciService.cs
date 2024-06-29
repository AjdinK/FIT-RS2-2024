using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObject;
using eProdaja.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Korisnici = eProdaja.Services.Database.Korisnici;

namespace eProdaja.Services;

public class KorisniciService : CrudBaseService<Model.Korisnici, KorisniciSearchObject, Korisnici,
    KorisniciInsertRequest, KorisniciUpdateRequest>, IKorisnici
{
    public KorisniciService(EProdajaContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public Model.Korisnici Login(string username, string password)
    {
        var entity =
            _context.Korisnicis
                .Include(x => x.KorisniciUloges)
                .ThenInclude(x => x.Uloga)
                .FirstOrDefault(x => x.KorisnickoIme == username);

        if (entity == null) return null;

        var hash = PasswordGenerator.GenerateHash(entity.LozinkaSalt, password);
        if (entity.LozinkaHash != hash) return null;

        return _mapper.Map<Model.Korisnici>(entity);
    }

    protected override IQueryable<Korisnici> AddFilter(IQueryable<Korisnici> query, KorisniciSearchObject search)
    {
        var queryFilter = base.AddFilter(query, search);

        if (!string.IsNullOrWhiteSpace(search?.Ime))
            queryFilter = queryFilter.Where(x => x.Ime.ToLower().Contains(search.Ime.ToLower()));

        if (!string.IsNullOrWhiteSpace(search?.Prezime))
            queryFilter = queryFilter.Where(x => x.Prezime.ToLower().Contains(search.Prezime.ToLower()));

        if (!string.IsNullOrWhiteSpace(search?.KorisnickoIme))
            queryFilter = queryFilter.Where(x => x.KorisnickoIme == search.KorisnickoIme);

        if (!string.IsNullOrWhiteSpace(search?.Email)) queryFilter = queryFilter.Where(x => x.Email == search.Email);

        if (search?.IsUlogeIncluded == true)
            queryFilter = queryFilter
                .Include(x => x.KorisniciUloges)
                .ThenInclude(x => x.Uloga);

        return queryFilter;
    }

    protected override void beforeInsert(Korisnici entity, KorisniciInsertRequest insert)
    {
        if (insert.Lozinka != insert.LozinkaPotvrda) throw new Exception("Lozinke se ne poklapaju");

        entity.LozinkaSalt = PasswordGenerator.GenerateSalt();
        entity.LozinkaHash = PasswordGenerator.GenerateHash(entity.LozinkaSalt, insert.Lozinka);

        base.beforeInsert(entity, insert);
    }

    protected override void beforeUpdate(Korisnici entity, KorisniciUpdateRequest update)
    {
        if (update.Lozinka != null)
            if (update.Lozinka != update.LozinkaPotvrda)
                throw new Exception("Lozinke se ne poklapaju");
        base.beforeUpdate(entity, update);
    }
}
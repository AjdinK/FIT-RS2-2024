using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObject;

namespace eProdaja.Services;

public interface
    IKorisnici : ICrudService<Korisnici, KorisniciSearchObject, KorisniciInsertRequest, KorisniciUpdateRequest>
{
    public Korisnici Login(string username, string password);
}
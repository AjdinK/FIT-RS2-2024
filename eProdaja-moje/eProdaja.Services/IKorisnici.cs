using eProdaja.Model.Requests;
using eProdaja.Model.SearchObject;

namespace eProdaja.Services;

public interface IKorisnici : ICrudService<Model.Korisnici , KorisniciSearchObject , KorisniciInsertRequest , KorisniciUpdateRequest>
{
}
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;

namespace eProdaja.Services {
    public interface IVrsteProizvodumService : ICRUDService<Model.VrsteProizvodum , VrsteProizvodumSearchObject, VrsteProizvodumUpsertRequest, VrsteProizvodumUpsertRequest> {
    }
}

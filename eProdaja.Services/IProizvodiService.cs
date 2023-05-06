using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;

namespace eProdaja.Services {
    public interface IProizvodiService : ICRUDService <Proizvodi , ProizvodiSearchObject , ProizvodiInsertRequest, ProizvodiUpdateRequest> {
        Model.Proizvodi Activate(int id);
    }
} 

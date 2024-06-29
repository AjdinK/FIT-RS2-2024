using eProdaja.Model.Requests;
using eProdaja.Model.SearchObject;

namespace eProdaja.Services;

public interface IProizvodi : ICrudService<Model.Proizvodi , ProizvodiSearchObject, ProizvodiInsertRequest, ProizvodiUpdateRequest>
{
    public Model.Proizvodi Activate(int id);
    public Model.Proizvodi Edit(int id);
    public Model.Proizvodi Hide(int id);
    public List<string> GetAllowedActions(int id);
}
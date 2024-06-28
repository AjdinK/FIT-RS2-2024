using eProdaja.Model.Requests;
using eProdaja.Model.SearchObject;

namespace eProdaja.Services;

public interface IProizvodi : ICrudService<Model.Proizvodi , ProizvodiSearchObject, ProizvodiInsertRequest, ProizvodiUpdateRequest>
{
}
using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public interface IProizvodiService : ICRUDService<Proizvodi, ProizvodiSearchObject, ProizvodiInsertRequest, ProizvodiUpdateRequest>
    {
        public Proizvodi Activate(int id);

        public Proizvodi Edit(int id);
        public Proizvodi Hide(int id);

        public List<string> AllowedActions(int id);

        List<Model.Proizvodi> Recommend(int id);
    }
}

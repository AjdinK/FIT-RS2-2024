using eProdaja.Model;
using eProdaja.Services.Database;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class ProizvodiService : IProizvodiService
    {
        public EProdajaContext Context { get; set; }
        public IMapper Mapper {get; set;}
        public ProizvodiService(EProdajaContext context , IMapper mapper) { 
            Context = context;
            Mapper = mapper;
        }

        public virtual List<Model.Proizvodi> GetList()
        {
            var list = Context.Proizvodis.ToList();
            var result = new List<Model.Proizvodi>();
            //list.ForEach(item => {
            //    result.Add(new Model.Proizvodi() { 
            //        ProizvodId = item.ProizvodId,
            //        Cijena = item.Cijena, 
            //        Naziv = item.Naziv
            //    });
            //});
            result = Mapper.Map(list, result);
            return result;
        }
    }
}

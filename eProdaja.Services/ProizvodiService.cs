using AutoMapper;
using eProdaja.DataBase;
using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services {
    public class ProizvodiService : IProizvodiService {

        public EProdajaContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public ProizvodiService(EProdajaContext context, IMapper mapper) {
            Context = context;
            Mapper = mapper;

        }

        public IEnumerable<Model.Proizvodi> Get() {

            List<Model.Proizvodi> lista = new List<Model.Proizvodi>();

            var rez = Context.Proizvodis.ToList();
            return Mapper.Map<List<Model.Proizvodi>>(rez);
        }

        public Model.Proizvodi GetByID(int id) {
            var rez = Context.Proizvodis.Find(id);

            return Mapper.Map<Model.Proizvodi>(rez);
        }
    }
}

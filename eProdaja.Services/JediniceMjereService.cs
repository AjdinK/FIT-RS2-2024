using AutoMapper;
using eProdaja.DataBase;
using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services {
    public class JediniceMjereService : IJediniceMjereService {

        public EProdajaContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public JediniceMjereService(EProdajaContext context, IMapper mapper) {
            Context = context;
            Mapper = mapper;

        }

        public IEnumerable<Model.JediniceMjere> Get() {
          
            var rez = Context.JediniceMjeres.ToList();
            return Mapper.Map<List<Model.JediniceMjere>>(rez);
        }

        public Model.JediniceMjere GetByID(int id) {
            var rez = Context.JediniceMjeres.Find(id);
            return Mapper.Map<Model.JediniceMjere>(rez);
        }
    }
}

using AutoMapper;
using eProdaja.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services {
    public class KorisniciService : IKorisniciService {

        public EProdajaContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public KorisniciService(EProdajaContext context , IMapper mapper) {
            Context = context;
            Mapper = mapper;

        }

        public IEnumerable<Model.Korisnici> Get() {

            List<Model.Korisnici> lista = new List<Model.Korisnici>();

            var rez =  Context.Korisnicis.ToList();

         
            return Mapper.Map<List<Model.Korisnici>>(rez);
        }
    }
}

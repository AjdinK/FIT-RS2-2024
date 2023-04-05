using eProdaja.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services {
    public class ProizvodiService : IProizvodiService {

        public EProdajaContext Context { get; set; }

        public ProizvodiService(EProdajaContext context) {
            Context = context;
        
        }

        public List<Proizvodi> ProizvodiList = new List<Proizvodi>() { new Proizvodi() { ID = 1 , Naziv = "Laptop" } ,

                new Proizvodi() { ID = 2, Naziv = "Mis" }};

        public IEnumerable<Proizvodi> Get() {

            var tmp = Context.Proizvodis.ToList();

            ProizvodiList.Add(new Proizvodi() { Naziv = "test" , ID = -1});
            return ProizvodiList;


        }

        public Proizvodi GetByID(int id ) {

            return ProizvodiList.FirstOrDefault(x => x.ID == id);

        }
    }
}

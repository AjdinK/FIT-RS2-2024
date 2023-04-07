using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services {
    public class DummyProizvodiService : IProizvodiService {


        public List<Model.Proizvodi> ProizvodiList = new List<Model.Proizvodi>() { new Model.Proizvodi() { ProizvodId = 1 , Naziv = "Laptop" } ,

                new Model.Proizvodi() { ProizvodId = 2, Naziv = "Mis" }};

        public IEnumerable<Model.Proizvodi> Get() {


            ProizvodiList.Add(new Model.Proizvodi() { Naziv = "test" , ProizvodId = -1});
            return ProizvodiList;


        }

        public Model.Proizvodi GetByID(int id ) {

            return ProizvodiList.FirstOrDefault(x => x.ProizvodId == id);

        }
    }
}

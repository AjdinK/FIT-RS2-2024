using eProdaja.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services {
    public class KorisniciService : IKorisniciService {

        public EProdajaContext Context { get; set; }
        public KorisniciService(EProdajaContext context) {
            Context = context;

        }

        public IEnumerable<Model.Korisnici> Get() {

            List<Model.Korisnici> lista = new List<Model.Korisnici>();

            var rez =  Context.Korisnicis.ToList();

            foreach ( var item in rez ) {
                lista.Add(new Model.Korisnici() {

                    KorisnikId = item.KorisnikId,
                    Ime = item.Ime,
                    KorisnickoIme = item.KorisnickoIme,
                    Email = item.Email,
                    Prezime = item.Prezime,
                    Status = item.Status,
                    Telefon = item.Telefon
                });
            }
            return lista;
        }
    }
}

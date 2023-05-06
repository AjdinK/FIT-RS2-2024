﻿using AutoMapper;
using eProdaja.DataBase;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services {
    public class KorisniciService : BaseCRUDService<Model.Korisnici , DataBase.Korisnici , KorisniciSearchObject, KorisniciInsertRequest , KorisniciUpdateRequest> , IKorisniciService {
        public KorisniciService(EProdajaContext context , IMapper mapper) : base (context , mapper) {}

        public override Model.Korisnici Insert(KorisniciInsertRequest insert) {

            var entity = base.Insert(insert);

            foreach (var ulogaId in insert.UlogeIdList) {

                DataBase.KorisniciUloge korisniciUloge = new DataBase.KorisniciUloge();
                korisniciUloge.UlogaId = ulogaId;
                korisniciUloge.KorisnikId = entity.KorisnikId;
                korisniciUloge.DatumIzmjene = DateTime.Now;
                Context.KorisniciUloges.Add(korisniciUloge);
            }

            Context.SaveChanges();
            return entity;

        }

        public override void BeforeInsert(KorisniciInsertRequest insert, Korisnici entity) {
            var salt = GenerateSalt();
            entity.LozinkaSalt = salt;
            entity.LozinkaHash = GenerateHash(salt, insert.Password);

            base.BeforeInsert(insert, entity);
        }
        public override Model.Korisnici Update(int id, KorisniciUpdateRequest update) {
            return base.Update(id, update);
        }

        public static string GenerateSalt() {
            return Convert.ToBase64String(new byte[16]);
            //TODO
            //var buf = new byte[16];
            //((new RSACryptoServiceProvider()).GetBytes(buf);
            //return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt , string password) {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

    }
}

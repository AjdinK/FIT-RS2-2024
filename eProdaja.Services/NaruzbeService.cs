using AutoMapper;
using eProdaja.DataBase;
using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Identity.Client.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services {
    public class NaruzbeService : BaseCRUDService<Model.Naruzbe, DataBase.Narudzbe, NaruzbeSearchObject, NaruzbaInsertRequest, NaruzbaUpdateRequest> {
        public NaruzbeService(EProdajaContext context, IMapper mapper) : base(context, mapper) {}
        public override void BeforeInsert(NaruzbaInsertRequest insert, Narudzbe entity) {
            entity.KupacId = 1;
            entity.Datum = DateTime.Now;
            entity.BrojNarudzbe = (Context.Narudzbes.Count() + 1).ToString();
            base.BeforeInsert(insert, entity);
        }

        public override Model.Naruzbe Insert(NaruzbaInsertRequest insert) {
            var rez = base.Insert(insert);
            foreach (var item in insert.Items)
            {
             //TODO : call context to store items    
            }
            return rez;
        }
    }
}

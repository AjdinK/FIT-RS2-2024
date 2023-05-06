using AutoMapper;
using Azure.Core;
using eProdaja.DataBase;
using eProdaja.Model.Requests;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.ProductStateMachine {
    public class DraftProductState : BaseState {
        public DraftProductState(IServiceProvider serviceProvider, EProdajaContext context, IMapper mapper) :
            base (serviceProvider , context , mapper) { }
        public override void Update (ProizvodiUpdateRequest request) {
            var set = Context.Set<DataBase.Proizvodi>();
            Mapper.Map(request, CurrentEntity);
            CurrentEntity.StateMachine = "draft";
            Context.SaveChanges();
        }
        public override void Activate() {
            CurrentEntity.StateMachine = "active";
            Context.SaveChanges();
        }
        public override List<string> AllowedActions() {
            var list = base.AllowedActions();
            list.Add("update");
            list.Add("activate");
            return list;
        }
    }
}

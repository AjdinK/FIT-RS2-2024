using AutoMapper;
using eProdaja.DataBase;
using eProdaja.Model.Requests;
using eProdaja.Services.ProductStateMachine;
using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model.ProductStateMachine {
    public class InitialProductState : BaseState {
        public InitialProductState(IServiceProvider serviceProvider, EProdajaContext Context, IMapper Mapper) :
            base(serviceProvider, Context, Mapper) { }

        public override Proizvodi Insert(ProizvodiInsertRequest request) {

            //طريقة الاولى 
            //var set = Context.Set<DataBase.Proizvodi>();
            //DataBase.Proizvodi entity = Mapper.Map<DataBase.Proizvodi>(request);
            //CurrentEntity = entity;
            //CurrentEntity.StateMachine = "draft";
            //set.Add(entity);
            //Context.SaveChanges();
            //return Mapper.Map<Model.Proizvodi>(entity);

            var entity = Mapper.Map<DataBase.Proizvodi>(request);
            entity.StateMachine = "draft";
            Context.Set<DataBase.Proizvodi>().Add(entity);
            Context.SaveChanges();
            return Mapper.Map<Model.Proizvodi>(entity);

        }
    }
}

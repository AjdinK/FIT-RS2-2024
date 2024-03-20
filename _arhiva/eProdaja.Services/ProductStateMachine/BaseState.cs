using AutoMapper;
using eProdaja.DataBase;
using eProdaja.Model.ProductStateMachine;
using eProdaja.Model.Requests;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace eProdaja.Services.ProductStateMachine {
    public class BaseState {

        public string CurrentState { get; set; }
        public DataBase.Proizvodi CurrentEntity { get; set; }
        public EProdajaContext Context { get; set; } = null;
        public IMapper Mapper { get; set; }
        public IServiceProvider ServiceProvider { get; set; }

        public BaseState(IServiceProvider serviceProvider, EProdajaContext context, IMapper mapper) {
            ServiceProvider = serviceProvider;
            Context = context;
            Mapper = mapper;
        }

        public virtual Model.Proizvodi Insert(ProizvodiInsertRequest insert) { throw new Exception("Not_Allowed"); }
        public virtual void Update(ProizvodiUpdateRequest update) { throw new Exception("Not_Allowed"); }
        public virtual void Activate() { throw new Exception("Not_Allowed"); }
        public virtual void Hide() { throw new Exception("Not_Allowed"); }
        public virtual void Delete() { throw new Exception("Not_Allowed"); }

        public BaseState CreateState(string stateName) {

            switch (stateName) {
                case "initial":
                    return ServiceProvider.GetService<InitialProductState>();
                    break;

                case "draft":
                    return ServiceProvider.GetService<DraftProductState>();

                case "active":
                    return ServiceProvider.GetService<ActiveProductState>();

                default:
                    throw new Exception("Not_Supported");
            }

        }
        public virtual List<string> AllowedActions() { return new List<string>(); }
    }
}

using eProdaja.DataBase;
using eProdaja.Model.ProductStateMachine;
using eProdaja.Model.Requests;
using System;

namespace eProdaja.Services.ProductStateMachine {
    public abstract class BaseState {

        public string CurrentState { get; set; }
        public DataBase.Proizvodi CurrentEntity { get; set; }
        public EProdajaContext Context { get; set; } = null;

        public virtual Model.Proizvodi Insert (ProizvodiInsertRequest insert) { throw new Exception("Not_Allowed"); }
        public virtual Model.Proizvodi Update (ProizvodiUpdateRequest update) { throw new Exception("Not_Allowed"); }
        public virtual void Activate () { throw new Exception("Not_Allowed"); }
        public virtual void Hide () { throw new Exception("Not_Allowed"); }
        public virtual void Delete () { throw new Exception("Not_Allowed"); }

        public static BaseState CreateState(string stateName) {

            switch (stateName) {
                case "Initial":
                    return new InitialProductState();
                    break;

                case "draft":
                    return new DraftProductState();
                    break;

                case "active":
                    return new ActiveProductState();
                    break;

                default:
                    throw new Exception("Not_Supported");
            }
        
        }
    }
}

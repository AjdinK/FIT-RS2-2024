using eProdaja.Model.Requests;
using eProdaja.Services.ProductStateMachine;
using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model.ProductStateMachine {
    public class InitialProductState : BaseState {

        public override void Insert(ProizvodiInsertRequest insert) {
            //call entity framework ....
            CurrentEntity.StateMachine = "draft";
        }
    }
}

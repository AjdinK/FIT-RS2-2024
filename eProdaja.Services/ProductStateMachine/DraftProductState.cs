using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.ProductStateMachine {
    public class DraftProductState : BaseState {
        public override void Update(ProizvodiUpdateRequest update) {
            //call data by calling EF ...
            CurrentEntity.StateMachine = "draft";
        }
        public override void Activate() {
            CurrentEntity.StateMachine = "active";
        }
    }
}

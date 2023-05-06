using AutoMapper;
using eProdaja.DataBase;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.ProductStateMachine {
    public class DraftProductState : BaseState {
        public DraftProductState(IServiceProvider serviceProvider, EProdajaContext context, IMapper mapper) :
            base (serviceProvider , context , mapper) { }

    }
}

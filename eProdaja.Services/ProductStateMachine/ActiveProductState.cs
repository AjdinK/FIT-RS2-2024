using AutoMapper;
using eProdaja.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.ProductStateMachine {
    public class ActiveProductState : BaseState {
        public ActiveProductState(IServiceProvider serviceProvider, EProdajaContext context, IMapper mapper) : 
            base (serviceProvider , context , mapper) { }
    }
}

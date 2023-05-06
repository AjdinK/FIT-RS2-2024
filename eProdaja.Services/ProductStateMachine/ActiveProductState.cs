using AutoMapper;
using eProdaja.DataBase;

namespace eProdaja.Services.ProductStateMachine {
    public class ActiveProductState : BaseState {
        public ActiveProductState(IServiceProvider serviceProvider, EProdajaContext Context, IMapper Mapper) : 
            base(serviceProvider, Context, Mapper) { }
    }
}

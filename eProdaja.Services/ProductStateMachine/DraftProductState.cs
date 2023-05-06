using AutoMapper;
using eProdaja.DataBase;

namespace eProdaja.Services.ProductStateMachine {
    public class DraftProductState : BaseState {
        public DraftProductState(IServiceProvider serviceProvider, EProdajaContext Context, IMapper Mapper) : 
            base (serviceProvider , Context , Mapper) { }


    }
}

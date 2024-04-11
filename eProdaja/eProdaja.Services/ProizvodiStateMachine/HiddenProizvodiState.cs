using eProdaja.Services.Database;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proizvodi = eProdaja.Model.Proizvodi;

namespace eProdaja.Services.ProizvodiStateMachine
{
    public class HiddenProizvodiState : BaseProizvodiState
    {
        public HiddenProizvodiState (EProdajaContext context, IMapper mapper, IServiceProvider serviceProvider)
         : base(context, mapper, serviceProvider) { }

        public override Proizvodi Edit(int id)
        {
            var set = Context.Set<Database.Proizvodi>();
            var entity = set.Find(id);
            entity.StateMachine = "draft";
            Context.SaveChanges();
            return Mapper.Map<Model.Proizvodi>(entity);
        }
    }
}

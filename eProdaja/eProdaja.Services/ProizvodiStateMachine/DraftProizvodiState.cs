using Azure.Core;
using EasyNetQ;
using eProdaja.Model.Messages;
using eProdaja.Model.Requests;
using eProdaja.Services.Database;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.ProizvodiStateMachine
{
    public class DraftProizvodiState : BaseProizvodiState
    {
        public DraftProizvodiState(EProdajaContext context, IMapper mapper, IServiceProvider serviceProvider) : base(context, mapper, serviceProvider)
        {
        }

        public override Model.Proizvodi Update(int id, ProizvodiUpdateRequest request)
        {
            var set = Context.Set<Database.Proizvodi>();

            var entity = set.Find(id);

            Mapper.Map(request, entity);

            Context.SaveChanges();

            return Mapper.Map<Model.Proizvodi>(entity);
        }

        public override Model.Proizvodi Activate(int id)
        {
            var set = Context.Set<Database.Proizvodi>();

            var entity = set.Find(id);

            entity.StateMachine = "active";

            Context.SaveChanges();

            var bus = RabbitHutch.CreateBus("host=localhost:5673");

            var mappedEntity = Mapper.Map<Model.Proizvodi>(entity);
            ProizvodiActivated message = new ProizvodiActivated { Proizvod = mappedEntity };
            bus.PubSub.Publish(message);

            return mappedEntity;

        }

        public override Model.Proizvodi Hide(int id)
        {
            var set = Context.Set<Database.Proizvodi>();

            var entity = set.Find(id);

            entity.StateMachine = "hidden";

            Context.SaveChanges();

            return Mapper.Map<Model.Proizvodi>(entity);
        }

        public override List<string> AllowedActions(Database.Proizvodi entity)
        {
            return new List<string>() { nameof(Activate), nameof(Update), nameof(Hide) };
        }
    }
}

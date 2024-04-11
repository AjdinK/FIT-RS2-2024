using Azure.Core;
using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using eProdaja.Services.ProizvodiStateMachine;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Proizvodi = eProdaja.Model.Proizvodi;

namespace eProdaja.Services
{
    public class ProizvodiService :
    BaseCRUDService<Model.Proizvodi, ProizvodiSearchObject, Database.Proizvodi, ProizvodiInsertRequest, ProizvodiUpdateRequest>,
    IProizvodiService
    {
        private ILogger<ProizvodiService> _logger;
        public BaseProizvodiState BaseProizvodiState { get; set; }

        public ProizvodiService(EProdajaContext context, IMapper mapper, BaseProizvodiState baseProizvodiState,
            ILogger<ProizvodiService> logger)
            : base(context, mapper)
        {
            BaseProizvodiState = baseProizvodiState;
            _logger = logger;
        }

        public override IQueryable<Database.Proizvodi> AddFilter(ProizvodiSearchObject search, IQueryable<Database.Proizvodi> query)
        {
            var filteredQuery = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search?.FTS))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv.Contains(search.FTS));
            }

            return filteredQuery;
        }

        public override Model.Proizvodi Insert(ProizvodiInsertRequest request)
        {
            var state = BaseProizvodiState.CreateState("initial");
            return state.Insert(request);
        }

        public override Model.Proizvodi Update(int id, ProizvodiUpdateRequest request)
        {
            var entity = GetById(id);
            var state = BaseProizvodiState.CreateState(entity.StateMachine);
            return state.Update(id, request);
        }

        public Model.Proizvodi Activate(int id)
        {
            var entity = GetById(id);
            var state = BaseProizvodiState.CreateState(entity.StateMachine);
            return state.Activate(id);
        }

        public Proizvodi Edit(int id)
        {
            var entity = GetById(id);
            var state = BaseProizvodiState.CreateState(entity.StateMachine);
            return state.Edit(id);
        }

        public Proizvodi Hide(int id)
        {
            var entity = GetById(id);
            var state = BaseProizvodiState.CreateState(entity.StateMachine);
            return state.Hide(id);
        }

        public List<string> AllowedActions(int id)
        {
            _logger.LogInformation($"Allowed Actions called for id {id}");
            
            if (id <= 0)
            {
                var state = BaseProizvodiState.CreateState("initial");
                return state.AllowedActions(null);
            }
            else
            {
                var entity = Context.Proizvodis.Find(id);
                var state = BaseProizvodiState.CreateState(entity.StateMachine);
                return state.AllowedActions(entity);
            }
        }
    }
}

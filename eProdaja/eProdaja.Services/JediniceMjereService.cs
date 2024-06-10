using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class JediniceMjereService : BaseService<Model.JediniceMjere, JediniceMjereSearchObject, Database.JediniceMjere>, IJediniceMjereService
    {

        public JediniceMjereService(EProdajaContext context, IMapper mapper)
        : base(context, mapper){ 

        }
    }
}

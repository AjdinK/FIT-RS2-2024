using AutoMapper;
using eProdaja.DataBase;
using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services {
    public class JediniceMjereService : BaseService<Model.JediniceMjere, DataBase.JediniceMjere>, IService<Model.JediniceMjere> {

        public JediniceMjereService(EProdajaContext context, IMapper mapper) : base(context, mapper) {
        }  
    }
}

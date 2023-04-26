using AutoMapper;
using eProdaja.DataBase;
using eProdaja.Model;
using eProdaja.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eProdaja.Services {
    public class JediniceMjereService : BaseService<Model.JediniceMjere, DataBase.JediniceMjere, object>, IService<Model.JediniceMjere,object> {

        public JediniceMjereService(EProdajaContext context, IMapper mapper) : base(context, mapper) {
        }  
    }
}

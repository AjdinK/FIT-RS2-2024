using AutoMapper;
using eProdaja.DataBase;
using eProdaja.Model;
using eProdaja.Model.SearchObjects;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services {
    public class ProizvodiService : BaseService<Model.Proizvodi , DataBase.Proizvodi , ProizvodiSearchObject>, IProizvodiService {

        public ProizvodiService(EProdajaContext context, IMapper mapper): base(context,mapper) {


        }
    }
}

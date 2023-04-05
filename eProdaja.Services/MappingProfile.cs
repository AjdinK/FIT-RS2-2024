using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services {
    public class MappingProfile : Profile {

        public MappingProfile() {
            CreateMap<DataBase.Korisnici, Model.Korisnici>();
        }
    }
}

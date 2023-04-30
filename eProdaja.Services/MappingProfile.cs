using AutoMapper;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<DataBase.Korisnici, Model.Korisnici>();
            CreateMap<DataBase.Proizvodi, Model.Proizvodi>();
            CreateMap<DataBase.JediniceMjere, Model.JediniceMjere>();
            CreateMap<ProizvodiInsertRequest,DataBase.Proizvodi>();
        }
    }
}

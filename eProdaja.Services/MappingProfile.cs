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
            CreateMap<ProizvodiUpdateRequest, DataBase.Proizvodi>();
            CreateMap<JediniceMjereUpsertRequest, DataBase.JediniceMjere>();
            CreateMap<VrsteProizvodumUpsertRequest, DataBase.VrsteProizvodum>();
            CreateMap<DataBase.VrsteProizvodum, Model.VrsteProizvodum>();
            CreateMap<DataBase.Korisnici, Model.Korisnici>();
            CreateMap<KorisniciInsertRequest, DataBase.Korisnici>();
            CreateMap<KorisniciUpdateRequest, DataBase.Korisnici>();
            CreateMap<DataBase.Uloge, Model.Uloge>();
            CreateMap<DataBase.KorisniciUloge, Model.KorisniciUloge>();
            CreateMap<DataBase.Narudzbe, Model.Narudzbe>();
            CreateMap<NarudzbaInsertRequest, DataBase.Narudzbe>();
            CreateMap<NarudzbaUpdateRequest, DataBase.Narudzbe>();
        }
    }
}

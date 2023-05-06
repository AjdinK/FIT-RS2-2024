using AutoMapper;
using eProdaja.Model.Requests;

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
        }
    }
}

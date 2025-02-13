using AutoMapper;
using TesteDevFullStackDbm.Data.Dtos;
using TesteDevFullStackDbm.Data.Entities;

namespace TesteDevFullStackDbm.AutoMapperConfig
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ClientDto, Client>().ReverseMap();
            CreateMap<ProtocolDto, Protocol>().ReverseMap();
            CreateMap<ProtocolFollowDto, ProtocolFollow>().ReverseMap();
            CreateMap<StatusProtocolDto, StatusProtocol>().ReverseMap();
        }
    }
}

using AutoMapper;
using NewShortAirTest.Shared.Entities;
using NewShortAirTest.Shared.Inputs;

namespace NewShortAirTest.Bussines;

public class MappingProfiles : Profile

{
    public MappingProfiles()
    {
        /*CreateMap<FlightOutput, Flight>()
        .ForMember(dto => dto.FlightCarrier, opt => opt.MapFrom(src => src.Transport.FlightCarrier))
        .ForMember(dto => dto.FlightNumber, opt => opt.MapFrom(src => src.Transport.FlightNumber))
        .ForMember(dto => dto.Price, opt => opt.MapFrom(src => src.Price))
        .ForMember(dto => dto.Origin, opt => opt.MapFrom(src => src.Origin))
        .ForMember(dto => dto.Destination, opt => opt.MapFrom(src => src.Destination));*/


        CreateMap<FlightOutput, Flight>()
        .ForMember(d => d.Origin, opt => opt.MapFrom(s => s.Origin))
        .ForMember(d => d.Destination, opt => opt.MapFrom(s => s.Destination));

        CreateMap<Transport, Flight>()
        .ForMember(d => d.FlightCarrier, opt => opt.MapFrom(s => s.FlightCarrier))
        .ForMember(d => d.FlightNumber, opt => opt.MapFrom(s => s.FlightNumber));

    }
}


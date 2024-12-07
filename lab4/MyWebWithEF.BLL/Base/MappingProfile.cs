using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Advice, AdviceDto>().ReverseMap();
    }
}

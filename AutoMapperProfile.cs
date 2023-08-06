using AutoMapper;
using CSharpRPG.DTOs.Character;
using CSharpRPG.Models;

namespace CSharpRPG
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}

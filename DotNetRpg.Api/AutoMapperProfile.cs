using AutoMapper;
using DotNetRpg.Domain.DTOs.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetRpg.Domain.Models
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

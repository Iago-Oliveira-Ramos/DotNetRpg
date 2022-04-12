using DotNetRpg.Domain.DTOs.Character;
using DotNetRpg.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetRpg.Domain.Services
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetCharacters();

        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);

        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newcharacter);

        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto character);

        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}

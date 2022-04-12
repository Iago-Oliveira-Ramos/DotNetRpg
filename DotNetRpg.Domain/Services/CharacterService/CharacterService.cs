using AutoMapper;
using DotNetRpg.Domain.DTOs.Character;
using DotNetRpg.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetRpg.Domain.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character {Id = 1, Name ="Markes" }
        };

        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newcharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newcharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character character = characters.First(c => c.Id == id);

                characters.Remove(character);

                serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedcharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = characters.FirstOrDefault(c => c.Id == updatedcharacter.Id);

                character.Name = updatedcharacter.Name;
                character.HitPoints = updatedcharacter.HitPoints;
                character.Strength = updatedcharacter.Strength;
                character.Defense = updatedcharacter.Defense;
                character.Intelligence = updatedcharacter.Intelligence;
                character.Class = updatedcharacter.Class;

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}

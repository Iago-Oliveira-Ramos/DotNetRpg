using DotNetRpg.Domain.DTOs.Character;
using DotNetRpg.Domain.Models;
using DotNetRpg.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetRpg.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class CharacterController : ControllerBase
    {


        //Injeção de dependência
        private readonly ICharacterService _characterservices;

        public CharacterController(ICharacterService characterservices)
        {
            _characterservices = characterservices;
        }

        //Retornar lista 

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetCharacters()
        {
            return Ok(await _characterservices.GetCharacters());

        }


        //Retornar apenas um

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetCharacter(int id)
        {
            var character = _characterservices.GetCharacterById(id);
            if(character == null)
            {
                return BadRequest("Character Not Found");
            }

            return Ok(await _characterservices.GetCharacterById(id));
        }


        //Adicionando um personagem

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newcharacter)
        {
            await _characterservices.AddCharacter(newcharacter);
            return Ok(await _characterservices.GetCharacters());
        }


        //Atualizando um personagem

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedcharacter)
        {
            var response = await _characterservices.UpdateCharacter(updatedcharacter);
            if(response.Data == null) return NotFound(response);
            return Ok(response);
        }

        //Deletando um personagem
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> DeleteCharacter(int id)
        {
            var response = await _characterservices.DeleteCharacter(id);
            if (response.Data == null) return NotFound(response);
            return Ok(response);
        }
    }
}

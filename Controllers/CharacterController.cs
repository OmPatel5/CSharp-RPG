﻿using CSharpRPG.DTOs.Character;
using CSharpRPG.Models;
using CSharpRPG.Services.CharacterService;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Runtime.CompilerServices;

namespace CSharpRPG.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("corspolicy")]
    public class CharacterController : ControllerBase
    {
        
        private readonly ICharacterService characterService;

        public CharacterController(ICharacterService characterService)
        {
            this.characterService = characterService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {
            return Ok(await characterService.GetAllCharacters());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
        {
            var response = await characterService.GetCharacterById(id);

            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok(await characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {

           var response = await characterService.UpdateCharacter(updatedCharacter);

           if (response.Data is null) {
                return NotFound(response);
           }

           return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> DeleteCharacter(int id)
        {
            var response = await characterService.DeleteCharacter(id);

            if (response.Data is null) { 
                return NotFound(response);
            }

            return Ok(response);

            
        }
    }
}

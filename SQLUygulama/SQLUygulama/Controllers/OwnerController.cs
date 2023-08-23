﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SQLUygulama.Dto;
using SQLUygulama.Interfaces;
using SQLUygulama.Models;
using SQLUygulama.Repository;

namespace SQLUygulama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class OwnerController : Controller
    {
        private readonly OwnerRepository _ownerRepository;
        private readonly IMapper _mapper;
        private readonly CountryRepository _countryRepository;
        public OwnerController(OwnerRepository ownerRepository, IMapper mapper,CountryRepository countryRepository
            )
        {
            _mapper = mapper;
            _ownerRepository = ownerRepository;
            _countryRepository = countryRepository;

        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetOwners()
        {
            var owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());    //Modelstate değerinin aynı türde girilip girilmediğini kontrol eder.
                                                                                                 //İnt yazan bir yere 'x' girilmişse hata verir gibi.
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);

            }
            return Ok(owners);

        }

        [HttpGet("{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]

        public IActionResult GetOwner(int ownerId)
        {
            if (!_ownerRepository.OwnerExits(ownerId))
            {
                return NotFound();
            }

            var owner = _mapper.Map<OwnerDto>(_ownerRepository.GetOwner(ownerId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(owner);
        }

        [HttpGet("{ownerId}/pokemon")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Owner))]

        public IActionResult GetPokemonByOwner(int ownerId)
        {
            if (!_ownerRepository.OwnerExits(ownerId))
            {
                return NotFound();
            }
            var pokemon=_mapper.Map<List<PokemonDto>>(
                _ownerRepository.GetPokemonByOwner(ownerId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemon);
             

        }
        [HttpGet("pokemon/{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Pokemon))]



        public IActionResult GetOwnerOfAPokemon(int pokeId)
        {
            if (!_ownerRepository.OwnerExits(pokeId))

            {
                return NotFound();
            }
            var ownerofapokemon=_mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwnerOfAPokemon(pokeId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(ownerofapokemon);

        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOwner([FromQuery] int countryId,[FromBody] OwnerDto ownerCreate)
        {
            if (ownerCreate == null)
            {
                return BadRequest(ModelState);
            }
            var owner = _ownerRepository.GetOwners()
                .Where(c => c.FirstName.Trim().ToUpper() == ownerCreate.FirstName.TrimEnd().ToUpper()).FirstOrDefault();

            if (owner != null)
            {

                ModelState.AddModelError("", "Country already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ownerMap = _mapper.Map<Owner>(ownerCreate);

            ownerMap.Country = _countryRepository.GetCountry(countryId);


            if (!_ownerRepository.CreateOwner(ownerMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfully created");


        }
        [HttpPut("{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateOwner(int ownerId, [FromBody] OwnerDto updatedOwner)
        {
            if (updatedOwner == null)
            {
                return BadRequest(ModelState);
            }
            if (ownerId != updatedOwner.Id)
            {
                return BadRequest(ModelState);
            }
            if (!_ownerRepository.OwnerExits(ownerId))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ownerMap = _mapper.Map<Owner>(updatedOwner);

            if (!_ownerRepository.UpdateOwner(ownerMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
        [HttpDelete("{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOwner(int ownerId)
        {
            if (!_ownerRepository.OwnerExits(ownerId))
            {
                return NotFound();
            }
            var ownerToDelete = _ownerRepository.GetOwner(ownerId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_ownerRepository.DeleteOwner(ownerToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting category");
            }
            return NoContent();
        }


    }
}

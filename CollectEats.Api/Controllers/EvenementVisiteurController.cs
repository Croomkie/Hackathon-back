﻿using Hackathon.Core.Interfaces;
using Hackathon.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hackathon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EvenementVisiteurController : ControllerBase
    {
        private readonly IEvenementVisiteurService _evenementVisiteurService;

        public EvenementVisiteurController(IEvenementVisiteurService evenementVisiteurService)
        {
            _evenementVisiteurService = evenementVisiteurService;
        }

        // GET: api/<EvenementVisiteurController>
        [HttpGet]
        public async Task<IEnumerable<EvenementVisiteurDTO>> Get()
        {
            return await _evenementVisiteurService.GetAll();
        }

        // GET api/<EvenementVisiteurController>/5
        [HttpGet("{id}")]
        public async Task<EvenementVisiteurDTO> Get(int id)
        {
            return await _evenementVisiteurService.GetById(id);
        }

        // POST api/<EvenementVisiteurController>
        [HttpPost]
        public async Task Post([FromBody] EvenementVisiteurDTO evenementVisiteurDTO)
        {
            await _evenementVisiteurService.Add(evenementVisiteurDTO);
        }

        // PUT api/<EvenementVisiteurController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] EvenementVisiteurDTO evenementVisiteurDTO)
        {
            await _evenementVisiteurService.Update(id, evenementVisiteurDTO);
        }

        // DELETE api/<EvenementVisiteurController>/5
        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            return _evenementVisiteurService.Delete(id);
        }
    }
}
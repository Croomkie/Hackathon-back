using Hackathon.Core.Interfaces;
using Hackathon.Data.Models;
using Hackathon.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hackathon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtelierController : ControllerBase
    {
        private readonly IAtelierService _atelierService;
        private readonly UserManager<Utilisateur> _userManager;

        public AtelierController(IAtelierService atelierService, UserManager<Utilisateur> userManager)
        {
            _atelierService = atelierService;
            _userManager = userManager;
        }


        // GET: api/<AtelierController>
        [HttpGet]
        public async Task<IEnumerable<AtelierDTO>> Get()
        {
            return await _atelierService.GetAll();
        }

        // GET api/<AtelierController>/5
        [HttpGet("{id}")]
        public async Task<AtelierDTO> Get(int id)
        {
            return await _atelierService.GetById(id);
        }

        // POST api/<AtelierController>
        [HttpPost, Authorize]
        public async Task Post([FromBody] AtelierDTO atelierDTO)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                Unauthorized("Aucun utilisateur connecté");

            await _atelierService.Add(atelierDTO);
        }

        // PUT api/<AtelierController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] AtelierDTO atelierDTO)
        {
            await _atelierService.Update(id, atelierDTO);
        }

        // DELETE api/<AtelierController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _atelierService.Delete(id);
        }
    }
}

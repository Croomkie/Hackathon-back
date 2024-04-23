using Hackathon.Core.Interfaces;
using Hackathon.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hackathon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EvenementController : ControllerBase
    {
        private readonly IEvenementService _evenementService;

        public EvenementController(IEvenementService evenementService)
        {
            _evenementService = evenementService;
        }

        // GET: api/<EvenementController>
        [HttpGet]
        public async Task<IEnumerable<EvenementDTO>> Get()
        {
            return await _evenementService.GetAll();
        }

        // GET api/<EvenementController>/5
        [HttpGet("{id}")]
        public async Task<EvenementDTO> Get(int id)
        {
            return await _evenementService.GetById(id);
        }

        // POST api/<EvenementController>
        [HttpPost]
        public async Task Post([FromBody] EvenementDTO evenementDTO)
        {
            await _evenementService.Add(evenementDTO);
        }

        // PUT api/<EvenementController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] EvenementDTO evenementDTO)
        {
            await _evenementService.Update(id, evenementDTO);
        }

        // DELETE api/<EvenementController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _evenementService.Delete(id);
        }
    }
}

using Hackathon.Core.Interfaces;
using Hackathon.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hackathon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VinController : ControllerBase
    {
        private readonly IVinService _vinService;

        public VinController(IVinService vinService)
        {
            _vinService = vinService;
        }

        // GET: api/<VinController>
        [HttpGet]
        public async Task<IEnumerable<VinDTO>> Get()
        {
            return await _vinService.GetAll();
        }

        // GET api/<VinController>/5
        [HttpGet("{id}")]
        public async Task<VinDTO> Get(int id)
        {
            return await _vinService.GetById(id);
        }

        // POST api/<VinController>
        [HttpPost]
        public async Task Post([FromBody] VinDTO vinDTO)
        {
            await _vinService.Add(vinDTO);
        }

        // PUT api/<VinController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] VinDTO value)
        {
            await _vinService.Update(id, value);
        }

        // DELETE api/<VinController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _vinService.Delete(id);
        }
    }
}

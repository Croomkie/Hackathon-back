using Hackathon.Core.Interfaces;
using Hackathon.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hackathon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcoleController : ControllerBase
    {
        private readonly IEcoleService _ecoleService;

        public EcoleController(IEcoleService ecoleService)
        {
            _ecoleService = ecoleService;
        }

        // GET: api/<EcoleController>
        [HttpGet]
        public async Task<IEnumerable<EcoleDTO>> Get()
        {
            return await _ecoleService.GetAll();
        }

        // GET api/<EcoleController>/5
        [HttpGet("{id}")]
        public async Task<EcoleDTO> Get(int id)
        {
            return await _ecoleService.GetById(id);
        }

        // POST api/<EcoleController>
        [HttpPost]
        public async Task Post([FromBody] EcoleDTO ecoleDTO)
        {
            await _ecoleService.Add(ecoleDTO);
        }

        // PUT api/<EcoleController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] EcoleDTO ecoleDTO)
        {
            await _ecoleService.Update(id, ecoleDTO);
        }

        // DELETE api/<EcoleController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _ecoleService.Delete(id);
        }
    }
}

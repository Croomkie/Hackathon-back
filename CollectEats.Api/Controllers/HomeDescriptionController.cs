using Hackathon.Core.Interfaces;
using Hackathon.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hackathon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeDescriptionController : ControllerBase
    {
        private readonly IHomeDescriptionService _homeDescriptionService;

        public HomeDescriptionController(IHomeDescriptionService homeDescriptionService)
        {
            _homeDescriptionService = homeDescriptionService;
        }

        // GET: api/<HomeDescriptionController>
        [HttpGet]
        public async Task<IEnumerable<HomeDescriptionDTO>> Get()
        {
            return await _homeDescriptionService.GetAll();
        }

        // GET api/<HomeDescriptionController>/5
        [HttpGet("{id}")]
        public async Task<HomeDescriptionDTO> Get(int id)
        {
            return await _homeDescriptionService.GetById(id);
        }

        // POST api/<HomeDescriptionController>
        [HttpPost]
        public async Task Post([FromBody] HomeDescriptionDTO homeDescriptionDTO)
        {
            await _homeDescriptionService.Add(homeDescriptionDTO);
        }

        // PUT api/<HomeDescriptionController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] HomeDescriptionDTO homeDescriptionDTO)
        {
            await _homeDescriptionService.Update(id, homeDescriptionDTO);
        }

        // DELETE api/<HomeDescriptionController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _homeDescriptionService.Delete(id);
        }
    }
}

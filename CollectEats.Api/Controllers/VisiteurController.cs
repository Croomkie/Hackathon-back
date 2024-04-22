using Hackathon.Core.Interfaces;
using Hackathon.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hackathon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisiteurController : ControllerBase
    {
        private readonly IVisiteurService _visiteurService;

        public VisiteurController(IVisiteurService visiteurService)
        {
            _visiteurService = visiteurService;
        }

        // GET: api/<VisiteurController>
        [HttpGet]
        public async Task<IEnumerable<VisiteurDTO>> Get()
        {
            return await _visiteurService.GetAll();
        }

        // GET api/<VisiteurController>/5
        [HttpGet("{id}")]
        public async Task<VisiteurDTO> Get(int id)
        {
            return await _visiteurService.GetById(id);
        }

        // POST api/<VisiteurController>
        [HttpPost]
        public async Task Post([FromBody] VisiteurDTO visiteurDTO)
        {
            await _visiteurService.Add(visiteurDTO);
        }

        // PUT api/<VisiteurController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] VisiteurDTO visiteurDTO)
        {
            await _visiteurService.Update(id, visiteurDTO);
        }

        // DELETE api/<VisiteurController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _visiteurService.Delete(id);
        }
    }
}

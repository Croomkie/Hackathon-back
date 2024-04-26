using AutoMapper;
using Hackathon.Core.Interfaces;
using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Hackathon.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hackathon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisiteurController : ControllerBase
    {
        private readonly IVisiteurService _visiteurService;
        private readonly IRepository<Visiteur> _repository;
        private readonly IMapper _mapper;

        public VisiteurController(IVisiteurService visiteurService, IRepository<Visiteur> repository, IMapper mapper)
        {
            _visiteurService = visiteurService;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/<VisiteurController>
        [HttpGet, Authorize]
        public async Task<IEnumerable<VisiteurDTO>> Get()
        {
            return _mapper.Map<IEnumerable<VisiteurDTO>>(await _repository.GetAllIncluding(v => v.Ecole!));
        }

        // GET: api/<VisiteurController>
        [HttpGet("Email/{evenementId}"), Authorize]
        public async Task<IList<string>> GetEmail(int evenementId)
        {
            return await _visiteurService.ListeEmailVisiteurEvenement(evenementId);
        }

        // GET api/<VisiteurController>/5
        [HttpGet("{id}")]
        public async Task<VisiteurDTO> Get(int id)
        {
            var listVisiteur = _mapper.Map<IEnumerable<VisiteurDTO>>(await _repository.GetAllIncluding(v => v.Ecole!));
            return listVisiteur.FirstOrDefault(v => v.VisiteurId == id)!;
        }

        // POST api/<VisiteurController>
        [HttpPost]
        public async Task Post([FromBody] VisiteurDTO visiteurDTO)
        {
            await _visiteurService.Add(visiteurDTO);
        }

        // PUT api/<VisiteurController>/5
        [HttpPut("{id}"), Authorize]
        public async Task Put(int id, [FromBody] VisiteurDTO visiteurDTO)
        {
            await _visiteurService.Update(id, visiteurDTO);
        }

        // DELETE api/<VisiteurController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task Delete(int id)
        {
            await _visiteurService.Delete(id);
        }
    }
}

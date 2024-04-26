using Hackathon.Core.Interfaces;
using Hackathon.DTOs;
using Hackathon.Shared.Enum;
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
            return await _evenementVisiteurService.GetEvenementVisiteur();
        }

        // GET api/<EvenementVisiteurController>/5
        [HttpGet("{visiteurId}/{evenementId}")]
        public async Task<EvenementVisiteurDTO> Get(int visiteurId, int evenementId)
        {
            var listEvenementVisiteur = await _evenementVisiteurService.GetEvenementVisiteur();
            return listEvenementVisiteur.FirstOrDefault(x => x.VisiteurId == visiteurId && x.EvenementId == evenementId)!;
        }

        // GET api/<EvenementVisiteurController>/5
        [HttpGet("{evenementId}"), AllowAnonymous]
        public async Task<IEnumerable<EvenementVisiteurDTO>> Get(int evenementId)
        {
            var listEvenementVisiteur = await _evenementVisiteurService.GetEvenementVisiteur();
            return listEvenementVisiteur.Where(x => x.EvenementId == evenementId)!;
        }

        // POST api/<EvenementVisiteurController>
        [HttpPost]
        public async Task Post(string email, int evenementId, int? ecoleId)
        {
            await _evenementVisiteurService.CreateEvenementVisiteur(email, evenementId, ecoleId);
        }

        // PUT api/<EvenementVisiteurController>/5
        [HttpPut]
        public async Task Put(int evenementId, int visiteurId, Status status)
        {
            await _evenementVisiteurService.UpdateEvenementVisiteur(evenementId, visiteurId, status);
        }

        // DELETE api/<EvenementVisiteurController>/5
        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            return _evenementVisiteurService.Delete(id);
        }
    }
}

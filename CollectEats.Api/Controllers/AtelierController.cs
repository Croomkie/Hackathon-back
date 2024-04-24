using AutoMapper;
using Hackathon.Core.Interfaces;
using Hackathon.Data.Interfaces;
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
        private readonly IRepository<Atelier> _repository;
        protected readonly IMapper _mapper;

        public AtelierController(IAtelierService atelierService, UserManager<Utilisateur> userManager, IRepository<Atelier> repository, IMapper mapper)
        {
            _atelierService = atelierService;
            _userManager = userManager;
            _repository = repository;
            _mapper = mapper;
        }


        // GET: api/<AtelierController>
        [HttpGet]
        public async Task<IEnumerable<AtelierDTO>> Get()
        {
            return _mapper.Map<IEnumerable<AtelierDTO>>(await _repository.GetAllIncluding(x => x.Image!));
        }

        // GET api/<AtelierController>/5
        [HttpGet("{id}")]
        public async Task<AtelierDTO> Get(int id)
        {
            var listAtelier = _mapper.Map<IEnumerable<AtelierDTO>>(await _repository.GetAllIncluding(x => x.Image!));
            return listAtelier.FirstOrDefault(x => x.AtelierId == id)!;
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
        [HttpPut("{id}"), Authorize]
        public async Task Put(int id, [FromBody] AtelierDTO atelierDTO)
        {
            await _atelierService.Update(id, atelierDTO);
        }

        // DELETE api/<AtelierController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task Delete(int id)
        {
            await _atelierService.Delete(id);
        }

        [HttpPut("{atelierId}/uploadimages"), Authorize]
        public async Task UploadImages(int atelierId, IFormFileCollection imageFiles)
        {
            await _atelierService.UpdateImageAtelier(atelierId, imageFiles);
        }
    }
}

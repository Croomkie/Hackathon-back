using Hackathon.Core.Interfaces;
using Hackathon.Core.Services;
using Hackathon.Data.Models;
using Hackathon.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hackathon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImageEvenementController : ControllerBase
    {
        private readonly IImageEvenementService _imageEvenementService;

        public ImageEvenementController(IImageEvenementService imageEvenementService)
        {
            _imageEvenementService = imageEvenementService;
        }

        // GET: api/<ImageEvenementController>
        [HttpGet]
        public async Task<IEnumerable<ImageEvenementDTO>> Get()
        {
            return await _imageEvenementService.GetAll();
        }

        // GET api/<ImageEvenementController>/5
        [HttpGet("{id}")]
        public async Task<ImageEvenementDTO> Get(int id)
        {
            return await _imageEvenementService.GetById(id);
        }

        // POST api/<ImageEvenementController>
        [HttpPost]
        public async Task Post([FromBody] ImageEvenementDTO imageEvenementDTO)
        {
            await _imageEvenementService.Add(imageEvenementDTO);
        }

        // PUT api/<ImageEvenementController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ImageEvenementDTO imageEvenementDTO)
        {
            await _imageEvenementService.Update(id, imageEvenementDTO);
        }

        // DELETE api/<ImageEvenementController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _imageEvenementService.Delete(id);
        }

        // PUT api/<ImageEvenementController>/5
        [HttpPost("{evenementId}"), Authorize]
        public async Task UploadImages(int evenementId, IFormFileCollection imageFiles)
        {
            await _imageEvenementService.UpdateImageEvenement(evenementId, imageFiles);
        }
    }
}

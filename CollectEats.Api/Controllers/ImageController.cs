using Hackathon.Core.Interfaces;
using Hackathon.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hackathon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        // GET: api/<ImageController>
        [HttpGet]
        public async Task<IEnumerable<ImageDTO>> Get()
        {
            return await _imageService.GetAll();
        }

        // GET api/<ImageController>/5
        [HttpGet("{id}")]
        public async Task<ImageDTO> Get(int id)
        {
            return await _imageService.GetById(id);
        }

        // POST api/<ImageController>
        [HttpPost]
        public async Task Post([FromBody] ImageDTO imageDTO)
        {
            await _imageService.Add(imageDTO);
        }

        // PUT api/<ImageController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ImageDTO imageDTO)
        {
            await _imageService.Update(id, imageDTO);
        }

        // DELETE api/<ImageController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _imageService.Delete(id);
        }
    }
}

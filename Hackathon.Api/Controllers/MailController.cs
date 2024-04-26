using Hackathon.Core.Interfaces;
using Hackathon.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;

        public MailController(IMailService mailService, IConfiguration configuration)
        {
            _mailService = mailService;
            _configuration = configuration;
        }

        [HttpPost, Authorize]
        public async Task Post([FromForm] MailDTO mailDTO)
        {
            string? email = _configuration["Smtp:email"];
            if(string.IsNullOrEmpty(email))
                throw new Exception("Email not found in configuration");

            string? password = _configuration["Smtp:password"];
            if (string.IsNullOrEmpty(password))
                throw new Exception("Password not found in configuration");

            await _mailService.SendMailAsync(mailDTO, email, password);
        }
    }
}

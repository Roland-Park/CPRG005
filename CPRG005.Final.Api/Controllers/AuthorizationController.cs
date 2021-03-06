using AutoMapper;
using CPRG005.Final.Api.ViewModels.Authorize;
using CPRG005.Final.BLL.Repositories;
using CPRG005.Final.BLL.Services;
using CPRG005.Final.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CPRG005.Final.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationRepository authorizeRepository;
        private readonly IHashingService hashingService;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;
        
        public AuthorizationController(IAuthorizationRepository authorizeRepository, IMapper mapper, IHashingService hashingService, ITokenService tokenService)
        {
            this.authorizeRepository = authorizeRepository;
            this.mapper = mapper;
            this.hashingService = hashingService;
            this.tokenService = tokenService;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            try
            {
                if (loginModel == null)
                    return BadRequest("Invalid client request");

                var authorization = await authorizeRepository.GetByUserName(loginModel.UserName);
                
                if (authorization == null)
                    return BadRequest("That username does not exist");

                if (hashingService.CheckHash(authorization.Password, loginModel.Password))
                {
                    var tokenString = tokenService.CreateToken(authorization);
                    return Ok(new { Token = tokenString, UserId = authorization.CustomerId  });
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<string> AddAuthorize([FromBody] AuthorizeCreateViewModel model)
        {
            var authorization = mapper.Map<Authorize>(model);
            var successMessage = await authorizeRepository.Create(authorization);

            return successMessage;
        }
    }
}

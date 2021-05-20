using AutoMapper;
using CPRG005.Final.Api.ViewModels.Authorize;
using CPRG005.Final.BLL.Repositories;
using CPRG005.Final.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CPRG005.Final.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationRepository authorizeRepository;
        private readonly IMapper mapper;
        public AuthorizationController(IAuthorizationRepository authorizeRepository, IMapper mapper)
        {
            this.authorizeRepository = authorizeRepository;
            this.mapper = mapper;
        }

        [HttpPut]
        public async Task<string> UpdateAuthorize([FromBody] AuthorizeDisplayViewModel model)
        {
            var authorization = mapper.Map<Authorize>(model);
            var successMessage = await authorizeRepository.Edit(authorization.Id, authorization);

            return successMessage;
        }

        [HttpPost]
        public async Task<string> AddAuthorize([FromBody] AuthorizeDisplayViewModel model)
        {
            var authorization = mapper.Map<Authorize>(model);
            var successMessage = await authorizeRepository.Create(authorization);

            return successMessage;
        }

        [HttpGet("{username}/{password}")]
        public async Task<AuthorizeDisplayViewModel> Authorize(string username, string password)
        {
            var authorization = await authorizeRepository.GetForCredentials(username, password);
            var model = mapper.Map<AuthorizeDisplayViewModel>(authorization);

            return model;
        }
    }
}

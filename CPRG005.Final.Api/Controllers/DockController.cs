using AutoMapper;
using CPRG005.Final.Api.ViewModels.Dock;
using CPRG005.Final.BLL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CPRG005.Final.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DockController : ControllerBase
    {
        private readonly IDockRepository dockRepository;
        private readonly IMapper mapper;
        public DockController(IDockRepository dockRepository, IMapper mapper)
        {
            this.dockRepository = dockRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<DockDisplayViewModel>> GetAllDocks()
        {
            var docks = await dockRepository.GetAll();
            var model = mapper.Map<List<DockDisplayViewModel>>(docks);

            return model;
        }
    }
}

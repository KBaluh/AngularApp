using System.Threading.Tasks;
using DBRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AngularApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeRepository _repository;

        public HomeController(IHomeRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Home
        [HttpGet("[action]")]
        public async Task<HomeModel> GetHomeData()
        {
            return await _repository.GetHomeData();
        }
    }
}
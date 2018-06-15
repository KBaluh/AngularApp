using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AngularApp.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private ITaskRepository repository;

        public TaskController(ITaskRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("[action]")]
        public async Task<List<TaskModel>> GetAll()
        {
            return await repository.GetAll();
        }

        [HttpPost("[action]")]
        public async Task Append([FromBody]TaskModel model)
        {
            await repository.Append(model);
        }
    }
}
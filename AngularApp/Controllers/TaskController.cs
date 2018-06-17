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
        public async Task<List<TaskListModel>> GetAll()
        {
            var result = await repository.GetAll();
            return result;
        }

        [HttpGet("[action]")]
        public async Task<TaskModel> GetById(int id)
        {
            return await repository.GetById(id);
        }

        [HttpPost("[action]")]
        public async Task Append([FromBody]TaskModel model)
        {
            await repository.Append(model);
        }

        [HttpPost("[action]")]
        public async Task Update([FromBody]TaskModel model)
        {
            await repository.Update(model);
        }

        [HttpPost("[action]")]
        public async Task RemoveById(int id)
        {
            await repository.RemoveById(id);
        }

        /*[HttpGet("[action]")]
        public async Task<List<TaskStatusModel>> GetStatuses()
        {
            return await repository.GetStatuses();
        }*/
    }
}
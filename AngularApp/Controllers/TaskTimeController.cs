using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AngularApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskTimeController : ControllerBase
    {
        private ITaskTimeRepository _repository;

        public TaskTimeController(ITaskTimeRepository repository)
        {
            _repository = repository;
        }

        // GET: api/TaskTime
        [HttpGet]
        public IEnumerable<TaskTime> Get()
        {
            NotFound();
            return null;
        }

        // GET: api/TaskTime/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<List<TaskTime>> GetAsync(int id)
        {
            return await _repository.GetByTaskId(id);
        }

        // POST: api/TaskTime
        [HttpPost]
        public void Post([FromBody] TaskTime value)
        {
        }

        // PUT: api/TaskTime/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TaskTime value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.RemoveById(id);
        }
    }
}

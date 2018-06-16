using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBRepository;
using Models;
using DBRepository.Interfaces;

namespace AngularApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskStatusModelsController : ControllerBase
    {
        //private readonly RepositoryContext _context;
        private readonly ITaskStatusRepository _repository;

        public TaskStatusModelsController(ITaskStatusRepository repository)
        {
            //_context = context;
            _repository = repository;
        }

        // GET: api/TaskStatusModels
        [HttpGet]
        public async Task<IEnumerable<TaskStatusModel>> GetTaskStatusModels()
        {
            return await _repository.GetAllAsync();
        }

        // GET: api/TaskStatusModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskStatusModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taskStatusModel = await _repository.GetById(id);

            if (taskStatusModel == null)
            {
                return NotFound();
            }

            return Ok(taskStatusModel);
        }

        // PUT: api/TaskStatusModels/5
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutTaskStatusModel([FromRoute] int id, [FromBody] TaskStatusModel taskStatusModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskStatusModel.TaskStatusModelId)
            {
                return BadRequest();
            }

            _context.Entry(taskStatusModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskStatusModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // POST: api/TaskStatusModels
        /*[HttpPost]
        public async Task<IActionResult> PostTaskStatusModel([FromBody] TaskStatusModel taskStatusModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TaskStatusModels.Add(taskStatusModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskStatusModel", new { id = taskStatusModel.TaskStatusModelId }, taskStatusModel);
        }*/

        // DELETE: api/TaskStatusModels/5
        /*[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskStatusModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taskStatusModel = await _context.TaskStatusModels.FindAsync(id);
            if (taskStatusModel == null)
            {
                return NotFound();
            }

            _context.TaskStatusModels.Remove(taskStatusModel);
            await _context.SaveChangesAsync();

            return Ok(taskStatusModel);
        }

        private bool TaskStatusModelExists(int id)
        {
            return _context.TaskStatusModels.Any(e => e.TaskStatusModelId == id);
        }*/
    }
}
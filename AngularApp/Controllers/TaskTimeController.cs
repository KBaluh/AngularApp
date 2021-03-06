﻿using System;
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
        public async Task PutAsync(int id, [FromBody] TaskTime model)
        {
            await _repository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _repository.RemoveById(id);
        }

        [HttpGet("[action]/{taskModelId}")]
        public async Task<bool> HaveOpenedTime(int taskModelId)
        {
            return await _repository.HaveOpenedTime(taskModelId);
        }

        [HttpGet("[action]/{taskModelId}")]
        public async Task CloseOpened(int taskModelId)
        {
            await _repository.CloseOpened(taskModelId);
        }

        [HttpPost("[action]")]
        public async Task OpenTime([FromBody] int taskModelId)
        {
            await _repository.OpenTime(taskModelId);
        }
    }
}

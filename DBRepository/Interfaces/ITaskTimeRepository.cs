﻿using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBRepository.Interfaces
{
    public interface ITaskTimeRepository
    {
        Task<List<TaskTime>> GetByTaskId(int taskId);
        Task Append(TaskTime model);
        Task Update(TaskTime model);
        Task RemoveById(int id);
    }
}

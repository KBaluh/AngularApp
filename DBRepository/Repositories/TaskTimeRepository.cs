using DBRepository.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DBRepository.Repositories
{
    public class TaskTimeRepository : BaseRepository, ITaskTimeRepository
    {
        public TaskTimeRepository(string connectionString, IRepositoryContextFactory contextFactory) 
            : base(connectionString, contextFactory)
        {
        }

        public async Task<List<TaskTime>> GetByTaskId(int taskId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.TaskTimes.Where(x => x.TaskModelId == taskId).ToListAsync();
            }
        }

        public async Task Append(TaskTime model)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                await context.TaskTimes.AddAsync(model);
            }
        }

        public async Task Update(TaskTime model)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                context.TaskTimes.Update(model);
                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveById(int id)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var entity = await context.TaskTimes.FindAsync(id);
                context.TaskTimes.Remove(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}

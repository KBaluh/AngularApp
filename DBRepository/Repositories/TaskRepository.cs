using DBRepository.Interfaces;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DBRepository.Repositories
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {
        public TaskRepository(string connectionString, IRepositoryContextFactory contextFactory)
            : base(connectionString, contextFactory) { }

        public async Task<List<TaskListModel>> GetAll()
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var query = context.Tasks.AsQueryable();
                query = query
                    .Take(100)
                    .OrderByDescending(x => x.CreatedDate)
                    .Join(context.TaskStatusModels, task => task.TaskStatusModelId, status => status.TaskStatusModelId, 
                    (task, status) => new TaskListModel
                    {
                        TaskModelId = task.TaskModelId,
                        Title = task.Title,
                        Body = task.Body,
                        CreatedDate = task.CreatedDate,
                        StartDate = task.StartDate,
                        EndDate = task.EndDate,
                        TaskStatusModelId = task.TaskStatusModelId,
                        TaskStatusModelName = status.TaskStatusModelName
                    });
                return await query.Cast<TaskListModel>().ToListAsync();
            }
        }

        public async Task<TaskModel> GetById(int id)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var query = context.Tasks.AsQueryable();
                return await query.FirstOrDefaultAsync(x => x.TaskModelId == id);
            }
        }

        public async Task Append(TaskModel model)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                context.Tasks.Add(model);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(TaskModel model)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                context.Tasks.Update(model);
                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveById(int id)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                TaskModel model = await context.Tasks.FirstOrDefaultAsync(x => x.TaskModelId == id);
                context.Tasks.Remove(model);
                await context.SaveChangesAsync();
            }
        }
    }
}

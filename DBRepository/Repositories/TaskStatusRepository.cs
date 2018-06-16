using DBRepository.Interfaces;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DBRepository.Repositories
{
    public class TaskStatusRepository : BaseRepository, ITaskStatusRepository
    {
        public TaskStatusRepository(string connectionString, IRepositoryContextFactory contextFactory) 
            : base(connectionString, contextFactory)
        {
        }

        public async Task<List<TaskStatusModel>> GetAllAsync()
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.TaskStatusModels.AsQueryable().ToListAsync();
            }
        }

        public async Task<TaskStatusModel> GetById(int id)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.TaskStatusModels.FindAsync(id);
            }
        }
    }
}

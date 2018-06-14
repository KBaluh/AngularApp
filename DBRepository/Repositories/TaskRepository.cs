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

        public async Task<List<TaskModel>> GetAll()
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var query = context.Tasks.AsQueryable();
                query = query.Take(100).OrderBy(x => x.CreatedDate);
                return await query.ToListAsync();
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
    }
}

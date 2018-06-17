using DBRepository.Interfaces;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DBRepository.Repositories
{
    public class HomeRepository : BaseRepository, IHomeRepository
    {
        public HomeRepository(string connectionString, IRepositoryContextFactory contextFactory) 
            : base(connectionString, contextFactory)
        {
        }

        public async Task<HomeModel> GetHomeData()
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                HomeModel model = new HomeModel();
                var query = context.Tasks.AsQueryable();
                model.TaskNotStarted = await query.CountAsync(t => t.TaskStatusModelId == 1);
                model.TaskInProgress = await query.CountAsync(t => t.TaskStatusModelId == 2);
                model.TaskCompleted = await query.CountAsync(t => t.TaskStatusModelId == 3);
                return model;
            }
        }
    }
}

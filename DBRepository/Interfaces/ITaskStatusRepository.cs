using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DBRepository.Interfaces
{
    public interface ITaskStatusRepository
    {
        Task<List<TaskStatusModel>> GetAllAsync();
        Task<TaskStatusModel> GetById(int id);
    }
}

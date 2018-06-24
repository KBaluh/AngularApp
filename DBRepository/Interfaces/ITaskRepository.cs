using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBRepository.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskListModel>> GetAll();
        Task<List<TaskListModel>> GetActive();
        Task<List<TaskListModel>> GetCompleted();
        Task<TaskModel> GetById(int id);
        Task Append(TaskModel model);
        Task Update(TaskModel model);
        Task RemoveById(int id);
    }
}

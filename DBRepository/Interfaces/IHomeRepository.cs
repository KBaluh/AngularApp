using Models;
using System.Threading.Tasks;

namespace DBRepository.Interfaces
{
    public interface IHomeRepository
    {
        Task<HomeModel> GetHomeData();
    }
}

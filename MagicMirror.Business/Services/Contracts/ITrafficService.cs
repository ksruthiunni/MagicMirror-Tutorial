using MagicMirror.Business.Models;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services.Contracts
{
    public interface ITrafficService : IService<TrafficModel>
    {
        Task<TrafficModel> GetTrafficModel(string start, string destination);
    }
}
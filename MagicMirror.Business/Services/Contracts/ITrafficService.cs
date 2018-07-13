using System.Threading.Tasks;
using MagicMirror.Business.Models;

namespace MagicMirror.Business.Services.Contracts
{
    public interface ITrafficService: IService<TrafficModel>
    {
        Task<TrafficModel> GetTrafficModel(string start, string destination);
    }
}
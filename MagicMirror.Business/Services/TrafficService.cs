using System.Threading.Tasks;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Repos;

namespace MagicMirror.Business.Services
{
    public class TrafficService : Service<TrafficModel>
    {
        private readonly ITrafficRepo _repo;

        public TrafficService(ITrafficRepo repo)
        {
            _repo = repo;
        }

        public async Task<TrafficModel> GetTrafficModel(string start, string destination)
        {
            var entity = await _repo.GetTrafficInfoAsync(start, destination);
            var model = MapFromEntity(entity);
            model.ConvertValues();

            return model;
        }
    }
}

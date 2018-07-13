using System.Threading.Tasks;
using MagicMirror.Business.Models;

namespace MagicMirror.Business.Services.Contracts
{
    public interface IWeatherService: IService<WeatherModel>
    {
        Task<WeatherModel> GetWeatherModel(string city);
    }
}
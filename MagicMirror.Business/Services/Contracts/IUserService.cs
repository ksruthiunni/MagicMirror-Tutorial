using MagicMirror.Business.Models;

namespace MagicMirror.Business.Services.Contracts
{
    public interface IUserService : IService<WeatherModel>
    {
        UserInformation GetUserInformation(int id);

        void StoreUserInformation(UserInformation information);

        void UpdateInformation(int id, UserInformation information);

        void DeleteInformation(int id);
    }
}

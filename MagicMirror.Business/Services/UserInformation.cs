using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Repos;
using MagicMirror.DataAccess.Entities.Entities;

namespace MagicMirror.Business.Services
{
    public class UserService: Service<UserInformation>
    {
        private readonly IUserRepo _repo;

        public UserService(IUserRepo repo)
        {
            _repo = repo;
        }

        private UserEntity MapToEntity(UserInformation model)
        {
            var entity = Mapper.Map<UserEntity>(model);
            return entity;
        }

        public void LoadUserInformation(int id)
        {
            UserEntity entity = _repo.GetUserInformation(id);
            UserInformation model = MapFromEntity(entity);

            UserInformation.Instance.DistanceUom = model.DistanceUom;
            UserInformation.Instance.Address = model.Address;
            UserInformation.Instance.Id = id;
            UserInformation.Instance.Name = model.Name;
            UserInformation.Instance.TemperatureUom = model.TemperatureUom;
            UserInformation.Instance.WorkAddress = model.WorkAddress;
        }

        public void StoreUserInformation(UserInformation information)
        {
            UserEntity entity = MapToEntity(information);
            _repo.StoreUserInformation(entity);
        }

        public void UpdateInformation(int id, UserInformation information)
        {
            UserEntity entity = MapToEntity(information);
            _repo.UpdateInformation(id, entity);
        }

        public void DeleteInformation(int id)
        {
            _repo.DeleteInformation(id);
        }
    }
}

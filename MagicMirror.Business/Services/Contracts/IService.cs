using MagicMirror.DataAccess.Entities.Entities;

namespace MagicMirror.Business.Services.Contracts
{
    public interface IService<T>
    {
        T MapFromEntity(Entity entity);
    }
}

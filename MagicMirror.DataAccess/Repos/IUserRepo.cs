using System;
using System.Collections.Generic;
using System.Text;
using MagicMirror.DataAccess.Entities.Entities;

namespace MagicMirror.DataAccess.Repos
{
    public interface IUserRepo
    {
        UserEntity GetUserInformation(int id);

        void StoreUserInformation(UserEntity information);

        void UpdateInformation(int id, UserEntity information);

        void DeleteInformation(int id);
    }
}

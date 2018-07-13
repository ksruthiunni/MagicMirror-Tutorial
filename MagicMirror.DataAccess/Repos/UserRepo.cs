using System;
using System.Collections.Generic;
using System.Text;
using MagicMirror.DataAccess.Entities.Entities;

namespace MagicMirror.DataAccess.Repos
{
    public class UserRepo: IUserRepo
    {
        public UserEntity GetUserInformation(int id)
        {
            throw new NotImplementedException();
        }

        public void StoreUserInformation(UserEntity information)
        {
            throw new NotImplementedException();
        }

        public void UpdateInformation(int id, UserEntity information)
        {
            throw new NotImplementedException();
        }

        public void DeleteInformation(int id)
        {
            throw new NotImplementedException();
        }
    }
}

using NebulaLearning.Entities.Net4x.ComplexTypes;
using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;

namespace NebulaLearning.Business.Net4x.Abstract
{
    // TODO Entity 6 : User için IUserService yazılır.
    public interface IUserService
    {
        User GetUserByUserNameAndPassword(string userName, string password);
        // TODO Complex Type : Step 8
        List<UserRoleItem> GetUserRoles(User user);
    }
}

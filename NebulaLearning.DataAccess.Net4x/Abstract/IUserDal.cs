using NebulaLearning.Core.Net4x.DataAccess;
using NebulaLearning.Entities.Net4x.ComplexTypes;
using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;

namespace NebulaLearning.DataAccess.Net4x.Abstract
{
    // TODO Entity 2 : IUserDal public interface yapılır ve Core katmanından IEntityRepository den implemente edilir. User türü ile çalışılır
    public interface IUserDal:IEntityRepository<User>
    {
        // TODO Complex Type : Step 2
        List<UserRoleItem> GetUserRoles(User user);
    }
}

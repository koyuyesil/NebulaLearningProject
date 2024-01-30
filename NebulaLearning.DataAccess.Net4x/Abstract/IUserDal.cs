using NebulaLearning.Core.Net4x.DataAccess;
using NebulaLearning.Entities.Net4x.ComplexTypes;
using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;

namespace NebulaLearning.DataAccess.Net4x.Abstract
{
    // TODO Entity 2 : User için IUserDal yazılır. Standart dışı işlemler burada soyutlanır.
    public interface IUserDal:IEntityRepository<User>
    {
        // TODO Complex Type : Step 2
        List<UserRoleItem> GetUserRoles(User user);
        // First Complex Type here, buraya yazılan methodlar Concrete klasoundeki miras alanlar implemente eder.
    }
}

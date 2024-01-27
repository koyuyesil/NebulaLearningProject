using NebulaLearning.Core.Net4x.DataAccess.EntityFramework;
using NebulaLearning.DataAccess.Net4x.Abstract;
using NebulaLearning.Entities.Net4x.ComplexTypes;
using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;
using System.Linq;


namespace NebulaLearning.DataAccess.Net4x.Concrete.EntityFramework
{
    // TODO Entity 3 : UserDal public nesnesi yapılır.
    // ve EntityFramework için aynı namespacedeki RepositoryBase den implemente edilir.
    // Tür ve Contex ile çalışılır. IUserDal dan kalıtım alınır.
    public class UserDal : RepositoryBase<User, DatabaseContex>, IUserDal
    {
        // TODO Complex Type : Step 3
        public List<UserRoleItem> GetUserRoles(User user)
        {
            using (DatabaseContex context = new DatabaseContex())
            {
                var result = from ur in context.UserRoles
                             join r in context.Roles
                             on ur.UserId equals user.Id
                             where ur.UserId == user.Id
                             select new UserRoleItem { RoleName = r.Name };
                var roleitems= result.ToList();
                return roleitems;//yanlış tüm roller geliyor
            }
        }
    }
}

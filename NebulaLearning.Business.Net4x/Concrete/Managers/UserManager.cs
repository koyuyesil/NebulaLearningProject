using NebulaLearning.Business.Net4x.Abstract;
using NebulaLearning.DataAccess.Net4x.Abstract;
using NebulaLearning.Entities.Net4x.ComplexTypes;
using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;

namespace NebulaLearning.Business.Net4x.Concrete.Managers
{
    // TODO Entity 7 : User için UserManager yazılır ve IUserService den implemente edilir.
    public class UserManager : IUserService
    {
        // TODO Entity 8 : IUserDal eklenmeli ASPECTLERİ ASSSEMBLYDEN YAPMAYI UNUTMA
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public User GetUserByUserNameAndPassword(string userName, string password)
        {
            // Core katmanındaki Contex'deki Get komutu ve expression
            return _userDal.Get(u=>u.UserName == userName && u.Password == password);
        }
        // TODO Complex Type : Step 9
        public List<UserRoleItem> GetUserRoles(User user)
        {
            // DataAccess katmanındaki Contex'deki GetUserRoles sorgu manuel yazılır.
            return _userDal.GetUserRoles(user);
        }
    }
}

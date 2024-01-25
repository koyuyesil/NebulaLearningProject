using NebulaLearning.Business.Net4x.Abstract;
using NebulaLearning.DataAccess.Net4x.Abstract;
using NebulaLearning.Entities.Net4x.Concrete;

namespace NebulaLearning.Business.Net4x.Concrete.Managers
{
    // TODO Entity 7 : User için UserManager yazılır ve IUserService den implemente edilir.
    public class UserManager : IUserService
    {
        // TODO Entity 7 : IUserDal eklenmeli
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetUserByUserNameAndPassword(string userName, string password)
        {
            // database contexteki get komutu ve expression
            return _userDal.Get(u=>u.UserName == userName && u.Password == password);
        }
    }
}

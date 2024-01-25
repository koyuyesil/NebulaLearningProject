using NebulaLearning.Entities.Net4x.Concrete;

namespace NebulaLearning.Business.Net4x.Abstract
{
    // TODO Entity 6 : User için IUserService yazılır.
    public interface IUserService
    {
        User GetUserByUserNameAndPassword(string userName, string password);
    }
}

using NebulaLearning.Core.Net4x.DataAccess;
using NebulaLearning.Entities.Net4x.Concrete;

namespace NebulaLearning.DataAccess.Net4x.Abstract
{
    // TODO Entity 2 : IUserDal public interface yapılır ve Core katmanından IEntityRepository den implemente edilir. User türü ile çalışılır
    public interface IUserDal:IEntityRepository<User>
    {
    }
}

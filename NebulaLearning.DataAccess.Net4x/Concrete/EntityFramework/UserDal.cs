using NebulaLearning.Core.Net4x.DataAccess.EntityFramework;
using NebulaLearning.DataAccess.Net4x.Abstract;
using NebulaLearning.Entities.Net4x.Concrete;


namespace NebulaLearning.DataAccess.Net4x.Concrete.EntityFramework
{
    // TODO Entity 3 : UserDal public nesnesi yapılır.
    // ve EntityFramework için aynı namespacedeki RepositoryBase den implemente edilir.
    // Tür ve Contex ile çalışılır. IUserDal dan kalıtım alınır.
    public class UserDal:RepositoryBase<User,DatabaseContex>,IUserDal
    {
    }
}

using NebulaLearning.Core.Net4x.Entities;

namespace NebulaLearning.Entities.Net4x.Concrete
{
    // TODO Entity 1 : User public nesnesi yapılır ve IEntity den implemente edilir.
    public class User:IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}

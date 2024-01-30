using NebulaLearning.Core.Net4x.Entities;

namespace NebulaLearning.Entities.Net4x.Concrete
{
    // TODO Entity 1 : User public nesnesi yapılır ve IEntity den implemente edilir.
    // Propertyler get set olsun yoksa hatayı zor bulursun.
    // Burada virtual keywordu NHibernate için zorunludur. EntityFramework için sorun yok
    public class User:IEntity
    {
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
    }
}

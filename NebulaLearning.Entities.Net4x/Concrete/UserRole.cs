using NebulaLearning.Core.Net4x.Entities;

namespace NebulaLearning.Entities.Net4x.Concrete
{
    // TODO Complex Type : Step 5
    public class UserRole:IEntity
    {
        public virtual int Id { get; set; }
        public virtual int RoleId { get; set; }
        public virtual int UserId { get; set; }
    }
}

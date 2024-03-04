using NebulaLearning.Core.Net4x.Entities;

namespace NebulaLearning.Entities.Net4x.Concrete
{
    public class Exam : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Duration { get; set; }
        public virtual int Result { get; set; }
        public virtual int CategoryId { get; set; }
    }
}
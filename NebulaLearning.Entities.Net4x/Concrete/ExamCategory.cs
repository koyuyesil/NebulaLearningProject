using NebulaLearning.Core.Net4x.Entities;

namespace NebulaLearning.Entities.Net4x.Concrete
{
    public class ExamCategory : IEntity
    {
        public virtual int CategoryId { get; set; }
        public virtual string CategoryName { get; set; }
    }
}
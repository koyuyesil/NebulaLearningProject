using NebulaLearning.Core.Net4x.Entities;

namespace NebulaLearning.Entities.Net4x.Concrete
{
    public class Choice:IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Content { get; set; }
        public virtual bool IsCorrect { get; set; }
        public virtual int QuestionId { get; set; }
    }
}

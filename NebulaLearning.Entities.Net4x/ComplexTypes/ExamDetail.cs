using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;

namespace NebulaLearning.Entities.Net4x.ComplexTypes
{
    public class ExamDetail
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Duration { get; set; }
        public virtual int Result { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual List<Question> QuestionList { get; set; }
        public List<List<Choice>> ChoiceList { get; set; }
    }
}
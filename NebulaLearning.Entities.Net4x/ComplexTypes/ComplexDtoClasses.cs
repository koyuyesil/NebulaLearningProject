using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebulaLearning.Entities.Net4x.ComplexTypes
{
    public class ExamDetailDto
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public string CategoryName { get; set; }
        public List<QuestionDetailDto> Questions { get; set; }
    }

    public class QuestionDetailDto
    {
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public List<ChoiceDetailDto> Choices { get; set; }
    }

    public class ChoiceDetailDto
    {
        public int ChoiceId { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
    }

}

using NebulaLearning.Core.Net4x.DataAccess.EntityFramework;
using NebulaLearning.DataAccess.Net4x.Abstract;
using NebulaLearning.Entities.Net4x.ComplexTypes;
using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace NebulaLearning.DataAccess.Net4x.Concrete.EntityFramework
{
    public class ExamDal : RepositoryBase<Exam, DatabaseContex>, IExamDal
    {
        public List<ExamDetail> GetExamDetailList()
        {
            using (DatabaseContex contex = new DatabaseContex())
            {
                var result = from e in contex.Exams
                             join c in contex.ExamCategories on e.CategoryId equals c.Id
                             join q in contex.Questions on e.Id equals q.ExamId into questions
                             where e.Id == 4   // todo : buradasın
                             select new ExamDetail
                             {
                                 Id = e.Id,
                                 Name = e.Name,
                                 Description = e.Description,
                                 Duration = e.Duration,
                                 Result = e.Result,
                                 CategoryId = c.Id,
                                 CategoryName = c.Name,
                                 QuestionList = questions.ToList(),
                                 ChoiceList = (
                                    from q in questions
                                    join ch in contex.Choices on q.Id equals ch.QuestionId into choices
                                    select choices.ToList()).ToList()
                             };
                return result.ToList();
            }
        }
    }
}
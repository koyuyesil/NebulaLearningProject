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
                var result = from p in contex.Exams
                             join c in contex.ExamCategories on p.CategoryId equals c.CategoryId
                             select new ExamDetail
                             {
                                 ExamId = p.CategoryId,
                                 ExamName = p.Name,
                                 CategoryName = c.CategoryName
                             }; 
                return result.ToList();
            }
        }

        public List<ExamDetailDto> GetExam()
        {
            using (DatabaseContex context = new DatabaseContex())
            {
                var result = from exam in context.Exams
                             join category in context.ExamCategories on exam.CategoryId equals category.CategoryId
                             select new ExamDetailDto
                             {
                                 ExamId = exam.Id,
                                 ExamName = exam.Name,
                                 CategoryName = category.CategoryName,
                                 Questions = (from question in context.Questions
                                              where question.ExamId == exam.Id
                                              select new QuestionDetailDto
                                              {
                                                  QuestionId = question.Id,
                                                  Content = question.Content,
                                                  Type = question.Type,
                                                  Choices = (from choice in context.Choices
                                                             where choice.QuestionId == question.Id
                                                             select new ChoiceDetailDto
                                                             {
                                                                 ChoiceId = choice.Id,
                                                                 Content = choice.Content,
                                                                 IsCorrect = choice.IsCorrect
                                                             }).ToList()
                                              }).ToList()
                             };
                return result.ToList();
            }
        }

    }
}

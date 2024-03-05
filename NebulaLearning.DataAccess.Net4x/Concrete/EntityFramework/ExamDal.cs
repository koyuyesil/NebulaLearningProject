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
                             select new ExamDetail
                             {
                                 ExamId = e.Id,
                                 ExamName = e.Name,
                                 CategoryName = c.Name
                             }; 
                return result.ToList();
            }
        }

    }
}

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
                             join c in contex.ExamCategories on p.ExamCategoryId equals c.ExamCategoryId
                             select new ExamDetail
                             {
                                 // burada kaldık database de sınavlar bölümünde kategori Id yok ekle
                                 ExamId = p.ExamCategoryId,
                                 ExamName = p.ExamName,
                                 CategoryName = c.ExamCategoryName
                             }; 
                return result.ToList();
            }
        }
    }
}

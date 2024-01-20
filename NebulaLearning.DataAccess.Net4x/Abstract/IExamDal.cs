using NebulaLearning.Core.Net4x.DataAccess;
using NebulaLearning.Entities.Net4x.ComplexTypes;
using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;

namespace NebulaLearning.DataAccess.Net4x.Abstract
{
    public interface IExamDal:IEntityRepository<Exam>
    {
        //First Complex Type here, buraya yazılan methodlar Concrete klasoundeki miras alanlar implemente eder.
        List<ExamDetail> GetExamDetailList();
    }
}

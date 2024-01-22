using NebulaLearning.Entities.Net4x.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebulaLearning.Business.Net4x.Abstract
{
    public interface IExamService
    {
        List<Exam> GetExamList();
        Exam GetExamById(int id);
        Exam AddExam(Exam exam);
        Exam UpdateExam(Exam exam);
    }
}

using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;

namespace NebulaLearning.Business.Net4x.Abstract
{
    public interface IExamService
    {
        List<Exam> GetExamList();

        Exam GetExamById(int id);

        Exam AddExam(Exam exam);

        Exam UpdateExam(Exam exam);

        void TransactionalOperation(Exam toInsertExam, Exam toUpdateExam);

        void TransactionalOperationDirtyCode(Exam toInsertExam, Exam toUpdateExam);
    }
}
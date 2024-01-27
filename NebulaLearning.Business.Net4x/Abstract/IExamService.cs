using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;
using System.ServiceModel;

namespace NebulaLearning.Business.Net4x.Abstract
{
    [ServiceContract]
    public interface IExamService
    {
        [OperationContract]
        List<Exam> GetExamList();
        [OperationContract]
        Exam GetExamById(int id);
        [OperationContract]
        Exam AddExam(Exam exam);
        [OperationContract]
        Exam UpdateExam(Exam exam);
        [OperationContract]
        void TransactionalOperation(Exam toInsertExam, Exam toUpdateExam);
    }
}
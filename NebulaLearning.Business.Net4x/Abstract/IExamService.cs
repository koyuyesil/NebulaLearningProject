using NebulaLearning.Entities.Net4x.ComplexTypes;
using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;
using System.ServiceModel;

namespace NebulaLearning.Business.Net4x.Abstract
{
    [ServiceContract]
    public interface IExamService
    {
        [OperationContract]
        Exam Add(Exam exam);

        [OperationContract]
        Exam Update(Exam exam);

        [OperationContract]
        Exam Delete(Exam exam);

        [OperationContract]
        Exam GetById(int id);

        [OperationContract]
        List<Exam> GetList();

        [OperationContract]
        List<ExamDetail> GetExamDetailList();

        [OperationContract]
        void TransactionalOperation(Exam toInsertExam, Exam toUpdateExam);//yukarıdakilere bağlı operasyon
    }
}
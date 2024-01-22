using NebulaLearning.Business.Net4x.Abstract;
using NebulaLearning.Business.Net4x.ValidationRules.FluentValidation;
using NebulaLearning.Core.Net4x.Aspects.PostSharp;
using NebulaLearning.DataAccess.Net4x.Abstract;
using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;

namespace NebulaLearning.Business.Net4x.Concrete.Managers
{
    public class ExamManager : IExamService
    {
        private IExamDal _examDal;

        public ExamManager(IExamDal examDal) // 54.3 QUERYABLE REPOSTORY BURADA PARAMETRE OLARAK IMPLEMENTE EDİLEBİLİR.
        {
            _examDal = examDal;
        }
        // BU Tür vadidationlar istemci tarafında da  otomatik arayüze uygulanabiliyor.
        //postsharp 4.2.17 ücrestsiz sürümü seç
        [FluentValidationAspect(typeof(ExamValidator))]
        public Exam AddExam(Exam exam)
        {
            return _examDal.Add(exam);
        }
        [FluentValidationAspect(typeof(ExamValidator))]
        public Exam GetExamById(int id)
        {
            return _examDal.Get(e=>e.ExamId == id);
        }
        [FluentValidationAspect(typeof(ExamValidator))]
        public List<Exam> GetExamList()
        {
            return _examDal.GetList();
        }
        [FluentValidationAspect(typeof(ExamValidator))]
        public Exam UpdateExam(Exam exam)
        {
            return _examDal.Update(exam);
        }
    }
}

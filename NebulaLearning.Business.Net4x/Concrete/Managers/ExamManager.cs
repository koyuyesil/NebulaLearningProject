using NebulaLearning.Business.Net4x.Abstract;
using NebulaLearning.Business.Net4x.ValidationRules.FluentValidation;
using NebulaLearning.Core.Net4x.Aspects.PostSharp.CacheAspects;
using NebulaLearning.Core.Net4x.Aspects.PostSharp.LogAspects;
using NebulaLearning.Core.Net4x.Aspects.PostSharp.TransactionAspect;
using NebulaLearning.Core.Net4x.Aspects.PostSharp.ValidationAspects;
using NebulaLearning.Core.Net4x.CrossCuttingConserns.Caching.Microsoft;
using NebulaLearning.Core.Net4x.CrossCuttingConserns.Logging.Log4Net.Loggers;
using NebulaLearning.DataAccess.Net4x.Abstract;
using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;
using System.Transactions;

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
        // postsharp ücretli bir liblary
        // aspect isimlerini biz giriyoruz.
        [FluentValidationAspect(typeof(ExamValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]// minute parametre alabilir
        //[CacheRemoveAspect("regexpatern",typeof(MemoryCacheManager))]// minute parametre alabilir
        public Exam AddExam(Exam exam)
        {
            return _examDal.Add(exam);
        }

        
        public Exam GetExamById(int id)
        {
            return _examDal.Get(e => e.ExamId == id);
        }

        [CacheAspect(typeof(MemoryCacheManager),60)]// minute parametre alabilir 
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        public List<Exam> GetExamList()
        {
            return _examDal.GetList();
        }

        [TransactionScopeAspect]
        public void TransactionalOperation(Exam a, Exam b)
        {
            _examDal.Add(a);
            //bussines codes
            _examDal.Update(b);
            // burada a ve b başarılı ise ok değilse error vermesi gerekmez mi
            // method aspect tarafından dispose edilse bile veritabanına kayıt olmaz mı?

        }

        public void TransactionalOperationDirtyCode(Exam a, Exam b)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _examDal.Add(a);
                    //bussines codes
                    _examDal.Update(b);
                    scope.Complete();
                    // bu yöntemin bir iyisi Action method kullanmak kirli kod örneği
                }
                catch
                {
                    scope.Dispose();
                }
            }
        }

        [FluentValidationAspect(typeof(ExamValidator))]
        public Exam UpdateExam(Exam exam)
        {
            return _examDal.Update(exam);
        }
    }
}
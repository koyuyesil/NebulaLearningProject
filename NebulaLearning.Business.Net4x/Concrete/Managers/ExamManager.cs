using AutoMapper;
using NebulaLearning.Business.Net4x.Abstract;
using NebulaLearning.Business.Net4x.ValidationRules.FluentValidation;
using NebulaLearning.Core.Net4x.Aspects.PostSharp.AuthorizationAspects;
using NebulaLearning.Core.Net4x.Aspects.PostSharp.CacheAspects;
using NebulaLearning.Core.Net4x.Aspects.PostSharp.TransactionAspect;
using NebulaLearning.Core.Net4x.Aspects.PostSharp.ValidationAspects;
using NebulaLearning.Core.Net4x.CrossCuttingConserns.Caching.Microsoft;
using NebulaLearning.Core.Net4x.Utilities.Mappings;
using NebulaLearning.DataAccess.Net4x.Abstract;
using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace NebulaLearning.Business.Net4x.Concrete.Managers
{
    // LogAspect Class yada Method üstü yerine assembly seviyesine (AssemblyInfo.cs) expression ile taşındı.
    public class ExamManager : IExamService
    {
        private IExamDal _examDal;
        private readonly IMapper _mapper;

        // TODO : AUTOMAPPER STEP 7 :
        public ExamManager(IExamDal examDal, IMapper mapper) // TODO : Konu 54.3 Queryable Repository burada parametre olarak implemente edilebilir.
        {
            _examDal = examDal;
            _mapper = mapper;
        }

        // Dip Not: Bu tarz validation işlemleri, istemci tarafında da otomatik arayüze uygulanabiliyor.
        [FluentValidationAspect(typeof(ExamValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]//[CacheRemoveAspect("regexpatern",typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor")]
        public Exam AddExam(Exam exam)
        {
            return _examDal.Add(exam);
        }

        public Exam GetExamById(int id)
        {
            return _examDal.Get(e => e.ExamId == id);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        //[SecuredOperation(Roles="Admin,Editor,Student")]
        public List<Exam> GetExamList()
        {
            // TODO : WEB API STEP 6 : EntityFramework Serileştirme hatası Select Operasyonu ile çözülür.
            //return _examDal.GetList().Select(p => new Exam
            //{
            //    ExamCategoryId = p.ExamCategoryId,
            //    ExamDescription = p.ExamDescription,
            //    ExamDuration = p.ExamDuration,
            //    ExamId = p.ExamId,
            //    ExamName = p.ExamName,
            //    ExamResult = p.ExamResult
            //}).ToList();
            // TODO : WEB API STEP 7 : Uzun kullanım yerine automapper 6.2.2 sürüm çalışan. kullanacağız alternatifi mapster
            // TODO : AUTOMAPPER STEP 1 :
            // return AutoMapperHelper.MapToSameTypeList(_examDal.GetList());
            // TODO : AUTOMAPPER STEP 8 :
            return _mapper.Map<List<Exam>>(_examDal.GetList()); 

        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ExamValidator))]
        public void TransactionalOperation(Exam toInsertExam, Exam toUpdateExam)
        {
            _examDal.Add(toInsertExam);
            // bussines codes
            _examDal.Update(toUpdateExam);
        }

        public void TransactionalOperationDirtyCode(Exam toInsertExam, Exam toUpdateExam)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _examDal.Add(toInsertExam);
                    // bussines codes
                    _examDal.Update(toUpdateExam);
                    scope.Complete();
                    // kirli kod örneği bunun yerine action method kullanılabilirdi ama aspect daha iyi seçenek
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
using AutoMapper;
using NebulaLearning.Business.Net4x.Abstract;
using NebulaLearning.Business.Net4x.ValidationRules.FluentValidation;
using NebulaLearning.Core.Net4x.Aspects.PostSharp.AuthorizationAspects;
using NebulaLearning.Core.Net4x.Aspects.PostSharp.CacheAspects;
using NebulaLearning.Core.Net4x.Aspects.PostSharp.TransactionAspect;
using NebulaLearning.Core.Net4x.Aspects.PostSharp.ValidationAspects;
using NebulaLearning.Core.Net4x.CrossCuttingConserns.Caching.Microsoft;
using NebulaLearning.DataAccess.Net4x.Abstract;
using NebulaLearning.Entities.Net4x.ComplexTypes;
using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;

namespace NebulaLearning.Business.Net4x.Concrete.Managers
{
    public class ExamManager : IExamService
    {// LogAspect Class yada Method üstü yerine assembly seviyesine (AssemblyInfo.cs) expression ile taşındı.
        private IExamDal _examDal;
        private readonly IMapper _mapper; // TODO : AUTOMAPPER STEP 7 :

        public ExamManager(IExamDal examDal, IMapper mapper) // TODO : Konu 54.3 Queryable Repository burada parametre olarak implemente edilebilir.
        {
            _examDal = examDal;
            _mapper = mapper; // TODO : AUTOMAPPER STEP 7 :
        }

        [FluentValidationAspect(typeof(ExamValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public Exam Add(Exam exam)
        {
            return _examDal.Add(exam);
        }

        [FluentValidationAspect(typeof(ExamValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public Exam Update(Exam exam)
        {
            return _examDal.Update(exam);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public Exam Delete(Exam exam)
        {
            return _examDal.Delete(exam);
        }

        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public Exam GetById(int id)
        {
            return _examDal.Get(e => e.Id == id);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public List<Exam> GetList()
        {
            return _mapper.Map<List<Exam>>(_examDal.GetList());
        }

        [TransactionScopeAspect] // TransactionalOperation
        [FluentValidationAspect(typeof(ExamValidator))]
        public void TransactionalOperation(Exam toInsertExam, Exam toUpdateExam)
        {
            _examDal.Add(toInsertExam);
            _examDal.Update(toUpdateExam);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public List<ExamDetail> GetExamDetailList() //complex type
        {
            return _mapper.Map<List<ExamDetail>>(_examDal.GetExamDetailList());
            return _examDal.GetExamDetailList();
        }
    }
}

// Dip Not: Bu tarz validation işlemleri, istemci tarafında da otomatik arayüze uygulanabiliyor.
//[CacheRemoveAspect("regexpatern",typeof(MemoryCacheManager))]
// TODO : WEB API STEP 6 : EntityFramework Serileştirme hatası Select Operasyonu ile çözülür.
// TODO : WEB API STEP 7 : Ancak, spagetti kodundan kaçınmak için serileştirmeyi Select operasyonu
// kullanmak yerine, .NET 4.8 üzerinde çalışan AutoMapper in 6.2.2 sürümü ile kullanmayı düşünebilirsiniz.
// Bu, kodunuzu daha temiz ve yönetilebilir hale getirebilir. Alternatif Mapster
// TODO : AUTOMAPPER STEP 1 :
// return AutoMapperHelper.MapToSameTypeList(_examDal.GetList());
// TODO : AUTOMAPPER STEP 8 :
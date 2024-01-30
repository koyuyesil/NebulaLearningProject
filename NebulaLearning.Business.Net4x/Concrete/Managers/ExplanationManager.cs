using AutoMapper;
using NebulaLearning.Business.Net4x.Abstract;
using NebulaLearning.Business.Net4x.ValidationRules.FluentValidation;
using NebulaLearning.Core.Net4x.Aspects.PostSharp.AuthorizationAspects;
using NebulaLearning.Core.Net4x.Aspects.PostSharp.CacheAspects;
using NebulaLearning.Core.Net4x.Aspects.PostSharp.ValidationAspects;
using NebulaLearning.Core.Net4x.CrossCuttingConserns.Caching.Microsoft;
using NebulaLearning.DataAccess.Net4x.Abstract;
using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;

namespace NebulaLearning.Business.Net4x.Concrete.Managers
{
    public class ExplanationManager : IExplanationService
    {
        private IExplanationDal _explanationDal;
        private readonly IMapper _mapper;

        public ExplanationManager(IExplanationDal explanationDal, IMapper mapper)
        {
            _explanationDal = explanationDal;
            _mapper = mapper;
        }

        [FluentValidationAspect(typeof(ExamValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public Explanation Add(Explanation explanation)
        {
            return _explanationDal.Add(explanation);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public Explanation Delete(Explanation explanation)
        {
            return _explanationDal.Delete(explanation);
        }

        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public Explanation GetById(int id)
        {
            return _explanationDal.Get(e => e.Id == id);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public List<Explanation> GetByQuestionId(int id)
        {
            return _mapper.Map<List<Explanation>>(_explanationDal.GetList(e => e.QuestionId == id));
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public List<Explanation> GetList()
        {
            return _mapper.Map<List<Explanation>>(_explanationDal.GetList());
        }

        [FluentValidationAspect(typeof(ExamValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public Explanation Update(Explanation explanation)
        {
            return _explanationDal.Update(explanation);
        }
    }
}

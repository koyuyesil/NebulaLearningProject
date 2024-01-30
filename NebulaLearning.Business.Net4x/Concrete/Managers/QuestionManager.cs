using AutoMapper;
using NebulaLearning.Business.Net4x.Abstract;
using NebulaLearning.Business.Net4x.ValidationRules.FluentValidation;
using NebulaLearning.Core.Net4x.Aspects.PostSharp.AuthorizationAspects;
using NebulaLearning.Core.Net4x.Aspects.PostSharp.CacheAspects;
using NebulaLearning.Core.Net4x.Aspects.PostSharp.ValidationAspects;
using NebulaLearning.Core.Net4x.CrossCuttingConserns.Caching.Microsoft;
using NebulaLearning.DataAccess.Net4x.Abstract;
using NebulaLearning.Entities.Net4x.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebulaLearning.Business.Net4x.Concrete.Managers
{
    public class QuestionManager : IQuestionService
    {
        private IQuestionDal _questionDal;
        private readonly IMapper _mapper;

        public QuestionManager(IQuestionDal questionDal, IMapper mapper)
        {
            _questionDal = questionDal;
            _mapper = mapper;
        }

        [FluentValidationAspect(typeof(ExamValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public Question Add(Question question)
        {
            return _questionDal.Add(question);
        }

        [FluentValidationAspect(typeof(ExamValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public Question Update(Question question)
        {
            return _questionDal.Update(question);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public Question Delete(Question question)
        {
            return _questionDal.Delete(question);
        }

        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public Question GetById(int id)
        {
            return _questionDal.Get(c => c.Id == id);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public List<Question> GetByCategoryId(int id)
        {
            return _mapper.Map<List<Question>>(_questionDal.GetList(c => c.CategoryId == id));
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public List<Question> GetList()
        {
            return _mapper.Map<List<Question>>(_questionDal.GetList());
        }
    }
}

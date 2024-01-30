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
    public class ChoiceManager : IChoiceService
    {
        private IChoiceDal _choiceDal;
        private readonly IMapper _mapper;

        public ChoiceManager(IChoiceDal choiceDal, IMapper mapper)
        {
            _choiceDal = choiceDal;
            _mapper = mapper;
        }

        [FluentValidationAspect(typeof(ExamValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public Choice Add(Choice choice)
        {
            return _choiceDal.Add(choice);
        }

        [FluentValidationAspect(typeof(ExamValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public Choice Update(Choice choice)
        {
            return _choiceDal.Update(choice);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public Choice Delete(Choice choice)
        {
            return _choiceDal.Delete(choice);
        }

        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public Choice GetById(int id)
        {
            return _choiceDal.Get(c => c.Id == id);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public List<Choice> GetByQuestionId(int id)
        {
            return _mapper.Map<List<Choice>>(_choiceDal.GetList(c => c.QuestionId == id));
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public List<Choice> GetList()
        {
            return _mapper.Map<List<Choice>>(_choiceDal.GetList());
        }


    }
}

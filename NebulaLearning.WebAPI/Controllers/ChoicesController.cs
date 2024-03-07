using NebulaLearning.Business.Net4x.Abstract;
using NebulaLearning.Business.Net4x.DependencyResolvers.Ninject;
using NebulaLearning.Entities.Net4x.Concrete;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace NebulaLearning.WebAPI.Controllers
{
    [RoutePrefix("api/choices")]
    public class ChoicesController : ApiController
    {
        private IChoiceService choiceService = InstanceFactory.GetInstance<IChoiceService>();

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        [Route("add")]
        public Choice Add()
        {
            return choiceService.Add(new Choice() { Content = "Yeni Şık - " + DateTime.Now, IsCorrect = false, QuestionId = 1 });
        }

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        [Route("update/{id}")]
        public Choice Update(int id)
        {
            return choiceService.Update(new Choice() { Id = id, Content = "Güncellendi - " + DateTime.Now, IsCorrect = false, QuestionId = 99 });
        }

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        [Route("delete/{id}")]
        public Choice Delete(int id)
        {
            return choiceService.Delete(new Choice() { Id = id });
        }

        [Route("get/{id}")]
        public Choice Get(int id)
        {
            return choiceService.GetById(id);
        }
        
        public List<Choice> GetList()
        {
            return choiceService.GetList();
        }

        [Route("GetByQuestionId/{id}")]
        public List<Choice> GetList(int id)
        {
            return choiceService.GetByQuestionId(id);
        }
    }
}
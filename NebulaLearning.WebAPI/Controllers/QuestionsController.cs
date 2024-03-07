using NebulaLearning.Business.Net4x.Abstract;
using NebulaLearning.Business.Net4x.DependencyResolvers.Ninject;
using NebulaLearning.Entities.Net4x.Concrete;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace NebulaLearning.WebAPI.Controllers
{
    [RoutePrefix("api/questions")]
    public class QuestionsController : ApiController
    {
        private IQuestionService questionService = InstanceFactory.GetInstance<IQuestionService>();

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        [Route("add")]
        public Question Add()
        {
            return questionService.Add(new Question() { ExamId = 4, Content = "Yeni Soru - " + DateTime.Now, Type = "Science", CategoryId = 99 });
        }

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        [Route("update/{id}")]
        public Question Update(int id)
        {
            return questionService.Update(new Question() { Id = id, Content = "Güncellendi - " + DateTime.Now, Type = "Science", CategoryId = 99 });
        }

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        [Route("delete/{id}")]
        public Question Delete(int id)
        {
            return questionService.Delete(new Question() { Id = id });
        }

        [Route("get/{id}")]
        public Question Get(int id)
        {
            return questionService.GetById(id);
        }

        public List<Question> GetList()
        {
            return questionService.GetList();
        }

        [Route("GetByCategoryId/{id}")]
        public List<Question> GetList(int id)
        {
            return questionService.GetByCategoryId(id);
        }
    }
}
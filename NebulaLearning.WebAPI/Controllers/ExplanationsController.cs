using NebulaLearning.Business.Net4x.Abstract;
using NebulaLearning.Business.Net4x.DependencyResolvers.Ninject;
using NebulaLearning.Entities.Net4x.Concrete;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace NebulaLearning.WebAPI.Controllers
{
    [RoutePrefix("api/explanations")]
    public class ExplanationsController : ApiController
    {
        private IExplanationService explanationService = InstanceFactory.GetInstance<IExplanationService>();

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        [Route("add")]
        public Explanation Add()
        {
            return explanationService.Add(new Explanation() { Content = "Yeni Açıklamalı - " + DateTime.Now, QuestionId = 1 });
        }

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        [Route("update/{id}")]
        public Explanation Update(int id)
        {
            return explanationService.Update(new Explanation() { Id = id, Content = "Güncellendi - " + DateTime.Now, QuestionId = 1 });
        }

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        [Route("delete/{id}")]
        public Explanation Delete(int id)
        {
            return explanationService.Delete(new Explanation() { Id = id });
        }

        [Route("get/{id}")]
        public Explanation Get(int id)
        {
            return explanationService.GetById(id);
        }

        public List<Explanation> GetList()
        {
            return explanationService.GetList();
        }

        [Route("GetByQuestionId/{id}")]
        public List<Explanation> GetList(int id)
        {
            return explanationService.GetByQuestionId(id);
        }
    }
}
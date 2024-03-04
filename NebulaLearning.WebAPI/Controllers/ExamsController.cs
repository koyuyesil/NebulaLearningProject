using NebulaLearning.Business.Net4x.Abstract;
using NebulaLearning.Business.Net4x.DependencyResolvers.Ninject;
using NebulaLearning.Entities.Net4x.Concrete;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace NebulaLearning.WebAPI.Controllers
{
    [RoutePrefix("api/exams")]
    public class ExamsController : ApiController
    {
        private IExamService examService = InstanceFactory.GetInstance<IExamService>();

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        [Route("add")]
        public Exam Add()
        {
            return examService.Add(new Exam() { Name = "Yeni Sınav - " + DateTime.Now, Result = 100, Duration = 30, Description = "Açıklama", CategoryId = 4 });
        }

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        [Route("update/{id}")]
        public Exam Update(int id)
        {
            return examService.Update(new Exam() { Id = id, Name = "Güncellendi - " + DateTime.Now, Result = 100, Duration = 30, Description = "Açıklama", CategoryId = 4 });
        }

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        [Route("delete/{id}")]
        public Exam Delete(int id)
        {
            return examService.Delete(new Exam() { Id = id });
        }

        [Route("get/{id}")]
        public Exam Get(int id)
        {
            return examService.GetById(id);
        }

        public List<Exam> GetList()
        {
            return examService.GetList();
        }
    }
}
// TODO : WEB API STEP 1 : Geçici constructor yapılır
// TODO : WEB API STEP 2 : ExamManager oluşturulur gerekli parametreler InstanceFactoryde inekte edilir.
// TODO : WEB API STEP 2 : Sonra burada servisden instance alınır.
// TODO : WEB API STEP 3 : Buradan itibaren 5 adet hata alınacaktır.
// HATA 1 : <ExceptionMessage>'ExamsController' türünde bir denetleyici oluşturmaya çalışırken hata oluştu. Denetleyicinin parametresiz ortak bir oluşturucusu olduğundan emin olun.
// ÇÖZÜM 1 : WebApiContrib.IoC.Ninject ve Ninject.MVC5 paketi yüklenir. Bağımlılık olarak gelen Ninject sürümü de yerel sürümlerle aynı olmalıdır. An itibari ile PostSharp hariç güncel.
// ÇÖZÜM 2 : NinjectWebCommon.cs dosyasına Binding yapılır
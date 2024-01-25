using NebulaLearning.Business.Net4x.Abstract;
using NebulaLearning.Entities.Net4x.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NebulaLearning.WebAPI.Controllers
{
    public class ExamsController : ApiController
    {
        private IExamService _examService; // TODO : WEB API STEP 1 :

        public ExamsController(IExamService examService)
        {
            _examService = examService;  // TODO : WEB API STEP 2 :
        }

        public List<Exam> Get()
        {
            return _examService.GetExamList(); // TODO : WEB API STEP 3 : Buradan itibaren 5 adet hata alınacaktır.
        }

        // HATA 1 : <ExceptionMessage>'ExamsController' türünde bir denetleyici oluşturmaya çalışırken hata oluştu. Denetleyicinin parametresiz ortak bir oluşturucusu olduğundan emin olun.
        // ÇÖZÜM 1 : WebApiContrib.IoC.Ninject ve Ninject.MVC5 paketi yüklenir. Bağımlılık olarak gelen Ninject sürümü de yerel sürümlerle aynı olmalıdır. An itibari ile PostSharp hariç güncel.
    }
}

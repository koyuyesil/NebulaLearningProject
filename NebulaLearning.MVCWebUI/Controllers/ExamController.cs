using NebulaLearning.Business.Net4x.Abstract;
using NebulaLearning.Entities.Net4x.Concrete;
using System.Web.Mvc;

namespace NebulaLearning.MVCWebUI.Controllers
{
    public class ExamController : Controller
    {
        // GET: Exam
        private IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }
        public ActionResult Index()
        {
            var model = new ExamListViewModel // generate new type-yeni tür oluşturdan hızlı yaplır
            {
                Exams = _examService.GetList()
            };
            return View(model);
            //return View(_examService.GetExamList()); DirtyCode
        }
        public string Add()
        {
            _examService.Add(new Exam { CategoryId = 1, Name = "Coğrafya", Duration = 30, Description = "Coğrafya 1. Sınav", Result = 5 });
            return "Added";
        }
        public string AddTransactional()
        {
            _examService.TransactionalOperation(
                new Exam
            {
                CategoryId = 1,
                Name = "Bilgisayar",
                Duration = 30,
                Description = "Sınav Açıklaması",
                Result = 1
            }, new Exam
            {
                Id = 1,
                CategoryId = 8,
                Name = "Data Science",
                Duration = 30,
                Description = "Sınav Açıklaması",
                Result = 1
            });
            return "Added";
        }
    }
}
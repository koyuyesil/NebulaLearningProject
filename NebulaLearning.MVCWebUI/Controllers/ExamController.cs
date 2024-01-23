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
                Exams = _examService.GetExamList()
            };
            return View(model);
            //return View(_examService.GetExamList()); DirtyCode
        }
        public string Add()
        {
            _examService.AddExam(new Exam { ExamCategoryId = 1, ExamName = "Coğrafya", ExamDuration = 30, ExamDescription = "Coğrafya 1. Sınav", ExamResult = 5 });
            return "Added";
        }
        public string AddTransactional()
        {
            _examService.TransactionalOperation(
                new Exam
            {
                ExamCategoryId = 1,
                ExamName = "Coğrafya",
                ExamDuration = 30,
                ExamDescription = "Coğrafya 1. Sınav",
                ExamResult = 5
            }, new Exam
            {
                ExamId = 1,
                ExamCategoryId = 4,
                ExamName = "Coğrafya",
                ExamDuration = 30,
                ExamDescription = "Coğrafya 1. Sınav",
                ExamResult = 5
            });
            return "Added";
        }
    }
}
using System.IO;
using System.Web.Mvc;
using NebulaLearning.Entities.Net4x.Concrete;
using System.Collections.Generic;

namespace NebulaLearning.MVCWebUI
{
    public class ExamListViewModel //: IView
    {
        public List<Exam> Exams { get; set; }

        public void Render(ViewContext viewContext, TextWriter writer)
        {
            throw new System.NotImplementedException();
        }
    }
}
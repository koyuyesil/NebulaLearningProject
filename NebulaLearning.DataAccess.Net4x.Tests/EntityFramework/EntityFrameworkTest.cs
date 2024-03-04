using Microsoft.VisualStudio.TestTools.UnitTesting;
using NebulaLearning.DataAccess.Net4x.Concrete.EntityFramework;
using NebulaLearning.Entities.Net4x.Concrete;

namespace NebulaLearning.DataAccess.Net4x.Tests.EntityFramework
{
    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod]
        public void Get_all_returns_exams()
        {
            ExamDal _examDal = new ExamDal();
            // select count(*) from Exams
            var result = _examDal.GetList();
            Assert.IsTrue(result.Count > 5);
            //Assert.AreEqual(3, result.Count);
        }
        [TestMethod]
        public void Get_all_with_parameters_returns_filtered_exams()
        {
            ExamDal _examDal = new ExamDal();
            // select count(*) from Exams where ExamName like '%Math%'
            var result = _examDal.GetList(e=>e.Name.Contains("Bilgisayar"));
            Assert.AreEqual(3, result.Count);
        }
    }
}
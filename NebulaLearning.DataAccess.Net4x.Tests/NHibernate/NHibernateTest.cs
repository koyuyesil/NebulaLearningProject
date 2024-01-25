using Microsoft.VisualStudio.TestTools.UnitTesting;
using NebulaLearning.DataAccess.Net4x.Concrete.NHibernate;
using NebulaLearning.DataAccess.Net4x.Concrete.NHibernate.Helpers;
using System;

namespace NebulaLearning.DataAccess.Net4x.Tests.NHibernate
{
    [TestClass]
    public class NHibernateTest
    {
        [TestMethod]
        public void Get_all_returns_exams()
        {
            ExamDal _examDal = new ExamDal(new SqlServerHelper());
            // select count(*) from Exams
            var result = _examDal.GetList();
            Assert.IsTrue(result.Count > 5);
            //Assert.AreEqual(3, result.Count);
        }
        [TestMethod]
        public void Get_all_with_parameters_returns_filtered_exams()
        {
            ExamDal _examDal = new ExamDal(new SqlServerHelper());
            // select count(*) from Exams where ExamName like '%Math%'
            var result = _examDal.GetList(e => e.ExamName.Contains("Bilgisayar"));
            Assert.AreEqual(3, result.Count);
        }
    }
}

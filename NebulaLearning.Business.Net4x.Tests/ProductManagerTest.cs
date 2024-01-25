using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NebulaLearning.Business.Net4x.Concrete.Managers;
using NebulaLearning.DataAccess.Net4x.Abstract;
using NebulaLearning.Entities.Net4x.Concrete;
using System.Security;

namespace NebulaLearning.Business.Net4x.Tests
{
    [TestClass]
    public class ProductManagerTest
    {
        //[ExpectedException(typeof(ValidationException))]
        [ExpectedException(typeof(SecurityException))]
        [TestMethod]
        public void exam_validator_test()
        {
            Mock<IExamDal> mock= new Mock<IExamDal> ();
            ExamManager  examManager= new ExamManager(mock.Object);
            examManager.AddExam(new Exam());
        }
    }
}

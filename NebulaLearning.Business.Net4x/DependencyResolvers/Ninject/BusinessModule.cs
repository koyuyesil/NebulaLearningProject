using NebulaLearning.Business.Net4x.Abstract;
using NebulaLearning.Business.Net4x.Concrete.Managers;
using NebulaLearning.Core.Net4x.DataAccess;
using NebulaLearning.DataAccess.Net4x.Abstract;
using Ninject.Modules;
using System.Data.Entity;

namespace NebulaLearning.Business.Net4x.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            // Depencency Injection
            // Class isimleri aynı olduğu için namespace seçilecek.
            // TODO Entity 9 : IEntityService ve IEntityDal için Depencency Injection tanımlanır
            Bind<IExamService>().To<ExamManager>().InSingletonScope();
            Bind<IExamDal>().To<DataAccess.Net4x.Concrete.EntityFramework.ExamDal>().InSingletonScope();
            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<DataAccess.Net4x.Concrete.EntityFramework.UserDal>().InSingletonScope();
            Bind<IChoiceService>().To<ChoiceManager>().InSingletonScope();
            Bind<IChoiceDal>().To<DataAccess.Net4x.Concrete.EntityFramework.ChoiceDal>().InSingletonScope();
            Bind<IExplanationService>().To<ExplanationManager>().InSingletonScope();
            Bind<IExplanationDal>().To<DataAccess.Net4x.Concrete.EntityFramework.ExplanationDal>().InSingletonScope();

            //Bind<IQuestionService>().To<QuestionManager>().InSingletonScope();
            Bind<IQuestionDal>().To<DataAccess.Net4x.Concrete.EntityFramework.QuestionDal>().InSingletonScope();

            // Standart Olanlar
            Bind(typeof(IQueryableRepository<>)).To(typeof(Core.Net4x.DataAccess.EntityFramework.QueryableRepository<>));
            Bind<DbContext>().To<DataAccess.Net4x.Concrete.EntityFramework.DatabaseContex>();
            // Sadece NHibernate için
            Bind<Core.Net4x.DataAccess.NHibernate.NHibernateHelper>().To<DataAccess.Net4x.Concrete.NHibernate.Helpers.SqlServerHelper>();

            
        }
    }
}
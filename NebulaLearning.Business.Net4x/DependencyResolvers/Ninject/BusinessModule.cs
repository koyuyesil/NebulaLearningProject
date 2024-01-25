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
            Bind<IExamService>().To<ExamManager>().InSingletonScope();
            Bind<IExamDal>().To<DataAccess.Net4x.Concrete.EntityFramework.ExamDal>().InSingletonScope();
            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<DataAccess.Net4x.Concrete.EntityFramework.UserDal>().InSingletonScope();  


            // Standart Olanlar
            Bind(typeof(IQueryableRepository<>)).To(typeof(Core.Net4x.DataAccess.EntityFramework.QueryableRepository<>));
            Bind<DbContext>().To<DataAccess.Net4x.Concrete.EntityFramework.DatabaseContex>();
            // Sadece NHibernate için
            Bind<Core.Net4x.DataAccess.NHibernate.NHibernateHelper>().To<DataAccess.Net4x.Concrete.NHibernate.Helpers.SqlServerHelper>();

            
        }
    }
}
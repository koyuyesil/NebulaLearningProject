using NebulaLearning.Business.Net4x.Abstract;
using NebulaLearning.Business.Net4x.Concrete.Managers;
using NebulaLearning.Core.Net4x.DataAccess;
// Depencency Injection
// Class isimleri aynı olduğu için namespace seçilecek.

// DataAccess Queryable yöntemini EF NH gibi buradan değiştir.
using NebulaLearning.Core.Net4x.DataAccess.EntityFramework;
using NebulaLearning.Core.Net4x.DataAccess.NHibernate;

//using NebulaLearning.Core.Net4x.DataAccess.NHibernate;

using NebulaLearning.DataAccess.Net4x.Abstract;

// DataAccess yöntemini EF NH gibi buradan değiştir.
using NebulaLearning.DataAccess.Net4x.Concrete.EntityFramework;
using NebulaLearning.DataAccess.Net4x.Concrete.NHibernate.Helpers;

//using NebulaLearning.DataAccess.Net4x.Concrete.NHibernate;

using Ninject.Modules;
using System.Data.Entity;

namespace NebulaLearning.Business.Net4x.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            // VARLIK BAZLI OLANLAR
            Bind<IExamService>().To<ExamManager>().InSingletonScope();
            Bind<IExamDal>().To<ExamDal>();  // EF ve NH Class isimleri aynı



            // STANDART OLANLAR
            // EF ve NH Class isimleri aynı olduğundan namespace ismiyle de yazabilirsin
            Bind(typeof(IQueryableRepository<>)).To(typeof(Core.Net4x.DataAccess.EntityFramework.QueryableRepository<>));
            Bind<DbContext>().To<DatabaseContex>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();

            
        }
    }
}
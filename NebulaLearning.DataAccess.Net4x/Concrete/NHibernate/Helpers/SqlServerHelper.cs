using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NebulaLearning.Core.Net4x.DataAccess.NHibernate;
using NHibernate;
using System.Reflection;

namespace NebulaLearning.DataAccess.Net4x.Concrete.NHibernate.Helpers
{
    public class SqlServerHelper : NHibernateHelper
    {
        public override ISessionFactory InitializeFactory()
        {
            // TODO burda string hatalı olabilir string nereden geliyor bak. Not:Evet haklı çıktım aşağıda yorumu oku.
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012
                //.ConnectionString(c => c.FromConnectionStringWithKey("NebulaLearning")))//App.Config'den gelir.
                .ConnectionString("Data Source=(localdb)\\MSSQLLocalDB; initial catalog=LearningDatabase;Integrated Security=True;Connect Timeout=30"))
                .Mappings(t => t.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
    }
}
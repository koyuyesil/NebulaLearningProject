using NHibernate;
using System;

namespace NebulaLearning.Core.Net4x.DataAccess.NHibernate
{
    public abstract class NHibernateHelper : IDisposable
    {
        // Entity Framework'taki DbContext'e karşılık gelen, NHibernate'da kullanılan bir ISessionFactory özelliğini temsil eder.
        private static ISessionFactory _sessionFactory;

        // Lazy loading ve/veya navigation property ile ilişkili nesneleri getirme amacıyla kullanılan ISessionFactory özelliği.
        // _sessionFactory henüz atanmamışsa, InitializeFactory() metodu çağrılarak atanır.
        // Bir methodu virtual olarak işaretlemek, bu methodun bir sınıfta tanımlandığını, ancak alt sınıflar tarafından aynı isimle geçersiz kılınabileceğini ifade eder
        public virtual ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = InitializeFactory()); }
        }

        // Bu metot soyut (abstract) olarak işaretlenmiştir.
        // Bu, bu metotun alt sınıflar tarafından implemente edilmesi gerektiğini gösterir.
        // Bu sayede, farklı sunucu teknolojileri (örneğin, NHibernate, Entity Framework) için ayrı implementasyonlar yapılabilir.
        public abstract ISessionFactory InitializeFactory();

        // ISessionFactory'den bir ISession örneği açma işlemini gerçekleştiren metot.
        // Bu, NHibernate tarafındaki veritabanı oturumunu temsil eder.
        public virtual ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

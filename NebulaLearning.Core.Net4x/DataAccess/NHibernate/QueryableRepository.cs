using NebulaLearning.Core.Net4x.Entities;
using System.Linq;

namespace NebulaLearning.Core.Net4x.DataAccess.NHibernate
{
    public class QueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        // NHibernate tarafındaki sorguları işlemek için QueryableRepository sınıfı.
        private NHibernateHelper _helper;

        // IQueryable<T> türündeki varlıkları temsil eden özellik.
        private IQueryable<T> _entities;

        // NHibernateHelper nesnesini kullanarak sınıfın oluşturulmasını sağlayan constructor.
        public QueryableRepository(NHibernateHelper helper)
        {
            _helper = helper;
        }

        public IQueryable<T> Table => this.Entities;

        public IQueryable<T> Entities
        {
            get
            {
                // Queryable Repository ToList() metodu çağrılmadığından session sonlandırılmaz.
                // Eğer _entities henüz atanmamışsa, NHibernateHelper üzerinden bir oturum açılır ve varlıkların sorgusu yapılır.
                if (_entities == null)
                {
                    _entities = _helper.OpenSession().Query<T>();
                }
                return _entities;
            }
        }
    }
}
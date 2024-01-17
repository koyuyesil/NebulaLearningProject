using NebulaLearning.Core.Net4x.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace NebulaLearning.Core.Net4x.DataAccess.EntityFramework
{
    public class QueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _dbContext;
        private IDbSet<T> _entities;

        public QueryableRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Table => this.Entities;

        // Bu özellik, RepositoryBase sınıfındaki veritabanı varlıklarına erişimi sağlar.
        // Cağrılmaması için (yani dışarıdan erişilmemesi için) protected erişim belirteci ile işaretlenmiştir.
        protected virtual IDbSet<T> Entities
        {
            // Eğer _entities henüz atanmamışsa, _dbContext üzerinden Set<T>() metodu kullanılarak atanır.
            get { return _entities ?? (_entities = _dbContext.Set<T>()); }
        }

    }
}
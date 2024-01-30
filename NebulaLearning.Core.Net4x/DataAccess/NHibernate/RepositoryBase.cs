using NebulaLearning.Core.Net4x.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NebulaLearning.Core.Net4x.DataAccess.NHibernate
{
    public class RepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private NHibernateHelper _NHibernateHelper;

        public RepositoryBase(NHibernateHelper nHibernateHelper)
        {
            _NHibernateHelper = nHibernateHelper;
        }

        public TEntity Add(TEntity entity)
        {
            using (var session = _NHibernateHelper.OpenSession())
            {
                session.Save(entity);
                return entity;
            }
        }

        public TEntity Delete(TEntity entity)
        {
            using (var session = _NHibernateHelper.OpenSession())
            {
                session.Delete(entity);
            }
            return entity;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var session = _NHibernateHelper.OpenSession())
            {
                return session.Query<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var session = _NHibernateHelper.OpenSession())
            {
                return filter == null ? session.Query<TEntity>().ToList()
                    : session.Query<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var session = _NHibernateHelper.OpenSession())
            {
                session.Update(entity);
                return entity;
            }
        }
    }
}
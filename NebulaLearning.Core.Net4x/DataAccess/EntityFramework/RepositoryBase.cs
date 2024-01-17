using NebulaLearning.Core.Net4x.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace NebulaLearning.Core.Net4x.DataAccess.EntityFramework
{
    // EntityFramework paketi projeye eklenirse, bu sınıf IEntityRepository<TEntity> arayüzünü uygular ve içini doldurur.
    public class RepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        // Bu sınıf, genel IEntityRepository arayüzünü uygular ve veritabanı işlemleri için temel bir yapı sağlar.
        // TEntity, veritabanındaki varlık türünü temsil eder.
        // TContext, DbContext türündeki veritabanı bağlamını temsil eder.

        // IEntityRepository arayüzünden gelen metotları burada implemente etmek gerekir.
        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }
    }
}
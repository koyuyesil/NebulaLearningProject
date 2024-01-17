using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Principal;

namespace NebulaLearning.Core.Net4x.DataAccess
{
    // Bu interface bir new() yapılabilen bir nesne olabilir (where kısıtı)
    // Bu, T türündeki varlıkların new() ile örneklenebilecek sınıflardan olması gerektiğini belirtir.
    public interface IEntityRepository<T> where T : class, Entities.IEntity, new()
    {
        // GetList metodu, belirli bir filtre koşuluna göre varlık listesini döndürür.
        List<T> GetList(Expression<Func<T, bool>> filter = null);

        // Get metodu, belirli bir filtre koşuluna göre tek bir varlığı döndürür.
        T Get(Expression<Func<T, bool>> filter);

        // Add metodu, bir varlığı veritabanına ekler ve eklenen varlığı geri döndürür.
        T Add(T entity);

        // Update metodu, bir varlığı veritabanında günceller ve güncellenen varlığı geri döndürür.
        T Update(T entity);

        // Delete metodu, belirli bir varlığı veritabanından siler.
        // Entity olarak parametre alması, PK yada numerik olmayan girdileri silmek için kullanışlıdır.
        void Delete(T entity);
    }
}
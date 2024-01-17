using NebulaLearning.Core.Net4x.Entities;
using System.Linq;

namespace NebulaLearning.Core.Net4x.DataAccess
{
    // Bu interface, LINQ sorgularını kullanabilmek için IQueryable özellikli bir repository'yi temsil eder.
    // Bu arayüz, T türündeki varlıklar için genel bir IQueryable erişimini sağlar.
    public interface IQueryableRepository<T> where T : class, IEntity, new()
    {
        // Table özelliği, T türündeki varlıkların IQueryable özelliğine erişimi sağlar.
        IQueryable<T> Table { get; }
    }

    // Not: IQueryable, LINQ sorgularını çalıştırmak için geniş bir arayüz sağlar.
    // Bu arabirim sayesinde, veritabanına yapılan sorgular daha verimli bir şekilde oluşturulabilir ve yönetilebilir.
    // Ancak, IQueryable kullanımına dikkat edilmelidir, çünkü veritabanı üzerinde gereksiz sorgulara neden olabilir.
    // Context kapatılmadan işlem yapılabilmesi için, genellikle bağlamın yönetimini dışarıdan kontrol eden bir yapı kullanmak önemlidir.
    // Bu sayede, IQueryableRepository'nin örneklendiği sınıfın yaşam döngüsü veritabanı bağlamıyla uyumlu olabilir.
}
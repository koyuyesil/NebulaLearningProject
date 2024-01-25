using NebulaLearning.DataAccess.Net4x.Concrete.EntityFramework.Mappings;
using NebulaLearning.Entities.Net4x.Concrete;
using System.Data.Entity;

namespace NebulaLearning.DataAccess.Net4x.Concrete.EntityFramework
{
    public class DatabaseContex:DbContext
    {
        public DatabaseContex():base("Data Source=(localdb)\\MSSQLLocalDB; initial catalog=LearningDatabase;Integrated Security=True;Connect Timeout=30")
        {
            //database yoksa oluşturulmasını null engeller.
            //Database.SetInitializer<DatabaseContex>(new DropCreateDatabaseIfModelChanges<DatabaseContex>());// değişiklik varsa database siler 
            Database.SetInitializer<DatabaseContex>(null);// tablo değişiklikllerini izlemez yorum yapılırsa database yoksa oluşturur.
        }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamCategory> ExamCategories { get; set; }

        // TODO Entity 4 : User için Users DbSet yapılır.
        public DbSet<User> Users { get; set; }



        //model oluşturulurken  override edilerek özel maping yapılması sağlanır.
        //Normalde Class isimleri aynıysa otomatik map eder.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ExamMap());
            modelBuilder.Configurations.Add(new ExamCategoryMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}

using NebulaLearning.DataAccess.Net4x.Concrete.EntityFramework.Mappings;
using NebulaLearning.Entities.Net4x.Concrete;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace NebulaLearning.DataAccess.Net4x.Concrete.EntityFramework
{
    public class DatabaseContex:DbContext
    {

        public DatabaseContex():base("Data Source=(localdb)\\MSSQLLocalDB; initial catalog=LearningDatabase;Integrated Security=True;Connect Timeout=30")
        {
            // Add-Migration InitialCreate –IgnoreChanges 
            // Update-Database -verbose KOMUTU bazen yararlı olablir."ExceptionMessage":"There is already an object named 'Choices'
            // Initializer tanımlanmaz ise yeni database oluşturur.
            //Database.SetInitializer<DatabaseContex>(null); // Tablo değişiklikleri takip edilir normal kullanım.
            Database.SetInitializer<DatabaseContex>(new DropCreateDatabaseIfModelChanges<DatabaseContex>()); // Değişiklik varsa database silinir ve güncellenir. 
            //Database.SetInitializer<DatabaseContex>(new MigrateDatabaseToLatestVersion<DatabaseContex, MigrationsConfiguration>()); // Sadece değişen tablo silinir.
        }
        // TODO Entity 4 : User için Users DbSet yapılır.
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamCategory> ExamCategories { get; set; }
        public DbSet<Explanation> Explanations { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
        // TODO Complex Type : Step 6
        public DbSet<UserRole> UserRoles { get; set; }
        // TODO Complex Type : Step 7
        public DbSet<Role> Roles { get; set; }



        // Model oluşturulurken override edilerek özel maping yapılması sağlanır.
        // Normalde Class isimleri aynıysa otomatik map eder.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ExamMap());
            modelBuilder.Configurations.Add(new ExamCategoryMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }

    public class MigrationsConfiguration : DbMigrationsConfiguration<DatabaseContex>
    {
        public MigrationsConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DatabaseContex context)
        {
            // Veritabanı oluşturulduğunda veya güncellendiğinde çalışacak başlangıç verileri veya kodları buraya ekleyebilirsiniz.
            base.Seed(context);
        }
    }
}

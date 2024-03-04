using NebulaLearning.Entities.Net4x.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace NebulaLearning.DataAccess.Net4x.Concrete.EntityFramework.Mappings
{
    public class ExamMap : EntityTypeConfiguration<Exam>
    {
        public ExamMap()
        {
            ToTable(@"Exams", @"dbo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("ExamId");
            Property(x => x.Name).HasColumnName("ExamName");
            Property(x => x.Description).HasColumnName("ExamDescription");
            Property(x => x.Duration).HasColumnName("ExamDuration");
            Property(x => x.Result).HasColumnName("ExamResult");
            Property(x => x.CategoryId).HasColumnName("ExamCategoryId");
            
        }
    }
}
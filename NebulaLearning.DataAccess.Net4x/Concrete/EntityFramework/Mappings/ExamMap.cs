using NebulaLearning.Entities.Net4x.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace NebulaLearning.DataAccess.Net4x.Concrete.EntityFramework.Mappings
{
    public class ExamMap : EntityTypeConfiguration<Exam>
    {
        public ExamMap()
        {
            ToTable(@"Exams", @"dbo");
            HasKey(x => x.ExamId);
            Property(x => x.ExamId).HasColumnName("ExamId");
            Property(x => x.ExamName).HasColumnName("ExamName");
            Property(x => x.ExamDescription).HasColumnName("ExamDescription");
            Property(x => x.ExamDuration).HasColumnName("ExamDuration");
            Property(x => x.ExamResult).HasColumnName("ExamResult");
            Property(x => x.ExamCategoryId).HasColumnName("ExamCategoryId");
            
        }
    }
}
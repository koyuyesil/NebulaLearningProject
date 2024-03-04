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
            Property(x => x.CategoryId).HasColumnName("CategoryId");
            Property(x => x.Description).HasColumnName("Description");
            Property(x => x.Duration).HasColumnName("Duration");
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Name).HasColumnName("Name");
            Property(x => x.Result).HasColumnName("Result");
            
        }
    }
}
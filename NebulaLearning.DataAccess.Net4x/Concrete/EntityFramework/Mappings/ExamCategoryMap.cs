using NebulaLearning.Entities.Net4x.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace NebulaLearning.DataAccess.Net4x.Concrete.EntityFramework.Mappings
{
    public class ExamCategoryMap:EntityTypeConfiguration<ExamCategory>
    {
        public ExamCategoryMap()
        {
            ToTable(@"ExamCategories", @"dbo");
            HasKey(x => x.CategoryId);
            Property(x => x.CategoryId).HasColumnName("ExamCategoryId");
            Property(x => x.CategoryName).HasColumnName("ExamCategoryName");
        }
    }
}

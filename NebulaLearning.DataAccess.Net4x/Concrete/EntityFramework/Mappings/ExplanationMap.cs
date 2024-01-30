using NebulaLearning.Entities.Net4x.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace NebulaLearning.DataAccess.Net4x.Concrete.EntityFramework.Mappings
{
    public class ExplanationMap : EntityTypeConfiguration<Explanation>
    {
        public ExplanationMap()
        {
            ToTable(@"Explanations", @"dbo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Content).HasColumnName("Content");
            Property(x => x.QuestionId).HasColumnName("QuestionId");
        }
    }
}

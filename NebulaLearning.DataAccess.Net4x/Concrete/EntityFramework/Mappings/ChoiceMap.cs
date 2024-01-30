using NebulaLearning.Entities.Net4x.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace NebulaLearning.DataAccess.Net4x.Concrete.EntityFramework.Mappings
{
    public class ChoiceMap : EntityTypeConfiguration<Choice>
    {
        public ChoiceMap()
        {
            ToTable(@"Choices", @"dbo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Content).HasColumnName("Content");
            Property(x => x.IsCorrect).HasColumnName("IsCorrect");
            Property(x => x.QuestionId).HasColumnName("QuestionId");
        }
    }
}

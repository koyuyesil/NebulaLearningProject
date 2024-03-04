using FluentNHibernate.Mapping;
using NebulaLearning.Entities.Net4x.Concrete;

namespace NebulaLearning.DataAccess.Net4x.Concrete.NHibernate.Mappings
{
    public class ChoiceMap:ClassMap<Choice>
    {
        public ChoiceMap()
        {
            Table(@"Choices");
            LazyLoad();
            Id(x => x.Id).Column("Id");
            Map(x => x.Content).Column("Content");
            Map(x => x.IsCorrect).Column("IsCorrect");
            Map(x => x.QuestionId).Column("QuestionId");
        }
    }
}

using FluentNHibernate.Mapping;
using NebulaLearning.Entities.Net4x.Concrete;

namespace NebulaLearning.DataAccess.Net4x.Concrete.NHibernate.Mappings
{
    public class ExamCategoryMap : ClassMap<ExamCategory>
    {
        public ExamCategoryMap()
        {
            Table(@"ExamCategories");
            LazyLoad();
            Id(x => x.Id).Column("Id");
            Map(x => x.Name).Column("Name");
        }
    }
}

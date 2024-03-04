using FluentNHibernate.Mapping;
using NebulaLearning.Entities.Net4x.Concrete;

namespace NebulaLearning.DataAccess.Net4x.Concrete.NHibernate.Mappings
{
    public class ExamMap:ClassMap<Exam>
    {
        public ExamMap()
        {
            Table(@"Exams");
            LazyLoad();
            Id(x => x.Id).Column("Id");
            Map(x => x.CategoryId).Column("CategoryId");
            Map(x => x.Description).Column("Description");
            Map(x => x.Duration).Column("Duration");
            Map(x => x.Name).Column("Name");
            Map(x => x.Result).Column("Result");
        }
    }
}

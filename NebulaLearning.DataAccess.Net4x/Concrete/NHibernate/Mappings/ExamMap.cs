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
            Id(x => x.Id).Column("ExamId");
            Map(x => x.Result).Column("ExamResult");
            Map(x => x.Duration).Column("ExamDuration");
            Map(x => x.Name).Column("ExamName");
            Map(x => x.CategoryId).Column("ExamCategoryId");
        }
    }
}

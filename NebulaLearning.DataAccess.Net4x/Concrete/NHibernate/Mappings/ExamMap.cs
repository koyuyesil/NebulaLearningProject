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
            Id(x => x.ExamId).Column("ExamId");
            Map(x => x.ExamResult).Column("ExamResult");
            Map(x => x.ExamDuration).Column("ExamDuration");
            Map(x => x.ExamName).Column("ExamName");
            Map(x => x.ExamCategoryId).Column("ExamCategoryId");
        }
    }
}

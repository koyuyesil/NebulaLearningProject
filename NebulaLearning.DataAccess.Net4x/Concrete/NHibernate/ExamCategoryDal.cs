using NebulaLearning.Core.Net4x.DataAccess.NHibernate;
using NebulaLearning.DataAccess.Net4x.Abstract;
using NebulaLearning.Entities.Net4x.Concrete;

namespace NebulaLearning.DataAccess.Net4x.Concrete.NHibernate
{
    public class ExamCategoryDal : RepositoryBase<ExamCategory>, IExamCategoryDal
    {
        public ExamCategoryDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}

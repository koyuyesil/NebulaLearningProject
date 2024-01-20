using NebulaLearning.Core.Net4x.DataAccess.EntityFramework;
using NebulaLearning.DataAccess.Net4x.Abstract;
using NebulaLearning.Entities.Net4x.Concrete;

namespace NebulaLearning.DataAccess.Net4x.Concrete.EntityFramework
{
    public class ExamCategoryDal:RepositoryBase<ExamCategory,DatabaseContex>, IExamCategoryDal
    {
    }
}

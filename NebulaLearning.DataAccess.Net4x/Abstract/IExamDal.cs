using NebulaLearning.Core.Net4x.DataAccess;
using NebulaLearning.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebulaLearning.DataAccess.Net4x.Abstract
{
    public interface IExamDal:IEntityRepository<Exam>
    {
    }
}

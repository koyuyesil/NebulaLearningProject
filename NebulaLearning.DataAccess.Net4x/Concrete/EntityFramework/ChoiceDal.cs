using NebulaLearning.Core.Net4x.DataAccess.EntityFramework;
using NebulaLearning.DataAccess.Net4x.Abstract;
using NebulaLearning.Entities.Net4x.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebulaLearning.DataAccess.Net4x.Concrete.EntityFramework
{
    public class ChoiceDal : RepositoryBase<Choice, DatabaseContex>, IChoiceDal
    {
    }
}

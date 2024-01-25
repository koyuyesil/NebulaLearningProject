using NebulaLearning.Core.Net4x.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebulaLearning.Entities.Net4x.Concrete
{
    // TODO Complex Type : Step 4
    public class Role:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

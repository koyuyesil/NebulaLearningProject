﻿using NebulaLearning.Core.Net4x.Entities;

namespace NebulaLearning.Entities.Net4x.Concrete
{
    // TODO Complex Type : Step 4
    public class Role:IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}

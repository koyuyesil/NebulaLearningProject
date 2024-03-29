﻿using NebulaLearning.Core.Net4x.Entities;

namespace NebulaLearning.Entities.Net4x.Concrete
{
    public class ExamCategory : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}
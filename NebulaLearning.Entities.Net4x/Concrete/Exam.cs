﻿using NebulaLearning.Core.Net4x.Entities;

namespace NebulaLearning.Entities.Net4x.Concrete
{
    public class Exam : IEntity
    {
        public virtual int ExamId { get; set; }
        public virtual string ExamName { get; set; }
        public virtual string ExamDescription { get; set; }
        public virtual int ExamDuration { get; set; }
        public virtual int ExamResult { get; set; }
        public virtual int ExamCategoryId { get; set; }
    }
}
using NebulaLearning.Core.Net4x.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebulaLearning.Entities.Net4x.ComplexTypes
{
    public class ExamDetail
    {
        public virtual int ExamId { get; set; }
        public virtual string ExamName { get; set; }   
        public virtual string CategoryName { get; set;}
    }
}

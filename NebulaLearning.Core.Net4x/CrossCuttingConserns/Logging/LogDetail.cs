using System.Collections.Generic;

namespace NebulaLearning.Core.Net4x.CrossCuttingConserns.Logging
{
    public class LogDetail
    {
        public string FullName { get; set; }
        public string MethodName { get; set; }   
        public List<LogParameter> Parameters { get; set; }
    }
}

using log4net.Core;
using System;

namespace NebulaLearning.Core.Net4x.CrossCuttingConserns.Logging.Log4Net
{
    [Serializable]// HACK: kullanım riski olabilir
    public class SerializableLogEvent
    { 
        LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }
        public string UserName => _loggingEvent.UserName;
        public object MessageObect => _loggingEvent.MessageObject;
    }
}

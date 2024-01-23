using log4net.Core;
using PostSharp.Serialization;
using System;

namespace NebulaLearning.Core.Net4x.CrossCuttingConserns.Logging.Log4Net
{
    [PSerializable]// HACK: kullanım riski olabilir
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

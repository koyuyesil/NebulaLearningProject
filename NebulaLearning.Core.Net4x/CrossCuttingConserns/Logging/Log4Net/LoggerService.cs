using log4net;

namespace NebulaLearning.Core.Net4x.CrossCuttingConserns.Logging.Log4Net
{
    public class LoggerService
    {
        private ILog _log;
        public LoggerService(ILog log)
        {
            _log = log;
        }
        public bool IsInfoEnabled() => _log.IsInfoEnabled;
        public bool IsDebugEnabled() => _log.IsDebugEnabled;
        public bool IsWarnEnabled() => _log.IsWarnEnabled;
        public bool IsFatalEnabled() => _log.IsFatalEnabled;
        public bool IsErrorEnabled() => _log.IsErrorEnabled;
        public void Info(object logMessage)
        {
            if (IsInfoEnabled()) //property yerine method olarak ele aldı anlamadım intellisense 
            {
                _log.Info(logMessage);
            }
        }
        public void Debug(object logMessage)
        {
            if (IsDebugEnabled()) //property yerine method olarak ele aldı anlamadım intellisense 
            {
                _log.Debug(logMessage);
            }
        }
        public void Warn(object logMessage)
        {
            if (IsWarnEnabled()) //property yerine method olarak ele aldı anlamadım intellisense 
            {
                _log.Warn(logMessage);
            }
        }
        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled()) //property yerine method olarak ele aldı anlamadım intellisense 
            {
                _log.Fatal(logMessage);
            }
        }
        public void Error(object logMessage)
        {
            if (IsErrorEnabled()) //property yerine method olarak ele aldı anlamadım intellisense 
            {
                _log.Error(logMessage);
            }
        }

    }
}

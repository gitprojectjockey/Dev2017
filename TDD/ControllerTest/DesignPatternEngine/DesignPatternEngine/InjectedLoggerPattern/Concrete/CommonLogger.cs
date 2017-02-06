using System;
using DesignPatternEngine.InjectedLoggerPattern.Abstract;
using log4net;


namespace DesignPatternEngine.InjectedLoggerPattern.Concrete
{

    public class CommonLogger : ICommonLogger
    {
        private readonly ILog _commonLog;
        private Exception _ex = null;
        private string _informationMessage = string.Empty;
        private string _exceptionMessage = string.Empty;
        private string _innerExceptionMessage = string.Empty;
        private string _stackTrace = string.Empty;
        private string _warningMessage = string.Empty;
        private string _sender = string.Empty;
        public CommonLogger()
        {
            _commonLog = LogManager.GetLogger("Common Logger");
        }

        public Exception Exp
        {
            set
            { _ex = value; }
        }

        public string InformationMessage
        {
            set { _informationMessage = value; }
        }

        public string WaningMessage
        {
            set { _warningMessage = value; }
        }

        public void LogMessage(object sender)
        {
            _exceptionMessage = _ex != null ? _ex.Message : "";
            _innerExceptionMessage = _ex != null && _ex.InnerException != null ? _ex.InnerException.Message : "";
            _stackTrace = _ex != null ? _ex.StackTrace : "";
            _sender = sender.ToString();

            LogInfoMessage();
            LogDebugMessage();
            LogWarningMessage();
            LogErrorMessage();
            LogFatalErrorMessag();
        }

        private void LogDebugMessage()
        {
            if (_commonLog.IsDebugEnabled)
                _commonLog.DebugFormat("{0} {1} {2} {3} {4}", _sender, _informationMessage, _exceptionMessage, _innerExceptionMessage, _stackTrace);
        }

        private void LogErrorMessage()
        {
            if (_commonLog.IsErrorEnabled)
                _commonLog.ErrorFormat("{0} {1} {2} {3}", _sender, _informationMessage, _exceptionMessage, _innerExceptionMessage);
        }

        private void LogFatalErrorMessag()
        {
            if (_commonLog.IsFatalEnabled)
                _commonLog.FatalFormat("{0} {1} {2} {3} {4}", _sender, _informationMessage, _exceptionMessage, _innerExceptionMessage, _stackTrace);
        }

        private void LogInfoMessage()
        {
            if (_commonLog.IsInfoEnabled)
                _commonLog.InfoFormat("{0} {1}", _sender, _informationMessage);
        }

        private void LogWarningMessage()
        {
            if (_commonLog.IsWarnEnabled)
                _commonLog.WarnFormat("{0} {1} {2}", _sender, _informationMessage, _warningMessage);
        }
    }
}

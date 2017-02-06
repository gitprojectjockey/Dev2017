using System;

namespace DesignPatternEngine.InjectedLoggerPattern.Abstract
{
    public interface ICommonLogger
    {
        void LogMessage(object sender);

        string InformationMessage { set; }

        string WaningMessage { set; }

        Exception Exp { set; }
    }
}

using SuperHeroBuilder.Enums;

namespace SuperHeroBuilder.Interfaces
{
    public interface ILogger
    {
        string[] Messages { get; }

        LogStatus[] LogStatus { get; }

        void Log(string message, LogStatus status);

        ILogger Append(ILogger logger);
    }
}

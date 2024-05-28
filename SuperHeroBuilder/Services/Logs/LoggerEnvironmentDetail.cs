using SuperHeroBuilder.Enums;

namespace SuperHeroBuilder.Services.Logs
{
    public class LoggerEnvironmentDetail
    {
        public static ConsoleColor GetConsoleColor(LogStatus logStatus)
        {
            return logStatus switch
            {
                LogStatus.Failed => ConsoleColor.Red,
                LogStatus.Success => ConsoleColor.Green,
                LogStatus.Invariant => ConsoleColor.White,
                _ => ConsoleColor.Gray,
            };
        }

    }
}

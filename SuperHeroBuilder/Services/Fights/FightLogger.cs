using SuperHeroBuilder.Enums;
using SuperHeroBuilder.Interfaces;

namespace SuperHeroBuilder.Services.Fights
{
    public class FightLogger : IFightLogger
    {
        public string[] Messages { get; private set; } = Array.Empty<string>();

        public LogStatus[] LogStatus { get; private set; } = Array.Empty<LogStatus>();

        public ILogger Append(ILogger logger)
        {
            foreach (var message in logger.Messages)
            {
                Log(message);
            }

            foreach (var status in logger.LogStatus)
            {
                Log(status);
            }
           
            return this;
        }

        public void Log(string message, LogStatus status)
        {
            Messages = Messages.Append(message).ToArray();
            LogStatus = LogStatus.Append(status).ToArray();
        }
        
        private void Log(string message)
        {
            Messages = Messages.Append(message).ToArray();
        }

        private void Log(LogStatus status)
        {
            LogStatus = LogStatus.Append(status).ToArray();
        }
    }
}

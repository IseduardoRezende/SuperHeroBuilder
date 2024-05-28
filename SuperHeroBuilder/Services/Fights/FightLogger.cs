using SuperHeroBuilder.Enums;
using SuperHeroBuilder.Interfaces;
using SuperHeroBuilder.Validations;

namespace SuperHeroBuilder.Services.Fights
{
    public class FightLogger : IFightLogger
    {        
        public string[] Messages { get; private set; } = Array.Empty<string>();

        public LogStatus[] LogStatus { get; private set; } = Array.Empty<LogStatus>();

        public ILogger Append(ILogger logger)
        {
            SuperHeroBuilderInputValidation.ValidateInput(logger, nameof(logger));

            Messages = Messages.Concat(logger.Messages).ToArray();
            LogStatus = LogStatus.Concat(logger.LogStatus).ToArray(); 
            
            return this;
        }

        public void Log(string message, LogStatus status)
        {
            SuperHeroBuilderInputValidation.ValidateInput(message, nameof(message));

            Messages = Messages.Append(message).ToArray();
            LogStatus = LogStatus.Append(status).ToArray();
        }               
    }
}

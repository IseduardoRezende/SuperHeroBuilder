using SuperHeroBuilder.Interfaces;
using SuperHeroBuilder.Services;
using SuperHeroBuilder.Services.Logs;
using SuperHeroBuilder.Validations;

namespace SuperHeroBuilder.Entities
{
    public class FightDetail
    {
        private readonly IFightLogger _log;

        private static readonly string[] _fightDetailDescriptions =
        {
            "It was epic.", "It was a tough battle.", "The world shook.", "The opponent succumbed.",
            "Victory was hard-fought.", "A clash for the ages.", "An unforgettable duel.", "The skies trembled.",
            "A fierce struggle.", "The earth quaked.", "A heroic showdown.", "A legendary fight.",
            "The arena roared.", "An intense confrontation.", "A brutal encounter.", "A remarkable victory.",
            "The battlefield burned.", "An awe-inspiring triumph.", "A glorious battle.", "A thrilling contest."
        };

        public FightDetail(IFightLogger log)
        {
            SuperHeroBuilderInputValidation.ValidateInput(log, nameof(log));

            _log = log;
            Description = Randomize.GetRandomItem(_fightDetailDescriptions);
        }

        public required SuperHero SuperHeroOne { get; init; } = new();

        public required SuperHero SuperHeroTwo { get; init; } = new();

        public required FightDataDetail SuperHeroOneDataDetail { get; init; } = new();

        public required FightDataDetail SuperHeroTwoDataDetail { get; init; } = new();

        public required string Winner { get; init; } = string.Empty;

        public required string Loser { get; init; } = string.Empty;

        public string Description { get; private set; }

        public required bool RightBet { get; init; }

        public void Inspect()
        {
            Console.WriteLine("Fight Details:\n");

            Console.WriteLine($"Super Hero One: \n{SuperHeroOne}\n" +
                              $"Super Hero Two: \n{SuperHeroTwo}\n");

            Thread.Sleep(2000);
            
            for (int i = 0; i < _log.Messages.Length; i++)
            {
                Thread.Sleep(450);

                Console.ForegroundColor = LoggerEnvironmentDetail.GetConsoleColor(_log.LogStatus.ElementAt(i));
                Console.WriteLine(_log.Messages.ElementAt(i));
            }

            Thread.Sleep(1000);

            Console.WriteLine();

            Console.WriteLine($"Winner: {Winner}\n" +
                              $"Looser: {Loser}\n" +
                              $"Right Bet: {RightBet}\n" +
                              $"\n{SuperHeroOne.Name} Data Detail: \n{SuperHeroOneDataDetail}\n" +
                              $"{SuperHeroTwo.Name} Data Detail: \n{SuperHeroTwoDataDetail}\n" +
                              $"Description Around The World: {Description}\n");

            Console.ResetColor();
        }       

        public override string ToString()
        {
            return $"Super Hero One: \n{SuperHeroOne}\n" +
                   $"Super Hero Two: \n{SuperHeroTwo}\n" +
                   $"Winner: {Winner}\n" +
                   $"Looser: {Loser}\n" +
                   $"Right Bet: {RightBet}\n" +
                   $"\n{SuperHeroOne.Name} Data Detail: \n{SuperHeroOneDataDetail}\n" +
                   $"{SuperHeroTwo.Name} Data Detail: \n{SuperHeroTwoDataDetail}\n" +
                   $"Description Around The World: {Description}\n";
        }
    }
}

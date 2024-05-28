using SuperHeroBuilder.Enums;
using SuperHeroBuilder.Interfaces;
using SuperHeroBuilder.Services;

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
            _log = log;
            Description = Randomize.GetRandomItem(_fightDetailDescriptions);
        }

        public SuperHero SuperHeroOne { get; init; } = new();

        public SuperHero SuperHeroTwo { get; init; } = new();       

        public string Winner { get; init; } = string.Empty;

        public string Loser { get; init; } = string.Empty;

        public string Description { get; private set; }

        public bool RightBet { get; init; }

        public void Inspect()
        {
            Console.WriteLine("Fight Details:\n");

            Thread.Sleep(1000);

            Console.WriteLine($"Super Hero One: \n{SuperHeroOne}\n" +
                              $"Super Hero Two: \n{SuperHeroTwo}\n");

            Thread.Sleep(2000);

            for (int i = 0; i < _log.Messages.Length; i++)
            {
                Console.ForegroundColor = GetConsoleColor(_log.LogStatus.ElementAt(i));
                Console.WriteLine(_log.Messages.ElementAt(i));
            }

            Thread.Sleep(1000);

            Console.WriteLine();

            Console.WriteLine($"Winner: {Winner}\n" +
                              $"Looser: {Loser}\n" +
                              $"Right Bet: {RightBet}\n" +
                              $"Description Around The World: {Description}\n");

            Console.ResetColor();
        }

        private static ConsoleColor GetConsoleColor(LogStatus logStatus)
        {
            return logStatus switch
            {
                LogStatus.Failed => ConsoleColor.Red,
                LogStatus.Success => ConsoleColor.Green,
                LogStatus.Irrelevant => ConsoleColor.White,
                _ => ConsoleColor.Gray,
            };
        }

        public override string ToString()
        {
            return $"Super Hero One: \n{SuperHeroOne}\n" +
                   $"Super Hero Two: \n{SuperHeroTwo}\n" +
                   $"Winner: {Winner}\n" +
                   $"Looser: {Loser}\n" +
                   $"Right Bet: {RightBet}\n" +
                   $"Description Around The World: {Description}\n";
        }
    }
}

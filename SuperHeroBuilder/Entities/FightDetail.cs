using SuperHeroBuilder.Services;

namespace SuperHeroBuilder.Entities
{
    public class FightDetail
    {
        private static readonly string[] _fightDetailDescriptions =
        {
            "It was epic.", "It was a tough battle.", "The world shook.", "The opponent succumbed.",
            "Victory was hard-fought.", "A clash for the ages.", "An unforgettable duel.", "The skies trembled.",
            "A fierce struggle.", "The earth quaked.", "A heroic showdown.", "A legendary fight.",
            "The arena roared.", "An intense confrontation.", "A brutal encounter.", "A remarkable victory.",
            "The battlefield burned.", "An awe-inspiring triumph.", "A glorious battle.", "A thrilling contest."
        };

        public FightDetail()
        {
            Description = Randomize.GetRandomItem(_fightDetailDescriptions);
        }

        public SuperHero Winner { get; set; } = new();

        public SuperHero Loser { get; set; } = new();

        public string Description { get; private set; }

        public bool RightBet { get; set; }

        public override string ToString()
        {
            return $"Winner:\n{Winner}\n" +
                   $"Looser:\n{Loser}\n" +
                   $"Right Bet: {RightBet}\n" +
                   $"Description Around The World: {Description}\n";
        }
    }
}

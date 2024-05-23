namespace SuperHeroBuilder.Entities
{
    public class FightDetail
    {
        public SuperHero Winner { get; set; } = new();

        public SuperHero Looser { get; set; } = new();

        public bool RightBet { get; set; }

        public double AttackDifference { get; set; }

        public double DefenseDifference { get; set; }

        public override string ToString()
        {
            return $"Winner:\n{Winner}\n" +
                   $"Looser:\n{Looser}\n" +
                   $"Right Bet: {RightBet}\n" +
                   $"Attack Difference: {AttackDifference}\n" +
                   $"Defense Difference: {DefenseDifference}\n";
        }
    }
}

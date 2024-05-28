namespace SuperHeroBuilder.Entities
{
    public class FightDataDetail
    {
        public FightDataDetail() { }

        public FightDataDetail(int finalAttack, int finalDefense)
        {
            FinalAttack = finalAttack;
            FinalDefense = finalDefense;
        }

        public int FinalAttack { get; }

        public int FinalDefense { get; }

        public override string ToString()
        {
            return $"Final Attack: {FinalAttack}\n" +
                   $"Final Defense: {FinalDefense}\n";
        }
    }
}

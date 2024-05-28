using SuperHeroBuilder.Entities;

namespace SuperHeroBuilder.Services.Fights
{
    public class FightLoggerMessage
    {
        private readonly SuperHero _superHero;
        private readonly SuperHero _superHeroAdversary;

        public FightLoggerMessage(SuperHero superHero, SuperHero superHeroAdversary)
        {
            _superHero = superHero;
            _superHeroAdversary = superHeroAdversary;
        }

        public string GetAttackFailedMessage(string superHeroPS, string superHeroAdversaryEquipment)
        {
            return $"{_superHero.Name} ({superHeroPS}) was 'Blocked' by {_superHeroAdversary.Name} ({superHeroAdversaryEquipment})";
        }

        public string GetDefenseFailedMessage(string superHeroEquipment, string superHeroAdversaryPS)
        {
            return $"{_superHero.Name} ({superHeroEquipment}) was 'Destroyed' by {_superHeroAdversary.Name} ({superHeroAdversaryPS})";
        }

        public string GetAttackSucessMessage(string superHeroPS)
        {
            return $"{_superHero.Name} ({superHeroPS}) was 'Mortal' for {_superHeroAdversary.Name} (Equipments)";
        }

        public string GetDefenseSucessMessage(string superHeroEquipment)
        {
            return $"{_superHero.Name} ({superHeroEquipment}) was 'Unbeatable' for {_superHeroAdversary.Name} (Powers and Skills)";
        }
    }
}

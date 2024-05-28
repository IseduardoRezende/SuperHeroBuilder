using SuperHeroBuilder.Entities;
using SuperHeroBuilder.Validations;

namespace SuperHeroBuilder.Services.Fights
{
    public class FightLoggerMessage
    {
        private readonly SuperHero _superHero;
        private readonly SuperHero _superHeroAdversary;

        public FightLoggerMessage(SuperHero superHero, SuperHero superHeroAdversary)
        {
            SuperHeroBuilderInputValidation.ValidateInput(superHero, nameof(superHero));
            SuperHeroBuilderInputValidation.ValidateInput(superHeroAdversary, nameof(superHeroAdversary));

            _superHero = superHero;
            _superHeroAdversary = superHeroAdversary;
        }

        public string GetAttackFailedMessage(string superHeroPS, string superHeroAdversaryEquipment)
        {
            SuperHeroBuilderInputValidation.ValidateInput(superHeroPS, nameof(superHeroPS));
            SuperHeroBuilderInputValidation.ValidateInput(superHeroAdversaryEquipment, nameof(superHeroAdversaryEquipment));

            return $"{_superHero.Name} ({superHeroPS}) was 'Blocked' by {_superHeroAdversary.Name} ({superHeroAdversaryEquipment})";
        }

        public string GetDefenseFailedMessage(string superHeroEquipment, string superHeroAdversaryPS)
        {
            SuperHeroBuilderInputValidation.ValidateInput(superHeroEquipment, nameof(superHeroEquipment));
            SuperHeroBuilderInputValidation.ValidateInput(superHeroAdversaryPS, nameof(superHeroAdversaryPS));

            return $"{_superHero.Name} ({superHeroEquipment}) was 'Destroyed' by {_superHeroAdversary.Name} ({superHeroAdversaryPS})";
        }

        public string GetAttackSucessMessage(string superHeroPS)
        {
            SuperHeroBuilderInputValidation.ValidateInput(superHeroPS, nameof(superHeroPS));

            return $"{_superHero.Name} ({superHeroPS}) was 'Mortal' for {_superHeroAdversary.Name} (Equipments)";
        }

        public string GetDefenseSucessMessage(string superHeroEquipment)
        {
            SuperHeroBuilderInputValidation.ValidateInput(superHeroEquipment, nameof(superHeroEquipment));

            return $"{_superHero.Name} ({superHeroEquipment}) was 'Unbeatable' for {_superHeroAdversary.Name} (Powers and Skills)";
        }
    }
}

using SuperHeroBuilder.Entities;
using SuperHeroBuilder.Interfaces;
using SuperHeroBuilder.Validations;

namespace SuperHeroBuilder.Builders
{
    public class SuperHeroBuilder : ISuperHeroBuilder
    {
        private readonly SuperHero _superHero = new();

        public SuperHero GetSuperHero()
        {
            return _superHero;
        }

        public ISuperHeroBuilder BuildEquipments(params string[] equipments)
        {
            SuperHeroBuilderInputValidation.ValidateInputs(equipments, nameof(equipments));

            _superHero.Equipments = equipments;
            return this;
        }

        public ISuperHeroBuilder BuildName(string name)
        {
            SuperHeroBuilderInputValidation.ValidateInput(name, nameof(name));

            _superHero.Name = name;
            return this;
        }

        public ISuperHeroBuilder BuildPowers(params string[] powers)
        {
            SuperHeroBuilderInputValidation.ValidateInputs(powers, nameof(powers));

            _superHero.Powers = powers;
            return this;
        }

        public ISuperHeroBuilder BuildSecretIdentity(string secretIdentity)
        {
            SuperHeroBuilderInputValidation.ValidateInput(secretIdentity, nameof(secretIdentity));

            _superHero.SecretIdentity = secretIdentity;
            return this;
        }

        public ISuperHeroBuilder BuildSkills(params string[] skills)
        {
            SuperHeroBuilderInputValidation.ValidateInputs(skills, nameof(skills));

            _superHero.Skills = skills;
            return this;
        }

        public ISuperHeroBuilder BuildAttack(int attack)
        {
            _superHero.Attack = attack;
            return this;
        }

        public ISuperHeroBuilder BuildDefense(int defense)
        {
            _superHero.Defense = defense;   
            return this;
        }
    }
}

using SuperHeroBuilder.Builders;
using SuperHeroBuilder.Entities;
using SuperHeroBuilder.Enums;

namespace SuperHeroBuilder
{
    public class Fight
    {
        private readonly SuperHero _superHeroOne = new();
        private readonly SuperHero _superHeroTwo = new();
        private readonly Fighters _bet;

        public Fight(Fighters bet)
        {
            _superHeroOne = new RandomizeFight().BuildSuperHero();
            _superHeroTwo = new RandomizeFight().ExceptInfos(_superHeroOne.Name, _superHeroOne.SecretIdentity).BuildSuperHero();
            _bet = bet;
        }

        public FightDetail Combat()
        {
            return new FightDetail
            {
                Winner = GetWinner(),
                Looser = GetLooser(),
                AttackDifference = GetAttackDifference(),
                DefenseDifference = GetDefenseDifference(),
                RightBet = WasRightBet()
            };
        }

        private SuperHero GetWinner()
        {
            if (_superHeroOne.Attack > _superHeroTwo.Attack && _superHeroOne.Defense > _superHeroTwo.Defense)
                return _superHeroOne;

            if (_superHeroTwo.Attack > _superHeroOne.Attack && _superHeroTwo.Defense > _superHeroOne.Defense)
                return _superHeroTwo;

            if (_superHeroOne.Defense > _superHeroTwo.Attack && _superHeroOne.Defense > _superHeroTwo.Defense)
                return _superHeroOne;

            if (_superHeroTwo.Defense > _superHeroOne.Attack && _superHeroTwo.Defense > _superHeroOne.Defense)
                return _superHeroTwo;

            if (_superHeroOne.Attack > _superHeroTwo.Defense && _superHeroOne.Attack > _superHeroTwo.Attack)
                return _superHeroOne;

            if (_superHeroTwo.Attack > _superHeroOne.Defense && _superHeroTwo.Attack > _superHeroOne.Attack)
                return _superHeroTwo;

            return new[] { _superHeroOne, _superHeroTwo }.ElementAt(Random.Shared.Next(maxValue: 2));
        }

        private SuperHero GetLooser()
        {
            return GetWinner() == _superHeroOne ? _superHeroTwo : _superHeroOne;
        }

        private double GetAttackDifference()
        {
            return GetWinner().Attack - GetLooser().Attack;
        }

        private double GetDefenseDifference()
        {
            return GetWinner().Defense - GetLooser().Defense;
        }

        private bool WasRightBet()
        {
            if (_bet is Fighters.One && GetWinner() == _superHeroOne)
                return true;

            if (_bet is Fighters.Two && GetWinner() == _superHeroTwo)
                return true;

            return false;
        }
    }
}

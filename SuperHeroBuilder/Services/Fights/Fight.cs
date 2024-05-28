using SuperHeroBuilder.Entities;
using SuperHeroBuilder.Enums;
using SuperHeroBuilder.Interfaces;

namespace SuperHeroBuilder.Services.Fights
{
    public class Fight
    {
        private readonly Fighter _bet;
        private readonly SuperHero _superHeroOne;
        private readonly SuperHero _superHeroTwo;

        private IFightLogger _fightLogger = new FightLogger();

        public Fight(Fighter bet)
        {
            _bet = bet;
            _fightLogger.Log("Fight Started !", LogStatus.Irrelevant);
            _superHeroOne = new FightRandomizer().BuildSuperHero();
            _superHeroTwo = new FightRandomizer().ExceptInfos(_superHeroOne.Name, _superHeroOne.SecretIdentity).BuildSuperHero();
        }

        public FightDetail Combat()
        {
            var winner = GetWinner();
            var loser  = GetLoser(winner);

            _fightLogger.Log("Fight Ended !", LogStatus.Irrelevant);

            return new FightDetail(log: _fightLogger)
            {
                Loser        = loser.Name,
                Winner       = winner.Name,
                SuperHeroOne = _superHeroOne,
                SuperHeroTwo = _superHeroTwo,
                RightBet     = WasRightBet(winner),
            };
        }

        private SuperHero GetWinner()
        {
            var totalPointsSuperHeroOne = CalculateTotalPoints(_superHeroOne, _superHeroTwo);
            var totalPointsSuperHeroTwo = CalculateTotalPoints(_superHeroTwo, _superHeroOne);

            if (totalPointsSuperHeroOne == totalPointsSuperHeroTwo)
                return Randomize.GetRandomItem(new[] { _superHeroOne, _superHeroTwo });

            return totalPointsSuperHeroOne > totalPointsSuperHeroTwo ? _superHeroOne : _superHeroTwo;
        }

        private SuperHero GetLoser(SuperHero winner)
        {
            return winner == _superHeroOne ? _superHeroTwo : _superHeroOne;
        }

        private bool WasRightBet(SuperHero winner)
        {
            return _bet is Fighter.One && winner == _superHeroOne
                                       ||
                   _bet is Fighter.Two && winner == _superHeroTwo;
        }

        private int CalculateTotalPoints(SuperHero superHero, SuperHero superHeroAdversary)
        {
            return CalculateAttackPoints(superHero, superHeroAdversary) + CalculateDefensePoints(superHero, superHeroAdversary);
        }

        private int CalculateAttackPoints(SuperHero superHero, SuperHero superHeroAdversary)
        {            
            var log = new FightData(superHero, superHeroAdversary)
                          .GetAttack(out int attack);

            _fightLogger = (IFightLogger)_fightLogger.Append(log);

            return attack;
        }        

        private int CalculateDefensePoints(SuperHero superHero, SuperHero superHeroAdversary)
        {            
            var log = new FightData(superHero, superHeroAdversary)
                          .GetDefense(out int defense);

            _fightLogger = (IFightLogger)_fightLogger.Append(log);

            return defense;
        }       
    }
}

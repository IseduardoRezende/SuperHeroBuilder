using SuperHeroBuilder.Entities;
using SuperHeroBuilder.Enums;

namespace SuperHeroBuilder.Services
{
    public class Fight
    {
        private readonly Fighter _bet;
        private readonly SuperHero _superHeroOne = new();
        private readonly SuperHero _superHeroTwo = new();

        public Fight(Fighter bet)
        {
            _bet = bet;
            _superHeroOne = new RandomizeFight().BuildSuperHero();
            _superHeroTwo = new RandomizeFight().ExceptInfos(_superHeroOne.Name, _superHeroOne.SecretIdentity).BuildSuperHero();
        }
        
        public FightDetail Combat()
        {
            var winner = GetWinner();
            var loser = GetLoser(winner);

            return new FightDetail
            {
                Loser = loser,
                Winner = winner,
                RightBet = WasRightBet(winner)
            };
        }

        private SuperHero GetWinner()
        {
            var totalPointsSuperHeroOne = CalculateTotalPoints(_superHeroOne, _superHeroTwo);
            var totalPointsSuperHeroTwo = CalculateTotalPoints(_superHeroTwo, _superHeroOne);

            if (totalPointsSuperHeroOne == totalPointsSuperHeroTwo)
                return new[] { _superHeroOne, _superHeroTwo }.ElementAt(Random.Shared.Next(maxValue: 2));

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
            superHero.Attack  = CalculatePSPoints(superHero, superHeroAdversary);
            superHero.Defense = CalculateEquipmentsPoints(superHero, superHeroAdversary);
        
            return superHero.Attack + superHero.Defense;
        }      

        private int CalculatePSPoints(SuperHero superHero, SuperHero superHeroAdversary)
        {
            var totalPS = superHero.Powers.Length + superHero.Skills.Length;

            var psList = superHero.Powers.Concat(superHero.Skills).ToArray();

            FightData.CancelPSByAdversaryEquipments(psList, superHeroAdversary.Equipments, ref totalPS);

            return totalPS;
        }

        private int CalculateEquipmentsPoints(SuperHero superHero, SuperHero superHeroAdversary)
        {
            var totalEquipments = superHero.Equipments.Length;

            var adversaryPSList = superHeroAdversary.Powers.Concat(superHeroAdversary.Skills).ToArray();

            FightData.CancelEquipmentsByAdversaryPS(superHero.Equipments, adversaryPSList, ref totalEquipments);

            return totalEquipments;
        }
    }
}

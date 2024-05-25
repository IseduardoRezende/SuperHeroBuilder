using SuperHeroBuilder.Entities;

namespace SuperHeroBuilder.Interfaces
{
    public interface ISuperHeroBuilder
    {
        ISuperHeroBuilder BuildName(string name);

        ISuperHeroBuilder BuildSecretIdentity(string secretIdentity);

        ISuperHeroBuilder BuildPowers(params string[] powers);

        ISuperHeroBuilder BuildEquipments(params string[] equipments);

        ISuperHeroBuilder BuildSkills(params string[] skills);

        ISuperHeroBuilder BuildAttack(int attack);

        ISuperHeroBuilder BuildDefense(int defense);

        SuperHero GetSuperHero();        
    }
}

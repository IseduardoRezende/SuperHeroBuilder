using SuperHeroBuilder.Entities;
using SuperHeroBuilder.Validations;

namespace SuperHeroBuilder.Services
{
    public class RandomizeFight : Randomize
    {
        private string[] _superHerosNames =
        {
            "Destroyer", "Slayer", "Invisible", "Phantom", "Vigilant", "Guardian", "Storm", "Shadow", "Lightning", "Night Hawk",
            "Solar Knight", "Shadow Master", "Steel Warrior", "Wild Spirit", "Sentry", "Cutting Wind", "Black Ray", "Golden Phoenix",
            "Silver Titan", "Lone Wolf"
        };

        private string[] _superHerosSecretIdentities =
        {
            "John Smith", "Emily Johnson", "Michael Brown", "Sarah Davis", "David Wilson", "Laura Martinez", "James Anderson", "Karen Thomas",
            "Robert Taylor", "Nancy Moore", "Charles White", "Jessica Harris", "Daniel Clark", "Amy Lewis", "Matthew Robinson", "Angela Walker",
            "Joseph Hall", "Rebecca Young", "Christopher King", "Patricia Wright"
        };

        private string[] _superHerosPowers =
        {
            "Super Strength", "Invisibility", "Flight", "Telepathy", "Telekinesis", "Super Speed", "Shape Shifting", "Energy Blasts",
            "Time Manipulation", "Invulnerability", "Healing Factor", "Elemental Control", "X-Ray Vision", "Mind Control", "Force Fields",
            "Animal Communication", "Weather Control", "Dimensional Travel", "Heat Vision", "Super Agility"
        };

        private string[] _superHerosSkills =
        {
            "Martial Arts", "Stealth", "Marksmanship", "Hacking", "Swordsmanship", "Acrobatics", "Tactical Planning", "Espionage",
            "Survival Skills", "Hand-to-Hand Combat", "Mechanics", "Linguistics", "Tracking", "Escape Artist", "Piloting",
            "Interrogation", "Forensics", "Disguise", "Chemistry", "Engineering"
        };

        private string[] _superHerosEquipments =
        {
            "Power Suit", "Invisibility Cloak", "Energy Shield", "Grappling Hook", "Jetpack", "Utility Belt", "Laser Gun",
            "Healing Potion", "Teleportation Device", "Magnetic Boots", "Hologram Projector", "Night Vision Goggles", "Nano Suit",
            "Force Field Generator", "Sonic Blaster", "Plasma Sword", "Cybernetic Implants", "Anti-Gravity Boots", "Exoskeleton",
            "Energy Gauntlets"
        };

        public SuperHero BuildSuperHero()
        {
            return new MethodChainingSuperHeroBuilder()
                       .BuildName(GetRandomItem(_superHerosNames))
                       .BuildPowers(GetRandomItems(_superHerosPowers))
                       .BuildSkills(GetRandomItems(_superHerosSkills))
                       .BuildEquipments(GetRandomItems(_superHerosEquipments))
                       .BuildSecretIdentity(GetRandomItem(_superHerosSecretIdentities))
                       .GetSuperHero();
        }

        public RandomizeFight ExceptInfos(string superHeroName, string superHeroSecretIdentity)
        {
            SuperHeroBuilderInputValidation.ValidateInput(superHeroName, nameof(superHeroName));
            SuperHeroBuilderInputValidation.ValidateInput(superHeroSecretIdentity, nameof(superHeroSecretIdentity));

            _superHerosNames = _superHerosNames.Except(new[] { superHeroName }).ToArray();
            _superHerosSecretIdentities = _superHerosSecretIdentities.Except(new[] { superHeroSecretIdentity }).ToArray();
            return this;
        }
    }
}

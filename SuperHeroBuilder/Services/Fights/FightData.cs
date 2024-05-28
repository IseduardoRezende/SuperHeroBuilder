using SuperHeroBuilder.Entities;
using SuperHeroBuilder.Enums;
using SuperHeroBuilder.Interfaces;

namespace SuperHeroBuilder.Services.Fights
{
    public class FightData
    {
        private readonly IFightLogger _fightLogger = new FightLogger();
        private readonly SuperHero _superHero;
        private readonly SuperHero _superHeroAdversary;

        private static readonly Dictionary<string, string[]> _equipmentsForPower = new()
        {
            { "Super Strength",       new[] { "Energy Shield", "Exoskeleton", "Power Suit" } },
            { "Invisibility",         new[] { "Hologram Projector", "Night Vision Goggles", "Energy Shield" } },
            { "Flight",               new[] { "Anti-Gravity Boots", "Magnetic Boots", "Force Field Generator" } },
            { "Telepathy",            new[] { "Cybernetic Implants", "Hologram Projector", "Force Field Generator" } },
            { "Telekinesis",          new[] { "Energy Shield", "Exoskeleton", "Force Field Generator" } },
            { "Super Speed",          new[] { "Energy Shield", "Magnetic Boots", "Exoskeleton" } },
            { "Shape Shifting",       new[] { "Hologram Projector", "Energy Shield", "Nano Suit" } },
            { "Energy Blasts",        new[] { "Energy Shield", "Force Field Generator", "Power Suit" } },
            { "Time Manipulation",    new[] { "Teleportation Device", "Force Field Generator", "Nano Suit" } },
            { "Invulnerability",      new[] { "Plasma Sword", "Sonic Blaster", "Energy Gauntlets" } },
            { "Healing Factor",       new[] { "Plasma Sword", "Sonic Blaster", "Energy Gauntlets" } },
            { "Elemental Control",    new[] { "Energy Shield", "Force Field Generator", "Power Suit" } },
            { "X-Ray Vision",         new[] { "Nano Suit", "Energy Shield", "Hologram Projector" } },
            { "Mind Control",         new[] { "Cybernetic Implants", "Hologram Projector", "Nano Suit" } },
            { "Force Fields",         new[] { "Sonic Blaster", "Plasma Sword", "Energy Gauntlets" } },
            { "Animal Communication", new[] { "Sonic Blaster", "Hologram Projector", "Nano Suit" } },
            { "Weather Control",      new[] { "Energy Shield", "Force Field Generator", "Power Suit" } },
            { "Dimensional Travel",   new[] { "Teleportation Device", "Force Field Generator", "Nano Suit" } },
            { "Heat Vision",          new[] { "Energy Shield", "Force Field Generator", "Power Suit" } },
            { "Super Agility",        new[] { "Energy Shield", "Magnetic Boots", "Exoskeleton" } }
        };

        private static readonly Dictionary<string, string[]> _equipmentsForSkill = new()
        {
            { "Martial Arts",        new[] { "Energy Shield", "Exoskeleton", "Power Suit" } },
            { "Stealth",             new[] { "Night Vision Goggles", "Invisibility Cloak", "Hologram Projector" } },
            { "Marksmanship",        new[] { "Energy Shield", "Force Field Generator", "Exoskeleton" } },
            { "Hacking",             new[] { "Cybernetic Implants", "Power Suit", "Nano Suit" } },
            { "Swordsmanship",       new[] { "Energy Shield", "Exoskeleton", "Power Suit" } },
            { "Acrobatics",          new[] { "Energy Shield", "Magnetic Boots", "Exoskeleton" } },
            { "Tactical Planning",   new[] { "Hologram Projector", "Nano Suit", "Utility Belt" } },
            { "Espionage",           new[] { "Hologram Projector", "Invisibility Cloak", "Night Vision Goggles" } },
            { "Survival Skills",     new[] { "Utility Belt", "Healing Potion", "Nano Suit" } },
            { "Hand-to-Hand Combat", new[] { "Energy Shield", "Exoskeleton", "Power Suit" } },
            { "Mechanics",           new[] { "Nano Suit", "Cybernetic Implants", "Utility Belt" } },
            { "Linguistics",         new[] { "Cybernetic Implants", "Nano Suit", "Hologram Projector" } },
            { "Tracking",            new[] { "Hologram Projector", "Night Vision Goggles", "Nano Suit" } },
            { "Escape Artist",       new[] { "Energy Shield", "Teleportation Device", "Nano Suit" } },
            { "Piloting",            new[] { "Cybernetic Implants", "Anti-Gravity Boots", "Jetpack" } },
            { "Interrogation",       new[] { "Hologram Projector", "Cybernetic Implants", "Nano Suit" } },
            { "Forensics",           new[] { "Nano Suit", "Hologram Projector", "Night Vision Goggles" } },
            { "Disguise",            new[] { "Hologram Projector", "Nano Suit", "Invisibility Cloak" } },
            { "Chemistry",           new[] { "Utility Belt", "Nano Suit", "Power Suit" } },
            { "Engineering",         new[] { "Nano Suit", "Cybernetic Implants", "Utility Belt" } }
        };

        private static readonly Dictionary<string, string[]> _powersForEquipment = new()
        {
            { "Energy Shield",          new[] { "Energy Blasts", "Telekinesis", "Super Strength" } },
            { "Exoskeleton",            new[] { "Super Strength", "Telekinesis" } },
            { "Power Suit",             new[] { "Energy Blasts", "Super Strength" } },
            { "Hologram Projector",     new[] { "Telepathy", "Invisibility", "Shape Shifting" } },
            { "Night Vision Goggles",   new[] { "Invisibility", "Stealth" } },
            { "Force Field Generator",  new[] { "Telekinesis", "Energy Blasts", "Elemental Control" } },
            { "Cybernetic Implants",    new[] { "Telepathy", "Mind Control" } },
            { "Nano Suit",              new[] { "Shape Shifting", "Telekinesis" } },
            { "Teleportation Device",   new[] { "Dimensional Travel", "Time Manipulation" } },
            { "Plasma Sword",           new[] { "Invulnerability", "Healing Factor" } },
            { "Sonic Blaster",          new[] { "Invulnerability", "Healing Factor" } },
            { "Energy Gauntlets",       new[] { "Invulnerability", "Healing Factor" } },
            { "Anti-Gravity Boots",     new[] { "Flight", "Super Agility" } },
            { "Magnetic Boots",         new[] { "Flight", "Super Speed" } },
            { "Invisibility Cloak",     new[] { "Invisibility", "Stealth" } },
            { "Jetpack",                new[] { "Flight", "Super Agility" } },
            { "Utility Belt",           new[] { "Tactical Planning", "Survival Skills" } },
            { "Healing Potion",         new[] { "Healing Factor", "Survival Skills" } },
            { "Laser Gun",              new[] { "Energy Blasts", "Heat Vision" } },
            { "Grappling Hook",         new[] { "Super Agility", "Super Strength" } }
        };

        private static readonly Dictionary<string, string[]> _skillsForEquipment = new()
        {
            { "Energy Shield",          new[] { "Marksmanship", "Swordsmanship" } },
            { "Exoskeleton",            new[] { "Martial Arts", "Hand-to-Hand Combat" } },
            { "Power Suit",             new[] { "Swordsmanship", "Martial Arts" } },
            { "Hologram Projector",     new[] { "Tactical Planning", "Espionage" } },
            { "Night Vision Goggles",   new[] { "Stealth", "Tracking" } },
            { "Force Field Generator",  new[] { "Marksmanship", "Swordsmanship" } },
            { "Cybernetic Implants",    new[] { "Hacking", "Interrogation" } },
            { "Nano Suit",              new[] { "Escape Artist", "Stealth" } },
            { "Teleportation Device",   new[] { "Escape Artist", "Piloting" } },
            { "Plasma Sword",           new[] { "Swordsmanship", "Martial Arts" } },
            { "Sonic Blaster",          new[] { "Marksmanship", "Swordsmanship" } },
            { "Energy Gauntlets",       new[] { "Hand-to-Hand Combat", "Martial Arts" } },
            { "Anti-Gravity Boots",     new[] { "Acrobatics", "Piloting" } },
            { "Magnetic Boots",         new[] { "Acrobatics", "Piloting" } },
            { "Invisibility Cloak",     new[] { "Stealth", "Espionage" } },
            { "Jetpack",                new[] { "Piloting", "Acrobatics" } },
            { "Utility Belt",           new[] { "Survival Skills", "Tactical Planning" } },
            { "Healing Potion",         new[] { "Survival Skills", "Hand-to-Hand Combat" } },
            { "Laser Gun",              new[] { "Marksmanship", "Hacking" } },
            { "Grappling Hook",         new[] { "Acrobatics", "Escape Artist" } }
        };

        public FightData(SuperHero superHero, SuperHero superHeroAdversary)
        {
            _superHero = superHero;
            _superHeroAdversary = superHeroAdversary;
        }

        public IFightLogger GetAttack(out int attack)
        {
            attack = _superHero.Powers.Length + _superHero.Skills.Length;

            var psList = _superHero.Powers.Concat(_superHero.Skills).ToArray();

            CalculateAttackByAdversaryDefense(psList, _superHeroAdversary.Equipments, ref attack);

            return _fightLogger;
        }

        private void CalculateAttackByAdversaryDefense(string[] superHeroPSList, string[] superHeroAdversaryEquipments, ref int attack)
        {
            var equipmentsForPower = Array.Empty<string>();
            var equipmentsForSkill = Array.Empty<string>();

            int chancesToCancel = superHeroAdversaryEquipments.Length;

            foreach (var superHeroPS in superHeroPSList)
            {
                if (_equipmentsForPower.TryGetValue(superHeroPS, out equipmentsForPower) || _equipmentsForSkill.TryGetValue(superHeroPS, out equipmentsForSkill))
                {
                    equipmentsForPower ??= Array.Empty<string>();
                    equipmentsForSkill ??= Array.Empty<string>();

                    foreach (var equipment in superHeroAdversaryEquipments)
                    {
                        if (equipmentsForPower.Contains(equipment) || equipmentsForSkill.Contains(equipment))
                        {
                            _fightLogger.Log(GetAttackCancelMessage(superHeroPS, equipment), LogStatus.Failed);
                            attack--;
                            break;
                        }

                        chancesToCancel--;

                        if (chancesToCancel == 0)
                        {
                            _fightLogger.Log(GetAttackSucessMessage(superHeroPS), LogStatus.Success);
                        }
                    }

                    chancesToCancel = superHeroAdversaryEquipments.Length;
                }
            }
        }

        public IFightLogger GetDefense(out int defense)
        {
            defense = _superHero.Equipments.Length;

            var adversaryPSList = _superHeroAdversary.Powers.Concat(_superHeroAdversary.Skills).ToArray();

            CalculateDefenseByAdversaryAttack(_superHero.Equipments, adversaryPSList, ref defense);

            return _fightLogger;
        }

        private void CalculateDefenseByAdversaryAttack(string[] superHeroEquipments, string[] superHeroAdversaryPSList, ref int defense)
        {
            var powersForEquipment = Array.Empty<string>();
            var skillsForEquipment = Array.Empty<string>();

            int chancesToCancel = superHeroAdversaryPSList.Length;

            foreach (var superHeroEquipment in superHeroEquipments)
            {
                if (_powersForEquipment.TryGetValue(superHeroEquipment, out powersForEquipment) || _skillsForEquipment.TryGetValue(superHeroEquipment, out skillsForEquipment))
                {
                    powersForEquipment ??= Array.Empty<string>();
                    skillsForEquipment ??= Array.Empty<string>();

                    foreach (var ps in superHeroAdversaryPSList)
                    {
                        if (powersForEquipment.Contains(ps) || skillsForEquipment.Contains(ps))
                        {
                            _fightLogger.Log(GetDefenseCancelMessage(superHeroEquipment, ps), LogStatus.Failed);
                            defense--;
                            break;
                        }

                        chancesToCancel--;

                        if (chancesToCancel == 0)
                        {
                            _fightLogger.Log(GetDefenseSucessMessage(superHeroEquipment), LogStatus.Success);
                        }
                    }

                    chancesToCancel = superHeroAdversaryPSList.Length;
                }
            }
        }

        private string GetAttackCancelMessage(string superHeroPS, string superHeroAdversaryEquipment)
        {
            return $"{_superHero.Name} ({superHeroPS}) was 'Blocked' by {_superHeroAdversary.Name} ({superHeroAdversaryEquipment})";
        }

        private string GetDefenseCancelMessage(string superHeroEquipment, string superHeroAdversaryPS)
        {
            return $"{_superHero.Name} ({superHeroEquipment}) was 'Destroyed' by {_superHeroAdversary.Name} ({superHeroAdversaryPS})";
        }

        private string GetAttackSucessMessage(string superHeroPS)
        {
            return $"{_superHero.Name} ({superHeroPS}) was 'Mortal' into {_superHeroAdversary.Name} (Equipments)";
        }

        private string GetDefenseSucessMessage(string superHeroEquipment)
        {
            return $"{_superHero.Name} ({superHeroEquipment}) was 'Unbeatable' into {_superHeroAdversary.Name} (Powers and Skills)";
        }
    }
}

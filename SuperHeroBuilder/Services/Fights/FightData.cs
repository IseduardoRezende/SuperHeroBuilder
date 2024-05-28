using SuperHeroBuilder.Entities;
using SuperHeroBuilder.Enums;
using SuperHeroBuilder.Interfaces;
using SuperHeroBuilder.Validations;

namespace SuperHeroBuilder.Services.Fights
{
    public class FightData
    {
        private readonly IFightLogger _fightLogger;
        private readonly SuperHero _superHero;
        private readonly SuperHero _superHeroAdversary;
        private readonly FightLoggerMessage _fightLoggerMessage;

        private static readonly Dictionary<string, string[]> _equipmentsForPower = new()
        {
            { "Super Strength",       new[] { "Energy Shield", "Exoskeleton" } },
            { "Invisibility",         new[] { "Hologram Projector", "Night Vision Goggles" } },
            { "Flight",               new[] { "Anti-Gravity Boots", "Magnetic Boots" } },
            { "Telepathy",            new[] { "Cybernetic Implants", "Hologram Projector" } },
            { "Telekinesis",          new[] { "Energy Shield", "Exoskeleton" } },
            { "Super Speed",          new[] { "Energy Shield", "Magnetic Boots" } },
            { "Shape Shifting",       new[] { "Hologram Projector", "Nano Suit" } },
            { "Energy Blasts",        new[] { "Energy Shield", "Force Field Generator" } },
            { "Time Manipulation",    new[] { "Teleportation Device", "Nano Suit" } },
            { "Invulnerability",      new[] { "Plasma Sword", "Sonic Blaster" } },
            { "Healing Factor",       new[] { "Plasma Sword", "Sonic Blaster" } },
            { "Elemental Control",    new[] { "Energy Shield", "Force Field Generator" } },
            { "X-Ray Vision",         new[] { "Nano Suit", "Hologram Projector" } },
            { "Mind Control",         new[] { "Cybernetic Implants", "Nano Suit" } },
            { "Force Fields",         new[] { "Sonic Blaster", "Plasma Sword" } },
            { "Animal Communication", new[] { "Sonic Blaster", "Nano Suit" } },
            { "Weather Control",      new[] { "Energy Shield", "Force Field Generator" } },
            { "Dimensional Travel",   new[] { "Teleportation Device", "Nano Suit" } },
            { "Heat Vision",          new[] { "Energy Shield", "Force Field Generator" } },
            { "Super Agility",        new[] { "Energy Shield", "Magnetic Boots" } }
        };

        private static readonly Dictionary<string, string[]> _equipmentsForSkill = new()
        {
            { "Martial Arts",        new[] { "Energy Shield", "Exoskeleton" } },
            { "Stealth",             new[] { "Night Vision Goggles", "Invisibility Cloak" } },
            { "Marksmanship",        new[] { "Energy Shield", "Force Field Generator" } },
            { "Hacking",             new[] { "Cybernetic Implants", "Nano Suit" } },
            { "Swordsmanship",       new[] { "Energy Shield", "Exoskeleton" } },
            { "Acrobatics",          new[] { "Energy Shield", "Magnetic Boots" } },
            { "Tactical Planning",   new[] { "Hologram Projector", "Utility Belt" } },
            { "Espionage",           new[] { "Hologram Projector", "Invisibility Cloak" } },
            { "Survival Skills",     new[] { "Utility Belt", "Healing Potion" } },
            { "Hand-to-Hand Combat", new[] { "Energy Shield", "Exoskeleton" } },
            { "Mechanics",           new[] { "Nano Suit", "Cybernetic Implants" } },
            { "Linguistics",         new[] { "Cybernetic Implants", "Hologram Projector" } },
            { "Tracking",            new[] { "Hologram Projector", "Night Vision Goggles" } },
            { "Escape Artist",       new[] { "Energy Shield", "Teleportation Device" } },
            { "Piloting",            new[] { "Cybernetic Implants", "Jetpack" } },
            { "Interrogation",       new[] { "Hologram Projector", "Cybernetic Implants" } },
            { "Forensics",           new[] { "Nano Suit", "Night Vision Goggles" } },
            { "Disguise",            new[] { "Hologram Projector", "Invisibility Cloak" } },
            { "Chemistry",           new[] { "Utility Belt", "Nano Suit" } },
            { "Engineering",         new[] { "Nano Suit", "Cybernetic Implants" } }
        };

        private static readonly Dictionary<string, string[]> _powersForEquipment = new()
        {
            { "Energy Shield",          new[] { "Energy Blasts", "Telekinesis" } },
            { "Exoskeleton",            new[] { "Super Strength" } },
            { "Power Suit",             new[] { "Super Strength", "Energy Blasts" } },
            { "Hologram Projector",     new[] { "Telepathy", "Invisibility" } },
            { "Night Vision Goggles",   new[] { "Invisibility" } },
            { "Force Field Generator",  new[] { "Telekinesis", "Elemental Control" } },
            { "Cybernetic Implants",    new[] { "Telepathy", "Mind Control" } },
            { "Nano Suit",              new[] { "Shape Shifting" } },
            { "Teleportation Device",   new[] { "Dimensional Travel", "Time Manipulation" } },
            { "Plasma Sword",           new[] { "Invulnerability" } },
            { "Sonic Blaster",          new[] { "Invulnerability" } },
            { "Energy Gauntlets",       new[] { "Invulnerability" } },
            { "Anti-Gravity Boots",     new[] { "Flight" } },
            { "Magnetic Boots",         new[] { "Flight" } },
            { "Invisibility Cloak",     new[] { "Invisibility" } },
            { "Jetpack",                new[] { "Flight" } },
            { "Utility Belt",           new[] { "Tactical Planning" } },
            { "Healing Potion",         new[] { "Healing Factor" } },
            { "Laser Gun",              new[] { "Heat Vision" } },
            { "Grappling Hook",         new[] { "Super Agility" } }
        };

        private static readonly Dictionary<string, string[]> _skillsForEquipment = new()
        {
            { "Energy Shield",          new[] { "Marksmanship" } },
            { "Exoskeleton",            new[] { "Martial Arts" } },
            { "Power Suit",             new[] { "Swordsmanship", "Martial Arts" } },
            { "Hologram Projector",     new[] { "Tactical Planning" } },
            { "Night Vision Goggles",   new[] { "Stealth" } },
            { "Force Field Generator",  new[] { "Marksmanship" } },
            { "Cybernetic Implants",    new[] { "Hacking", "Interrogation" } },
            { "Nano Suit",              new[] { "Escape Artist", "Stealth" } },
            { "Teleportation Device",   new[] { "Escape Artist", "Piloting" } },
            { "Plasma Sword",           new[] { "Swordsmanship" } },
            { "Sonic Blaster",          new[] { "Marksmanship" } },
            { "Energy Gauntlets",       new[] { "Hand-to-Hand Combat" } },
            { "Anti-Gravity Boots",     new[] { "Acrobatics" } },
            { "Magnetic Boots",         new[] { "Acrobatics" } },
            { "Invisibility Cloak",     new[] { "Stealth" } },
            { "Jetpack",                new[] { "Piloting" } },
            { "Utility Belt",           new[] { "Survival Skills" } },
            { "Healing Potion",         new[] { "Survival Skills" } },
            { "Laser Gun",              new[] { "Marksmanship" } },
            { "Grappling Hook",         new[] { "Acrobatics" } }
        };

        public FightData(SuperHero superHero, SuperHero superHeroAdversary)
        {
            SuperHeroBuilderInputValidation.ValidateInput(superHero, nameof(superHero));
            SuperHeroBuilderInputValidation.ValidateInput(superHeroAdversary, nameof(superHeroAdversary));

            _superHero = superHero;
            _superHeroAdversary = superHeroAdversary;
            _fightLogger = new FightLogger();
            _fightLoggerMessage = new FightLoggerMessage(superHero, superHeroAdversary);
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
                            _fightLogger.Log(_fightLoggerMessage.GetAttackFailedMessage(superHeroPS, equipment), LogStatus.Failed);
                            attack--;
                            break;
                        }

                        chancesToCancel--;

                        if (chancesToCancel == 0)
                        {
                            _fightLogger.Log(_fightLoggerMessage.GetAttackSucessMessage(superHeroPS), LogStatus.Success);
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
                            _fightLogger.Log(_fightLoggerMessage.GetDefenseFailedMessage(superHeroEquipment, ps), LogStatus.Failed);
                            defense--;
                            break;
                        }

                        chancesToCancel--;

                        if (chancesToCancel == 0)
                        {
                            _fightLogger.Log(_fightLoggerMessage.GetDefenseSucessMessage(superHeroEquipment), LogStatus.Success);
                        }
                    }

                    chancesToCancel = superHeroAdversaryPSList.Length;
                }
            }
        }       
    }
}

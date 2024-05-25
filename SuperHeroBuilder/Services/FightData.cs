namespace SuperHeroBuilder.Services
{
    public class FightData
    {
        private static readonly Dictionary<string, string[]> _equipmentsForPowers = new()
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

        private static readonly Dictionary<string, string[]> _equipmentsForSkills = new()
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

        private static readonly Dictionary<string, string[]> _powersForEquipments = new()
        {
            { "Energy Shield",          new[] { "Energy Blasts", "Telekinesis", "Super Strength" } },
            { "Exoskeleton",            new[] { "Super Strength", "Telekinesis" } },
            { "Power Suit",             new[] { "Energy Blasts", "Super Strength" } },
            { "Hologram Projector",     new[] { "Telepathy", "Invisibility", "Shape Shifting" } },
            { "Night Vision Goggles",   new[] { "Invisibility", "Stealth" } },
            { "Force Field Generator",  new[] { "Telekinesis", "Energy Blasts", "Elemental Control" } },
            { "Cybernetic Implants",    new[] { "Telepathy", "Hacking" } },
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
            { "Healing Potion",         new[] { "Healing Factor", "Survival Skills" } }
        };

        private static readonly Dictionary<string, string[]> _skillsForEquipments = new()
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
            { "Healing Potion",         new[] { "Survival Skills", "Hand-to-Hand Combat" } }
        };

        public static void CancelPSByAdversaryEquipments(string[] superHeroPSList, string[] superHeroAdversaryEquipments, ref int totalPS)
        {
            var equipmentsForPowers = Array.Empty<string>();
            var equipmentsForSkills = Array.Empty<string>();

            foreach (var superHeroPS in superHeroPSList)
            {
                if (_equipmentsForPowers.TryGetValue(superHeroPS, out equipmentsForPowers) || _equipmentsForSkills.TryGetValue(superHeroPS, out equipmentsForSkills))
                {
                    equipmentsForPowers ??= Array.Empty<string>();
                    equipmentsForSkills ??= Array.Empty<string>();

                    foreach (var equipment in superHeroAdversaryEquipments)
                    {
                        if (equipmentsForPowers!.Contains(equipment) || equipmentsForSkills!.Contains(equipment))
                        {
                            totalPS--;
                            break;
                        }
                    }
                }
            }
        }

        public static void CancelEquipmentsByAdversaryPS(string[] superHeroEquipments, string[] superHeroAdversaryPSList, ref int totalEquipments)
        {
            var powersForEquipments = Array.Empty<string>();
            var skillsForEquipments = Array.Empty<string>();

            foreach (var superHeroEquipment in superHeroEquipments)
            {
                if (_powersForEquipments.TryGetValue(superHeroEquipment, out powersForEquipments) || _skillsForEquipments.TryGetValue(superHeroEquipment, out skillsForEquipments))
                {
                    powersForEquipments ??= Array.Empty<string>();
                    skillsForEquipments ??= Array.Empty<string>();

                    foreach (var ps in superHeroAdversaryPSList)
                    {
                        if (powersForEquipments!.Contains(ps) || skillsForEquipments!.Contains(ps))
                        {
                            totalEquipments--;
                            break;
                        }
                    }
                }
            }
        }
    }
}

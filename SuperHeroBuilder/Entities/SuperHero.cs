﻿namespace SuperHeroBuilder.Entities
{
    public class SuperHero
    {
        public string Name { get; set; } = string.Empty;

        public string SecretIdentity { get; set; } = string.Empty;

        public string[] Powers { get; set; } = Array.Empty<string>();

        public string[] Skills { get; set; } = Array.Empty<string>();

        public string[] Equipments { get; set; } = Array.Empty<string>();

        public int TotalAttack { get { return Powers.Length + Skills.Length; } }

        public int TotalDefense { get { return Equipments.Length; } }        

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Secret Identity: {SecretIdentity}\n" +
                   $"Powers: {string.Join(", ", Powers)}\n" +
                   $"Skills: {string.Join(", ", Skills)}\n" +
                   $"Equipments: {string.Join(", ", Equipments)}\n" +
                   $"Total Attack: {TotalAttack}\n" +
                   $"Total Defense: {TotalDefense}\n";
        }
    }
}

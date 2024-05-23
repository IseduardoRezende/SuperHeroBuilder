namespace SuperHeroBuilder.Entities
{
    public class SuperHero
    {
        public string Name { get; set; } = string.Empty;

        public string SecretIdentity { get; set; } = string.Empty;

        public string[] Powers { get; set; } = Array.Empty<string>();

        public string[] Skills { get; set; } = Array.Empty<string>();

        public string[] Equipments { get; set; } = Array.Empty<string>();

        public double Attack { get; set; }

        public double Defense { get; set; }        

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Secret Identity: {SecretIdentity}\n" +
                   $"Powers: {string.Join(", ", Powers)}\n" +
                   $"Skills: {string.Join(", ", Skills)}\n" +
                   $"Equipments: {string.Join(", ", Equipments)}\n" +
                   $"Attack: {Attack}\n" +
                   $"Defense: {Defense}\n";
        }
    }
}

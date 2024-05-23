global using MethodChainingSuperHeroBuilder = SuperHeroBuilder.Builders.SuperHeroBuilder;
using SuperHeroBuilder;
using SuperHeroBuilder.Enums;

Console.WriteLine($"Hello, World! {Environment.NewLine}");

Console.WriteLine("Fight Details:");

var fightDetails = new Fight(bet: Fighters.One).Combat();

Console.WriteLine(fightDetails);

Console.WriteLine("Creating Spider Man:");

var spiderMan = new MethodChainingSuperHeroBuilder()
                    .BuildName("Spider Man")
                    .BuildSecretIdentity("Peter Parker")
                    .BuildPowers("Improved Strength", "Spider Sense")
                    .BuildSkills("Agility", "Intelligence")
                    .BuildEquipments("Special Outfit", "Web Shooters")
                    .GetSuperHero();

Console.WriteLine(spiderMan);

Console.WriteLine("Creating Hulk:");

var hulk = new MethodChainingSuperHeroBuilder()
               .BuildName("Hulk")
               .BuildSecretIdentity("Bruce Banner")
               .BuildPowers("Super Strength")
               .BuildSkills("Intelligence")
               .GetSuperHero();

Console.WriteLine(hulk);
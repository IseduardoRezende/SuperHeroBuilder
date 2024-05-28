global using MethodChainingSuperHeroBuilder = SuperHeroBuilder.Builders.SuperHeroBuilder;
using SuperHeroBuilder.Enums;
using SuperHeroBuilder.Services.Fights;

Console.WriteLine($"Hello, World! {Environment.NewLine}");

var fightDetails = new Fight(bet: Fighter.One).Combat();

fightDetails.Inspect();

//Console.WriteLine("Creating Spider Man:");

//var spiderMan = new MethodChainingSuperHeroBuilder()
//                    .BuildName("Spider Man")
//                    .BuildSecretIdentity("Peter Parker")
//                    .BuildPowers("Improved Strength", "Spider Sense")
//                    .BuildSkills("Agility", "Intelligence")
//                    .BuildEquipments("Special Outfit", "Web Shooters")
//                    .GetSuperHero();

//Console.WriteLine(spiderMan);

//Console.WriteLine("Creating Hulk:");

//var hulk = new MethodChainingSuperHeroBuilder()
//               .BuildName("Hulk")
//               .BuildSecretIdentity("Bruce Banner")
//               .BuildPowers("Super Strength")
//               .BuildSkills("Intelligence")
//               .GetSuperHero();

//Console.WriteLine(hulk);

//Console.WriteLine("Fight Details:");

//fightDetails = new Fight(spiderMan, hulk, Fighters.Two).Combat();

//Console.WriteLine(fightDetails);
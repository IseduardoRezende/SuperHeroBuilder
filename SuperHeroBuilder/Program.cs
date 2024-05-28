global using MethodChainingSuperHeroBuilder = SuperHeroBuilder.Builders.SuperHeroBuilder;
using SuperHeroBuilder.Enums;
using SuperHeroBuilder.Services.Fights;

Console.WriteLine($"Hello, World! {Environment.NewLine}");

var fightDetails = new Fight(bet: Fighter.One).Combat();

fightDetails.Inspect();
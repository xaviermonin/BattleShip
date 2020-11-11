using BattleShip.PlayerBehavior.IA;
using BattleShip.Simulator;
using System;

namespace BattleShip.Host.Simulator
{
    class Program
    {
        /// <summary>
        /// Comportement du joueur 1.
        /// </summary>
        static readonly Type behaviorType1 = typeof(SmartBehavior);

        /// <summary>
        /// Comportement du joueur 2.
        /// </summary>
        static readonly Type behaviorType2 = typeof(RandomBehavior);

        static void Main()
        {
            Console.WriteLine("Battle ship - Simulator.");

            Console.WriteLine($"{behaviorType1.Name} VS {behaviorType2.Name}. Fight !");

            var battleShipSimulator = new BattleShipSimulator(behaviorType1, behaviorType2);

            var matchResult = battleShipSimulator.RunMultiplesMatches();

            Console.WriteLine($"Best IA: {matchResult.WinnerBehaviorType.Name}.");
            Console.WriteLine($"Victory rate of the best IA: {matchResult.WinnerWinRate:P2}");
            Console.WriteLine($"Winner victories: {matchResult.WinnerVictories}.");
            Console.WriteLine($"Looser victories: {matchResult.LooserVictories}.");
            Console.WriteLine($"Draws: {matchResult.Draws}.");
        }
    }
}

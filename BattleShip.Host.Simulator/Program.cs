﻿using BattleShip.PlayerBehavior.IA;
using BattleShip.Simulator;
using System;

namespace BattleShip.Host.Simulator
{
    class Program
    {
        /// <summary>
        /// Comportement du joueur 1.
        /// </summary>
        static readonly Type behaviorType1 = typeof(FullRandomBehavior);

        /// <summary>
        /// Comportement du joueur 2.
        /// </summary>
        static readonly Type behaviorType2 = typeof(PartialRandomBehavior);

        static void Main(string[] args)
        {
            Console.WriteLine("Simulateur de bataile navale.");

            Console.WriteLine($"{behaviorType1.Name} VS {behaviorType2.Name}. Fight !");

            var battleShipSimulator = new BattleShipSimulator(behaviorType1, behaviorType2);
            var matchResult = battleShipSimulator.RunMultiplesMatches();

            Console.WriteLine($"La meilleur IA est : {matchResult.WinnerBehaviorType.Name}.");
            Console.WriteLine($"Le taux de victoire est de {matchResult.WinnerWinRate}%");
            Console.WriteLine($"{matchResult.WinnerVictories} à {matchResult.LooserVictories}.");
        }
    }
}

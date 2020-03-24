using BattleShip.Engine;
using BattleShip.PlayerBehavior;
using BattleShip.PlayerBehavior.IA;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BattleShip.Simulator
{
    class Program
    {
        /// <summary>
        /// Nombre de combat de bataille navale à effectuer dans la simulation.
        /// </summary>
        const int NbIterations = 10_000;

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

            int player1WinCounter = 0, player2WinCounter = 0;
            Parallel.For(0, NbIterations, i =>
            {
                if (Fight(behaviorType1, behaviorType2) == GameWinner.Player1)
                    Interlocked.Increment(ref player1WinCounter);
                else
                    Interlocked.Increment(ref player2WinCounter);
            });

            Type winner = player1WinCounter > player2WinCounter ? behaviorType1 : behaviorType2;

            Console.WriteLine($"La meilleur IA est : {winner.Name}. {Math.Max(player1WinCounter, player2WinCounter)} à {Math.Min(player1WinCounter, player2WinCounter)} !");
        }
        
        /// <summary>
        /// Fait combattre 2 IA.
        /// </summary>
        /// <param name="behaviorType1">Type de l'IA 1</param>
        /// <param name="behaviorType2">Type de l'IA 2</param>
        /// <returns></returns>
        static GameWinner Fight(Type behaviorType1, Type behaviorType2)
        {
            var behavior1 = Activator.CreateInstance(behaviorType1) as IPlayerBehavior;
            var behavior2 = Activator.CreateInstance(behaviorType2) as IPlayerBehavior;

            Game game = new Game();
            game.InitializePlayers(behavior1, behavior2);

            while (game.State != GameState.End)
                game.Update();

            return game.Winner;
        }
    }
}

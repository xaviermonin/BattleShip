using BattleShip.Engine;
using BattleShip.PlayerBehavior;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BattleShip.Simulator
{
    /// <summary>
    /// Simulateur de bataille navale.
    /// Fait combattre 2 IA et indique le vainqueur.
    /// </summary>
    public class BattleShipSimulator
    {
        /// <summary>
        /// Comportement de l'IA 1 et 2.
        /// </summary>
        readonly Type _behaviorType1, _behaviorType2;

        /// <summary>
        /// Nombre de combat de bataille navale à effectuer dans la simulation.
        /// </summary>
        const int _nbIterations = 10_000;

        /// <summary>
        /// Construit un simulateur de combat de bataille navale.
        /// </summary>
        /// <param name="behaviorType1">Comportement (IA) du joueur 1.</param>
        /// <param name="behaviorType2">Comportement (IA) du joueur 2.</param>
        public BattleShipSimulator(Type behaviorType1, Type behaviorType2)
        {
            if (behaviorType1 == null || !typeof(IPlayerBehavior).IsAssignableFrom(behaviorType1))
                throw new ArgumentException($"Le comportement doit être hérité de {nameof(IPlayerBehavior)}", nameof(behaviorType1));

            if (behaviorType2 == null || !typeof(IPlayerBehavior).IsAssignableFrom(behaviorType2))
                throw new ArgumentException($"Le comportement doit être hérité de {nameof(IPlayerBehavior)}", nameof(behaviorType2));

            _behaviorType1 = behaviorType1;
            _behaviorType2 = behaviorType2;
        }

        /// <summary>
        /// Effectue de multiples matches (10 000) et indique le gagnant.
        /// </summary>
        public MatchesResult RunMultiplesMatches()
        {
            int player1Victories = 0, player2Victories = 0;

            Parallel.For(0, _nbIterations, i =>
            {
                if (RunOneMatch() == GameWinner.Player1)
                    Interlocked.Increment(ref player1Victories);
                else
                    Interlocked.Increment(ref player2Victories);
            });

            return new MatchesResult(player1Victories, player2Victories, _behaviorType1, _behaviorType2);
        }

        /// <summary>
        /// Effectue un match entre les 2 joueurs et indique le gagnant.
        /// </summary>
        /// <returns>Gagnant</returns>
        public GameWinner RunOneMatch()
        {
            var behavior1 = Activator.CreateInstance(_behaviorType1) as IPlayerBehavior;
            var behavior2 = Activator.CreateInstance(_behaviorType2) as IPlayerBehavior;

            Game game = new Game();
            game.InitializePlayers(behavior1, behavior2);

            while (game.State != GameState.End)
                game.Update();

            return game.Winner;
        }
    }
}

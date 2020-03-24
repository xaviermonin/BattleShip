using BattleShip.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Simulator
{
    /// <summary>
    /// Résultat des matches de bataille navale.
    /// </summary>
    public class MatchesResult
    {
        /// <summary>
        /// Comportements.
        /// </summary>
        Type _behavior1, _behavior2;

        /// <summary>
        /// Gagnant des matches.
        /// </summary>
        public GameWinner GameWinner => Player1Victories > Player2Victories ? GameWinner.Player1 : GameWinner.Player2;

        /// <summary>
        /// Comportement (IA) gagnante.
        /// </summary>
        public Type WinnerBehaviorType => Player1Victories > Player2Victories ? _behavior1 : _behavior2;

        /// <summary>
        /// Comportement (IA) gagnante.
        /// </summary>
        public Type LooserBehaviorType => Player1Victories > Player2Victories ? _behavior2 : _behavior1;

        /// <summary>
        /// Nombre de victoires du gagnant.
        /// </summary>
        public int WinnerVictories => Math.Max(Player1Victories, Player2Victories);

        /// <summary>
        /// Nombre de victoires du perdant.
        /// </summary>
        public int LooserVictories => Math.Min(Player1Victories, Player2Victories);

        /// <summary>
        /// Nombre de victoire du joueur 1.
        /// </summary>
        public int Player1Victories { get; }

        /// <summary>
        /// Nombre de victoire du joueur 2.
        /// </summary>
        public int Player2Victories { get; }

        /// <summary>
        /// Taux de victoire du joueur 1.
        /// Exprimé de 0 à 100.
        /// </summary>
        public double Player1WinRate => Player1Victories / (double)TotalMatches * 100d;

        /// <summary>
        /// Taux de victoire du joueur 2.
        /// Exprimé de 0 à 100.
        /// </summary>
        public double Player2WinRate => Player2Victories / (double)TotalMatches * 100d;

        /// <summary>
        /// Taux de victorie du gagnant.
        /// </summary>
        public double WinnerWinRate => Math.Max(Player1WinRate, Player2WinRate);

        /// <summary>
        /// Taux de victoire du perdant.
        /// </summary>
        public double LooserWinRate => Math.Min(Player1WinRate, Player2WinRate);

        /// <summary>
        /// Nombre total de matches joués par les joueurs.
        /// </summary>
        public int TotalMatches => Player1Victories + Player2Victories;

        /// <summary>
        /// Constructeur d'un résultat de matches.
        /// </summary>
        /// <param name="player1Victories">Nombre de victoires du joueur 1.</param>
        /// <param name="player2Victories">Nombre de victoires du joueur 2.</param>
        /// <param name="behavior1">Comportement du joueur 1.</param>
        /// <param name="behavior2">Comportement du joueur 2.</param>
        internal MatchesResult(int player1Victories, int player2Victories, Type behavior1, Type behavior2)
        {
            if (player1Victories + player2Victories < 1)
                throw new ArgumentException("Le nombre total de matches joués doit être supérieur à 0");

            Player1Victories = player1Victories;
            Player2Victories = player2Victories;

            _behavior1 = behavior1;
            _behavior2 = behavior2;
        }
    }
}

using BattleShip.PlayerBehavior.Ships;
using System.Collections.Generic;

namespace BattleShip.PlayerBehavior
{
    /// <summary>
    /// Joueur de la bataille navale.
    /// Permet de placer les navires sur son plateau et de tirer à des coordonnées du plateau ennemie.
    /// </summary>
    public interface IPlayerBehavior
    {
        /// <summary>
        /// Positionnement des navires.
        /// </summary>
        /// <param name="board"></param>
        IEnumerable<ShipPosition> ShipPositions { get; }

        /// <summary>
        /// Donne l'autorisation de tirer sur le plateau ennemi.
        /// </summary>
        /// <param name="fireAuthorization">Autorisation de tirer</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1030:Utiliser des événements quand cela est approprié", Justification = "Fire ne veut pas dire lancer évènement mais tirer une salve")]
        void Fire(IFireAuthorization fireAuthorization);
    }
}

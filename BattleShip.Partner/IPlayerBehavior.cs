using BattleShip.PlayerBehavior.Ships;
using System.Collections.Generic;

namespace BattleShip.PlayerBehavior
{
    /// <summary>
    /// Comportement d'un joueur de la bataille navale.
    /// Permet de placer les navires sur son plateau et de tirer à des coordonnées du plateau ennemi.
    /// </summary>
    public interface IPlayerBehavior
    {
        /// <summary>
        /// Positionnement des navires.
        /// Les classes de navires doivent être positionnées.
        /// Le plateau de jeu est de 10x10, commence à 0x0 et se termine à 9x9.
        /// </summary>
        /// <param name="board"></param>
        IEnumerable<ShipPosition> ShipPositions { get; }

        /// <summary>
        /// Donne l'autorisation de tirer sur le plateau ennemi.
        /// </summary>
        /// <param name="fireAuthorization">Autorisation de tirer. Permet de tirer sur le plateau adverse</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1030:Utiliser des événements quand cela est approprié",
                                                         Justification = "Fire ne veut pas dire lancer évènement mais tirer une salve")]
        void Fire(IFireAuthorization fireAuthorization);
    }
}

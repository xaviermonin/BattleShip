using BattleShip.PlayerBehavior.Ships;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace BattleShip.PlayerBehavior.IA
{
    /// <summary>
    /// IA pacisfist. Ne tire jamais et ne peut donc jamais gagner.
    /// Permet de tester une IA.
    /// Positionne de façon fixe les navires.
    /// </summary>
    public sealed class PacifistBehavior : IPlayerBehavior
    {
        /// <summary>
        /// Donne des positions fixes aux navires sur le plateau.
        /// </summary>
        public IEnumerable<ShipPosition> ShipPositions => new List<ShipPosition>()
        {
            new ShipPosition(ClassOfShip.Submarine,     new Point(0, 0), Orientation.Horizontal),
            new ShipPosition(ClassOfShip.BattleShip,    new Point(0, 1), Orientation.Horizontal),
            new ShipPosition(ClassOfShip.Carrier,       new Point(0, 2), Orientation.Horizontal),
            new ShipPosition(ClassOfShip.Cruiser,       new Point(0, 3), Orientation.Horizontal),
            new ShipPosition(ClassOfShip.Destroyer,     new Point(0, 4), Orientation.Horizontal),
        };

        /// <summary>
        /// Tir au hasard sur le plateau adverse.
        /// </summary>
        /// <param name="fireAuthorization">Autorisation de tir. Permet de tirer sur le plateau ennemi.</param>
        public void Fire(IFireAuthorization fireAuthorization)
        {
            // Ne tire pas.
        }
    }
}

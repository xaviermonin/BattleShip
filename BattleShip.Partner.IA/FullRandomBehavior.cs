using BattleShip.PlayerBehavior.Ships;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace BattleShip.PlayerBehavior.IA
{
    /// <summary>
    /// IA qui pense avoir la chance de son coté.
    /// Tir n'importe où et parfois au même endroit.
    /// Positionne de façon fixe les navires.
    /// </summary>
    public sealed class FullRandomBehavior : IPlayerBehavior
    {
        private readonly Random random = new Random();

        /// <summary>
        /// Donne des positions fixe aux navires sur le plateau.
        /// </summary>
        public IEnumerable<ShipPosition> ShipPositions => new List<ShipPosition>()
        {
            new ShipPosition(ClassOfShip.BattleShip1, new Point(0, 0), Orientation.Horizontal),
            new ShipPosition(ClassOfShip.BattleShip2, new Point(0, 1), Orientation.Horizontal),
            new ShipPosition(ClassOfShip.Carrier,     new Point(0, 2), Orientation.Horizontal),
            new ShipPosition(ClassOfShip.Cruiser,     new Point(0, 3), Orientation.Horizontal),
            new ShipPosition(ClassOfShip.Destroyer,   new Point(0, 4), Orientation.Horizontal),
        };

        /// <summary>
        /// Tir au hasard sur le plateau adverse.
        /// </summary>
        /// <param name="fireAuthorization">Autorisation de tir. Permet de tirer sur le plateau ennemi.</param>
        public void Fire(IFireAuthorization fireAuthorization)
        {
            fireAuthorization.Fire(new Point(random.Next(0, 10), random.Next(0, 10)));
        }
    }
}

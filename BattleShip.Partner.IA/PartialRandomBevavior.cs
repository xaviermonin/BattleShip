using BattleShip.PlayerBehavior.Ships;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BattleShip.PlayerBehavior.IA
{
    /// <summary>
    /// IA qui tir au hasard mais pas jamais au même endroit.
    /// Positionne de façon fixe les navires et tir au hasard.
    /// </summary>
    public sealed class PartialRandomBehavior : IPlayerBehavior
    {
        private readonly Random random = new Random();
        private readonly List<Point> previousShotsCoordonates = new List<Point>();

        /// <summary>
        /// Donne des positions fixe aux navires sur le plateau.
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
        /// <param name="fireAuthorization"></param>
        public void Fire(IFireAuthorization fireAuthorization)
        {
            Point coordonate = new Point();

            do
            {
                coordonate.X = random.Next(0, 10);
                coordonate.Y = random.Next(0, 10);
            } while (previousShotsCoordonates.Contains(coordonate));

            fireAuthorization.Fire(coordonate);

            previousShotsCoordonates.Add(coordonate);
        }
    }
}

using BattleShip.PlayerBehavior.Ships;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BattleShip.PlayerBehavior.IA
{
    /// <summary>
    /// IA qui pense avoir la chance de son coté.
    /// Tir au hasard.
    /// Positionne de façon fixe les navires.
    /// </summary>
    public sealed class RandomBehavior : IPlayerBehavior
    {
        private readonly Random random = new Random();
        private readonly List<Point> previousShotsCoordonates = new List<Point>();

        /// <summary>
        /// Donne des positions fixes aux navires sur le plateau.
        /// </summary>
        public IEnumerable<ShipPosition> ShipPositions => new List<ShipPosition>()
        {
            new ShipPosition(ClassOfShip.Destroyer,     new System.Drawing.Point(1,1), Orientation.Vertical),
            new ShipPosition(ClassOfShip.Cruiser,       new System.Drawing.Point(4,1), Orientation.Horizontal),
            new ShipPosition(ClassOfShip.Submarine,     new System.Drawing.Point(1,7), Orientation.Vertical),
            new ShipPosition(ClassOfShip.BattleShip,    new System.Drawing.Point(3,4), Orientation.Vertical),
            new ShipPosition(ClassOfShip.Carrier,       new System.Drawing.Point(5,6), Orientation.Horizontal),
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

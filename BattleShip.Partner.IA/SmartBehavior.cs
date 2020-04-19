using BattleShip.PlayerBehavior.Ships;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BattleShip.PlayerBehavior.IA
{
    /// <summary>
    /// IA intelligente.
    /// </summary>
    public sealed class SmartBehavior : IPlayerBehavior
    {

        private readonly Random random = new Random();

        private readonly List<Point> previousShots = new List<Point>();

        private readonly List<ShipToHunt> shipsToHunt = new List<ShipToHunt>();

        public SmartBehavior()
        {
        }

        /// <summary>
        /// Donne des positions fixes aux navires sur le plateau.
        /// </summary>
        public IEnumerable<ShipPosition> ShipPositions => new ShipPosition[]
        {
            new ShipPosition(ClassOfShip.Destroyer,     new System.Drawing.Point(1,1), Orientation.Vertical),
            new ShipPosition(ClassOfShip.Cruiser,       new System.Drawing.Point(4,1), Orientation.Horizontal),
            new ShipPosition(ClassOfShip.Submarine,     new System.Drawing.Point(1,7), Orientation.Vertical),
            new ShipPosition(ClassOfShip.BattleShip,    new System.Drawing.Point(3,4), Orientation.Vertical),
            new ShipPosition(ClassOfShip.Carrier,       new System.Drawing.Point(5,6), Orientation.Horizontal),
        };

        /// <summary>
        /// Tire sur le plateau adverse.
        /// </summary>
        /// <param name="fireAuthorization"></param>
        public void Fire(IFireAuthorization fireAuthorization)
        {
            if (shipsToHunt.Count > 0)
                Hunt(fireAuthorization);
            else
                Discover(fireAuthorization);
        }

        private void Hunt(IFireAuthorization fireAuthorization)
        {
            var shipToHunt = shipsToHunt.First();
            foreach (var coordonate in shipToHunt.Coordonates)
            {
                Point? nextCoordonate = FindNextFire(coordonate);
                if (nextCoordonate != null)
                {
                    FireAndStore(nextCoordonate.Value, fireAuthorization);
                    break;
                }
            }
        }

        private Point? FindNextFire(Point coordonate)
        {
            var top = new Point(coordonate.X, coordonate.Y - 1);
            if (IsValidCoordonate(top))
                return top;

            var bot = new Point(coordonate.X, coordonate.Y + 1);
            if (IsValidCoordonate(bot))
                return bot;

            var left = new Point(coordonate.X - 1, coordonate.Y);
            if (IsValidCoordonate(left))
                return left;

            var right = new Point(coordonate.X + 1, coordonate.Y);
            if (IsValidCoordonate(right))
                return right;

            return null;
        }

        bool IsValidCoordonate(Point coordonate)
        {
            if (coordonate.X < 0 || coordonate.Y < 0 || coordonate.X > 9 || coordonate.Y > 9)
                return false;

            return !previousShots.Contains(coordonate);
        }

        private void Discover(IFireAuthorization fireAuthorization)
        {
            Point coordonate = new Point();

            do
            {
                coordonate.Y = random.Next(0, 10);
                coordonate.X = random.Next(0, 5) * 2;

                if (coordonate.Y % 2 == 0)
                    coordonate.X += 1;

            } while (previousShots.Contains(coordonate));

            FireAndStore(coordonate, fireAuthorization);
        }

        private void FireAndStore(Point coordonate, IFireAuthorization fireAuthorization)
        {
            var fireResult = fireAuthorization.Fire(coordonate);

            previousShots.Add(coordonate);

            if (fireResult.State == FireState.Hit)
            {
                var target = shipsToHunt.FirstOrDefault(c => c.ClassOfShip == fireResult.Ship);

                if (target == null)
                {
                    target = new ShipToHunt()
                    {
                        ClassOfShip = fireResult.Ship.Value
                    };

                    shipsToHunt.Add(target);
                }

                target.Coordonates.Add(coordonate);
            }

            if (fireResult.State == FireState.Sunk)
            {
                var shipToHunt = shipsToHunt.FirstOrDefault(c => c.ClassOfShip == fireResult.Ship);
                shipsToHunt.Remove(shipToHunt);
            }
        }

        class ShipToHunt
        {
            public ClassOfShip ClassOfShip { get; set; }
            public List<Point> Coordonates { get; private set; }

            public ShipToHunt()
            {
                Coordonates = new List<Point>();
            }
        }
    }
}

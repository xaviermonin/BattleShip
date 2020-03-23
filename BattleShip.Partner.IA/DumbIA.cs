using BattleShip.PlayerBehavior.Ships;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace BattleShip.PlayerBehavior.IA
{
    /// <summary>
    /// Mauvaise IA.
    /// Positionne de façon fixe les navires et tir au hasard.
    /// </summary>
    public class DumbIA : IPlayerBehavior
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
        /// <param name="fireAuthorization"></param>
        public void Fire(IFireAuthorization fireAuthorization)
        {
            var result = fireAuthorization.Fire(new Point(random.Next(0, 10), random.Next(0, 10)));

            /*switch (result.State)
            {
                case FireState.Hit: 
                    break;
                case FireState.Miss:
                    break;
                case FireState.Sunk:
                    var shipSunk = result.Ship.Value;
                    break;
            }*/
        }
    }
}

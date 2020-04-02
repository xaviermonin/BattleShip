using BattleShip.Engine;
using BattleShip.PlayerBehavior.Ships;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BattleShip.PlayerBehavior.IA
{
    /// <summary>
    /// IA intelligente.
    /// </summary>
    public sealed class SmartBehavior : IPlayerBehavior
    {
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

        private Board EnemyBoard => new Board();

        /// <summary>
        /// Tire sur le plateau adverse.
        /// </summary>
        /// <param name="fireAuthorization"></param>
        public void Fire(IFireAuthorization fireAuthorization)
        {
            
        }
    }
}

using BattleShip.PlayerBehavior.Ships;
using System;
using System.Collections.Generic;

namespace BattleShip.PlayerBehavior.IA
{
    /// <summary>
    /// IA intelligente.
    /// </summary>
    public sealed class SmartBehavior : IPlayerBehavior
    {
        enum Mode { Discovery, Hunt }

        Mode CurrentMode { get; set; }

        public SmartBehavior()
        {
            CurrentMode = Mode.Discovery;
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
            if (CurrentMode == Mode.Discovery)
                Discover(fireAuthorization);
            else
                Hunt(fireAuthorization);
        }

        private void Hunt(IFireAuthorization fireAuthorization)
        {
            throw new NotImplementedException();
        }

        private void Discover(IFireAuthorization fireAuthorization)
        {
            throw new NotImplementedException();
        }
    }
}

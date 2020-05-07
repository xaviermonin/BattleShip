using BattleShip.PlayerBehavior.Ships;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShip.PlayerBehavior.IA
{
    /// <summary>
    /// Demande à un humain de saisir les coordonnées de tir.
    /// </summary>
    public sealed class HumanConsoleBehavior : IPlayerBehavior
    {
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
            Task.Run(() =>
            {
                Console.Write("Coordonnées de tir [x:y]: ");
                var coordonates = Console.ReadLine().Split(':');

                if (coordonates.Length != 2)
                    throw new InvalidDataException("Coordonnées invalides");

                int x = int.Parse(coordonates[0]);
                int y = int.Parse(coordonates[1]);

                fireAuthorization.Fire(new Point(x, y));
            });
        }
    }
}

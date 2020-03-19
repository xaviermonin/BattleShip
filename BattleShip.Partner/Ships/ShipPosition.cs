using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BattleShip.PlayerBehavior.Ships
{
    /// <summary>
    /// Position complète du navire sur le plateau.
    /// </summary>
    public struct ShipPosition : IEquatable<ShipPosition>
    {
        /// <summary>
        /// Classe du navire.
        /// </summary>
        public ClassOfShip ClassOfShip { get; set; }

        /// <summary>
        /// Position (haut / gauche) du navire sur le plateau.
        /// </summary>
        public Point Coordonate { get; set; }

        /// <summary>
        /// Orientation du navire.
        /// </summary>
        public Orientation Orientation { get; set; }

        public ShipPosition(ClassOfShip classOfShip, Point coordonate, Orientation orientation)
        {
            ClassOfShip = classOfShip;
            Coordonate = coordonate;
            Orientation = orientation;
        }

        public override bool Equals(object obj)
        {
            if (obj is ShipPosition)
                return Equals((ShipPosition)obj);

            return false;
        }

        public override int GetHashCode()
        {
            return ClassOfShip.GetHashCode() ^ Coordonate.GetHashCode() ^ Orientation.GetHashCode();
        }

        public static bool operator ==(ShipPosition left, ShipPosition right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ShipPosition left, ShipPosition right)
        {
            return !(left == right);
        }

        public bool Equals(ShipPosition other)
        {
            return this.ClassOfShip == other.ClassOfShip &&
                   this.Coordonate == other.Coordonate &&
                   this.Orientation == other.Orientation;
        }
    }
}

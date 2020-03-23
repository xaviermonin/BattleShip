using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BattleShip.PlayerBehavior.Ships
{
    /// <summary>
    /// Position complète du navire sur le plateau.
    /// </summary>
    public class ShipPosition : IEquatable<ShipPosition>
    {
        /// <summary>
        /// Classe du navire.
        /// </summary>
        public ClassOfShip Class { get; }

        /// <summary>
        /// Position (haut / gauche) du navire sur le plateau.
        /// </summary>
        public Point Coordonate { get; }

        /// <summary>
        /// Orientation du navire.
        /// </summary>
        public Orientation Orientation { get; }

        public ClassOfShipInfo ClassOfShipInfo { get; }

        public Size Size
        {
            get
            {
                if (Orientation == Orientation.Horizontal)
                    return new Size(ClassOfShipInfo.Lenght, 0);
                else
                    return new Size(0, ClassOfShipInfo.Lenght);
            }
        }

        public ShipPosition(ClassOfShip classOfShip, Point coordonate, Orientation orientation)
        {
            Class = classOfShip;
            Coordonate = coordonate;
            Orientation = orientation;
            ClassOfShipInfo = ClassOfShipInfo.FromClassOfShip(classOfShip);
        }

        public override bool Equals(object obj)
        {
            if (obj is ShipPosition)
                return Equals((ShipPosition)obj);

            return false;
        }

        public override int GetHashCode()
        {
            return Class.GetHashCode() ^ Coordonate.GetHashCode() ^ Orientation.GetHashCode();
        }

        public static bool operator ==(ShipPosition left, ShipPosition right)
        {
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(ShipPosition left, ShipPosition right)
        {
            return !(left == right);
        }

        public bool Equals(ShipPosition other)
        {
            if (other == null)
                return false;

            return Class == other.Class &&
                   Coordonate == other.Coordonate &&
                   Orientation == other.Orientation;
        }
    }
}

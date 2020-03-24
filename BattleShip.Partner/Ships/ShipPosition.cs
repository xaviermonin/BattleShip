using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BattleShip.PlayerBehavior.Ships
{
    /// <summary>
    /// Position complète du navire sur le plateau 10x10.
    /// Le positionnement sur le plateau commence à 0x0 et se termine à 9x9.
    /// </summary>
    public class ShipPosition : IEquatable<ShipPosition>
    {
        /// <summary>
        /// Classe du navire.
        /// </summary>
        public ClassOfShip Class { get; }

        /// <summary>
        /// Position (haut / gauche) du navire sur le plateau (10x10).
        /// Le plateau commence à 0x0 et se termine à 9x9.
        /// </summary>
        public Point Coordonate { get; }

        /// <summary>
        /// Orientation du navire: Vertical ou horizontal.
        /// </summary>
        public Orientation Orientation { get; }

        /// <summary>
        /// Information sur la classe du navire.
        /// </summary>
        public ClassOfShipInfo ClassOfShipInfo { get; }

        /// <summary>
        /// Taille du navire.
        /// </summary>
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

        /// <summary>
        /// Construit la position complète d'un navire.
        /// </summary>
        /// <param name="classOfShip">Classe du navire.</param>
        /// <param name="coordonate">Coordonnées X et Y du navire sur le plateau 10x10. Le plateau commence à 0x0 et se termine à 9x9.</param>
        /// <param name="orientation">Orientation du navire (Verical ou Horizontal).</param>
        public ShipPosition(ClassOfShip classOfShip, Point coordonate, Orientation orientation)
        {
            Class = classOfShip;
            Coordonate = coordonate;
            Orientation = orientation;
            ClassOfShipInfo = ClassOfShipInfo.FromClassOfShip(classOfShip);
        }

        /// <summary>
        /// Comparateur d'égalité.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is ShipPosition)
                return Equals((ShipPosition)obj);

            return false;
        }

        /// <summary>
        /// Obtient le hashcode.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Class.GetHashCode() ^ Coordonate.GetHashCode() ^ Orientation.GetHashCode();
        }

        /// <summary>
        /// Opérateur d'égalité.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ShipPosition left, ShipPosition right)
        {
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return left.Equals(right);
        }

        /// <summary>
        /// Opérateur d'inégalité.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ShipPosition left, ShipPosition right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Compare une instance de <see cref="ShipPosition"/> avec une autre.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ShipPosition other)
        {
            if (ReferenceEquals(other,null))
                return false;

            return Class == other.Class &&
                   Coordonate == other.Coordonate &&
                   Orientation == other.Orientation;
        }
    }
}

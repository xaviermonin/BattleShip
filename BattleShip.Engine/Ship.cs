using BattleShip.PlayerBehavior.Ships;
using System;
using System.Drawing;

namespace BattleShip.Engine
{
    /// <summary>
    /// Navire.
    /// </summary>
    public class Ship
    {
        /// <summary>
        /// Position bas / droite.
        /// </summary>
        public Point TopLeft { get; }
        
        /// <summary>
        /// Position haut / gauche.
        /// </summary>
        public Point BottomRight { get; }

        /// <summary>
        /// Points de vie restant.
        /// </summary>
        public int HealthPoint { get; private set; }

        /// <summary>
        /// Longueur.
        /// </summary>
        public int Lenght { get; }

        /// <summary>
        /// Orientation du navire.
        /// </summary>
        public Orientation Orientation { get; }

        /// <summary>
        /// Etat du navire: Intact, touché ou coulé.
        /// </summary>
        public ShipState State
        {
            get
            {
                if (HealthPoint == Lenght)
                    return ShipState.Intact;
                else if (HealthPoint <= 0)
                    return ShipState.Sunk;
                else
                    return ShipState.Hit;
            }
        }

        /// <summary>
        /// Information sur la classe du navire.
        /// </summary>
        public ClassOfShipInfo ClassOfShipInfo { get; }

        /// <summary>
        /// Classe du navire.
        /// </summary>
        public ClassOfShip Class { get; }

        /// <summary>
        /// Constructeur d'un navire.
        /// </summary>
        /// <param name="shipPosition">Position et type du navire.</param>
        public Ship(ShipPosition shipPosition)
        {
            Orientation = shipPosition.Orientation;
            ClassOfShipInfo = shipPosition.ClassOfShipInfo; //TODO: Revoir la pertinence de cette classe et de son usage.
            Lenght = shipPosition.ClassOfShipInfo.Lenght;
            TopLeft = shipPosition.Coordonate;
            BottomRight = shipPosition.Coordonate + shipPosition.Size - new Size(1, 1); // -1 en X et Y car on TopLeft "consomme" une case
            Class = shipPosition.Class;
            HealthPoint = Lenght;
        }

        /// <summary>
        /// Touche le navire et modifie son état.
        /// </summary>
        internal void Hit()
        {
            --HealthPoint;
        }

        public override string ToString()
        {
            return $"{Class}";
        }
    }
}
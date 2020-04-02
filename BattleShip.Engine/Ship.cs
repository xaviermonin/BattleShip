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
        /// Position de la proue.
        /// Position bas / droite.
        /// </summary>
        public Point TopLeft { get; }
        
        /// <summary>
        /// Position de la poupe.
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
        /// Classe du navire.
        /// </summary>
        public ClassOfShip? Class { get; }

        /// <summary>
        /// Constructeur d'un navire.
        /// </summary>
        /// <param name="shipPosition">Position et type du navire.</param>
        public Ship(ShipPosition shipPosition)
        {
            Orientation = shipPosition.Orientation;
            Lenght = shipPosition.ClassOfShipInfo.Lenght;
            BottomRight = shipPosition.Coordonate;
            TopLeft = shipPosition.Coordonate + shipPosition.Size;
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
    }
}
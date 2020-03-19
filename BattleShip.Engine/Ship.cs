using BattleShip.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BattleShip.PlayerBehavior
{
    /// <summary>
    /// Navire
    /// </summary>
    public class Ship
    {
        /// <summary>
        /// Position de la proue
        /// </summary>
        public Point BowPosition { get; set; }
        
        /// <summary>
        /// Position de la poupe
        /// </summary>
        public Point SternPosition { get; set; }

        /// <summary>
        /// Points de vie
        /// </summary>
        public int HealthPoint { get; set; }

        /// <summary>
        /// Longueur
        /// </summary>
        public int Lenght { get; set; }

        /// <summary>
        /// Orientation
        /// </summary>
        public Orientation Orientation { get; set; }

        public ShipState State { get; set; }
    }

    public enum Orientation
    {
        Horizontal,
        Vertical
    }

    public enum ShipState
    {
        /// <summary>
        /// Intact
        /// </summary>
        Intact,
        /// <summary>
        /// Touché
        /// </summary>
        Hit,
        /// <summary>
        /// Coulé
        /// </summary>
        Sunk
    }
}
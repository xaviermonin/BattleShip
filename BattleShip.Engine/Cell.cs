using BattleShip.PlayerBehavior;

namespace BattleShip.Engine
{
    /// <summary>
    /// Case d'un plateau.
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Navire ayant un point sur cette case.
        /// </summary>
        public Ship Ship { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Hit { get; set; }

        /// <summary>
        /// Indique si la case est vide (sans navire).
        /// </summary>
        public bool IsEmpty => Ship == null;

        public Cell() => Hit = false;
    }
}

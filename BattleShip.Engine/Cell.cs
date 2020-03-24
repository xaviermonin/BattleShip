using BattleShip.PlayerBehavior;

namespace BattleShip.Engine
{
    /// <summary>
    /// Case d'un plateau.
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Coordonnée X de la cellule.
        /// </summary>
        public uint X { get; }

        /// <summary>
        /// Coordonnée Y de la cellule.
        /// </summary>
        public uint Y { get; }

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

        /// <summary>
        /// Construit une cellule.
        /// </summary>
        /// <param name="x">Coordonnée X</param>
        /// <param name="y">Coordonnée Y</param>
        public Cell(uint x, uint y)
        {
            X = x;
            Y = y;
            Hit = false;
        }

        /// <summary>
        /// Affiche les coordonnés de la cellule.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Ship == null)
                return $"{X}x{Y}";
            else
                return $"{X}x{Y}: {Ship}";
        }
    }
}

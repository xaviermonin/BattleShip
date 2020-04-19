using BattleShip.Engine.Exception;
using BattleShip.PlayerBehavior;
using System;

namespace BattleShip.Engine
{
    /// <summary>
    /// Case d'un plateau.
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Coordonnée X de la case.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Coordonnée Y de la case.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Navire ayant un point sur cette case.
        /// </summary>
        public Ship Ship { get; internal set; }

        /// <summary>
        /// Indique si cette case a subit un tir.
        /// </summary>
        public bool Hit { get; internal set; }

        /// <summary>
        /// Indique si la case est vide (sans navire).
        /// </summary>
        public bool IsEmpty => Ship == null;

        /// <summary>
        /// Construit une case.
        /// </summary>
        /// <param name="x">Coordonnée X</param>
        /// <param name="y">Coordonnée Y</param>
        internal Cell(int x, int y)
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
            return $"{X}x{Y}. Hit: {Hit}. Ship: {Ship}";
        }

        /// <summary>
        /// Tire sur une case
        /// </summary>
        /// <returns></returns>
        internal FireResult Fire()
        {
            if (Hit)
                throw new InvalidFireException("Cette case a déjà été touchée.");

            Hit = true;

            if (IsEmpty)
                return new FireResult() { State = FireState.Miss };
            else
            {
                Ship.Hit();

                if (Ship.State == ShipState.Sunk)
                    return new FireResult() { Ship = Ship.Class, State = FireState.Sunk };
                else
                    return new FireResult() { Ship = Ship.Class, State = FireState.Hit };
            }
        }
    }
}

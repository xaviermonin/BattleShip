using BattleShip.Engine.Exception;
using BattleShip.PlayerBehavior;
using BattleShip.PlayerBehavior.Ships;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BattleShip.Engine
{
    /// <summary>
    /// Plateau de la bataile navale.
    /// Permet de placer des navires et de tirer sur une cellule du plateau.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Liste des navires placés sur le plateau.
        /// </summary>
        private readonly List<Ship> ships = new List<Ship>();

        /// <summary>
        /// Taille du coté du plateau.
        /// </summary>
        private const int BoardSide = 10;

        /// <summary>
        /// Navires placés.
        /// </summary>
        public IEnumerable<Ship> Ships { get => ships; }

        /// <summary>
        /// Cases du plateau.
        /// </summary>
        private Cell[,] Cells { get; set; }

        /// <summary>
        /// Indique si tous les navires sont coulés.
        /// </summary>
        public bool IsAllShipsSunk => Ships.All(s => s.State == ShipState.Sunk);

        /// <summary>
        /// Construit un plateau de jeu de la bataille navale.
        /// </summary>
        public Board()
        {
            Cells = new Cell[BoardSide, BoardSide];

            for (uint x = 0; x < BoardSide; ++x)
            {
                for (uint y = 0; y < BoardSide; ++y)
                    Cells[x, y] = new Cell(x, y);
            }
        }

        /// <summary>
        /// Place les navires sur le plateau.
        /// </summary>
        /// <param name="shipsPosition"></param>
        public void PlaceShip(IEnumerable<ShipPosition> shipsPosition)
        {
            if (ships.Count > 0)
                throw new InvalidBoardException("Les navires ont déjà été disposés sur le plateau.");

            if (shipsPosition.Count() != Enum.GetNames(typeof(ClassOfShip)).Length)
                throw new InvalidBoardException($"{Enum.GetNames(typeof(ClassOfShip)).Length} navires doivent être ajoutés.");

            foreach (var shipPos in shipsPosition)
            {
                if (shipsPosition.Any(s => s.Class == shipPos.Class && !s.Equals(shipPos)))
                    throw new InvalidBoardException("Une seule classe de navire par plateau");

                Size sizeIncrement = shipPos.Orientation == Orientation.Horizontal ? new Size(1, 0) : new Size(0, 1);

                Ship ship = new Ship(shipPos);

                // Positionne les cases du navire sur le plateau.
                for (Point cellPos = ship.BottomRight; cellPos.X <= ship.TopLeft.X && cellPos.Y <= ship.TopLeft.Y; cellPos += sizeIncrement)
                {
                    if (IsOutside(cellPos))
                        throw new InvalidBoardException($"Le navire n'est pas positionné sur le plateau ({BoardSide}x{BoardSide})");

                    var cell = Cells[cellPos.X, cellPos.Y];

                    if (cell.Ship != null)
                        throw new InvalidBoardException("Deux navires ne peuvent pas être positionnés au même endroit");

                    cell.Ship = ship;
                }

                ships.Add(ship);
            }
        }

        /// <summary>
        /// Indique si les coordonnées sont en dehors du plateau.
        /// </summary>
        /// <param name="x">Coordonnée X</param>
        /// <param name="y">Coordonnée Y</param>
        /// <returns>true si les coordonnées sont en dehors sinon false.</returns>
        public bool IsOutside(int x, int y)
        {
            return (x < 0 || y < 0 || x > BoardSide - 1 || y > BoardSide - 1);
        }

        /// <summary>
        /// Indique si les coordonnées sont en dehors du plateau.
        /// </summary>
        /// <param name="coordonate">Coordonnées</param>
        /// <returns>true si les coordonnées sont en dehors sinon false.</returns>
        public bool IsOutside(Point coordonate)
        {
            return IsOutside(coordonate.X, coordonate.Y);
        }

        /// <summary>
        /// Tire aux coordonnées indiquées sur ce plateau.
        /// </summary>
        /// <param name="fireCoordonate"></param>
        /// <returns></returns>
        internal FireResult Fire(Point fireCoordonate)
        {
            if (fireCoordonate.X < 0 || fireCoordonate.Y < 0 ||
                fireCoordonate.X > BoardSide - 1 || fireCoordonate.Y > BoardSide - 1)
            {
                throw new InvalidBoardException($"Le navire n'est pas positionné dans le plateau ({BoardSide}x{BoardSide})");
            }

            var cell = Cells[fireCoordonate.X, fireCoordonate.Y];
            return cell.Fire();
        }
    }
}

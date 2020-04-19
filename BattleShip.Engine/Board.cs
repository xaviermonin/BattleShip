using BattleShip.Engine.Exception;
using BattleShip.PlayerBehavior;
using BattleShip.PlayerBehavior.Ships;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BattleShip.Engine.Utils;

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
        public const int BoardSide = 10;

        /// <summary>
        /// Navires placés.
        /// </summary>
        public IEnumerable<Ship> Ships { get => ships; }

        /// <summary>
        /// Cases du plateau.
        /// </summary>
        private readonly Cell[,] _cells;

        /// <summary>
        /// Indique si tous les navires sont coulés.
        /// </summary>
        public bool IsAllShipsSunk => Ships.All(s => s.State == ShipState.Sunk);

        /// <summary>
        /// Obtient une case du plateau
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Cell GetCell(int x, int y)
        {
            if (IsOutside(x, y))
                throw new ArgumentException("Coordonnées en dehors du plateau.");

            return _cells[x, y];
        }

        /// <summary>
        /// Cases du plateau.
        /// </summary>
        public IEnumerable<Cell> Cells => _cells.ToEnumerable();

        /// <summary>
        /// Construit un plateau de jeu de la bataille navale.
        /// </summary>
        public Board()
        {
            _cells = new Cell[BoardSide, BoardSide];

            for (int x = 0; x < BoardSide; ++x)
            {
                for (int y = 0; y < BoardSide; ++y)
                    _cells[x, y] = new Cell(x, y);
            }
        }

        /// <summary>
        /// Place les navires sur le plateau.
        /// </summary>
        /// <param name="shipsPosition"></param>
        internal void PlaceShip(IEnumerable<ShipPosition> shipsPosition)
        {
            if (ships.Count > 0)
                throw new InvalidBoardException("Les navires ont déjà été disposés sur le plateau.");

            if (shipsPosition.Count() != Enum.GetNames(typeof(ClassOfShip)).Length)
                throw new InvalidBoardException($"{Enum.GetNames(typeof(ClassOfShip)).Length} navires doivent être ajoutés.");

            foreach (var shipPos in shipsPosition)
            {
                if (shipsPosition.Any(s => s.Class == shipPos.Class && !s.Equals(shipPos)))
                    throw new InvalidBoardException("Une seule classe de navire par plateau.");

                Size sizeIncrement = shipPos.Orientation == Orientation.Horizontal ? new Size(1, 0) : new Size(0, 1);

                Ship ship = new Ship(shipPos);

                // Positionne les cases du navire sur le plateau.
                for (Point cellPos = ship.TopLeft; cellPos.X <= ship.BottomRight.X && cellPos.Y <= ship.BottomRight.Y; cellPos += sizeIncrement)
                {
                    if (IsOutside(cellPos))
                        throw new InvalidBoardException($"Le navire [{ship}] n'est pas positionné sur le plateau ({BoardSide}x{BoardSide})");
                     
                    var cell = _cells[cellPos.X, cellPos.Y];

                    if (cell.Ship != null)
                        throw new InvalidBoardException("Deux navires ne peuvent pas être positionnés au même endroit.");

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
            if (IsOutside(fireCoordonate))
                throw new InvalidBoardException($"Le tir est en dehors du plateau ({BoardSide}x{BoardSide})");

            var cell = _cells[fireCoordonate.X, fireCoordonate.Y];
            return cell.Fire();
        }

        /// <summary>
        /// Affiche la grille du plateau au format ASCII.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Entête
            string boardTable = "-";
            for (int i = 0; i < BoardSide; ++i)
                boardTable += "--";
            boardTable += Environment.NewLine;

            // Contenu des cases
            for (int y = 0; y < BoardSide; ++y)
            {
                boardTable += "|";

                for (int x = 0; x < BoardSide; ++x)
                    boardTable += $"{_cells[x, y].Ship?.ClassOfShipInfo.Symbol ?? ' '}|";

                boardTable += Environment.NewLine;
            }

            // Pied
            boardTable += "-";
            for (int i = 0; i < BoardSide; ++i)
                boardTable += "--";

            return boardTable;
        }
    }
}

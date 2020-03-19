using BattleShip.Engine.Exception;
using BattleShip.PlayerBehavior;
using BattleShip.PlayerBehavior.Ships;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BattleShip.Engine
{
    public class Board
    {
        private List<Ship> ShipPlaced { get; set; }

        private Cell[,] Cells { get; set; }

        private const int BoardSide = 10;

        public Board()
        {
            Cells = new Cell[BoardSide, BoardSide];
        }

        public void PlaceShip(IEnumerable<ShipPosition> shipsPosition)
        {           
            foreach (var ship in shipsPosition)
            {
                if (shipsPosition.Any(s => s.ClassOfShip == ship.ClassOfShip && !s.Equals(ship)))
                    throw new InvalidBoardException("Une seule classe de navire par plateau");

                if (ship.Coordonate.X < 0 || ship.Coordonate.Y < 0 ||
                    ship.Coordonate.X > BoardSide-1 || ship.Coordonate.Y > BoardSide-1)
                    throw new InvalidBoardException($"Le navire n'est pas positionné dans le plateau ({BoardSide}x{BoardSide})");

                var classInf = ClassOfShipInfo.FromClassOfShip(ship.ClassOfShip);

                //for (int x = ship.Coordonate.X, int y = ship.Coordonate.Y; ; )
            }
        }

        internal FireResult Fire(Point coordonate)
        {
            throw new NotImplementedException();
        }
    }
}

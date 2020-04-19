using Microsoft.Xna.Framework;

namespace BattleShip.Host.MonoGame.Game.Entities
{
    class Cell : Entity
    {
        Engine.Cell cell;
        Board board;

        public Cell(Engine.Cell cell, Board board)
        {
            this.cell = cell;
            this.board = board;
        }

        public override void Update()
        {
            Position = board.SeaPosition + new Vector2(cell.X * board.CellSize, cell.Y * board.CellSize);

            if (cell.Hit)
            {
                if (cell.IsEmpty)
                    Texture = Art.Miss;
                else
                    Texture = Art.Hit;
            }
            else
                Texture = null;
        }
    }
}

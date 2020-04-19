using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace BattleShip.Host.MonoGame.Game.Entities
{
    class Board : Entity
    {
        private readonly Engine.Player player;

        public float CellSize => (Texture.Width / 11) * Ratio;

        List<Ship> ships;
        List<Cell> cells;

        public Vector2 SeaPosition => Position + new Vector2(CellSize / 2, CellSize / 2);

        public Board(Engine.Player player)
        {
            this.player = player;

            Texture = Art.Board;

            ships = player.Board.Ships.Select(ship => new Ship(ship, this)).ToList();
            cells = player.Board.Cells.Select(cell => new Cell(cell, this)).ToList();
        }

        public override void Update()
        {
            ships.ForEach(s => s.Update());
            cells.ForEach(s => s.Update());
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            ships.ForEach(s => s.Draw(spriteBatch));
            cells.ForEach(c => c.Draw(spriteBatch));
        }
    }
}

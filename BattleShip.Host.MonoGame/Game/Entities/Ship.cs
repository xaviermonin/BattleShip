using BattleShip.PlayerBehavior.Ships;
using Microsoft.Xna.Framework;
using System;

namespace BattleShip.Host.MonoGame.Game.Entities
{
    class Ship : Entity
    {
        readonly Engine.Ship ship;
        Board board;

        public Ship(Engine.Ship ship, Board board)
        {
            this.ship = ship;
            this.board = board;
            
            switch (ship.Class)
            {
                case ClassOfShip.BattleShip: Texture = Art.Battleship; break;
                case ClassOfShip.Carrier: Texture = Art.Carrier; break;
                case ClassOfShip.Cruiser: Texture = Art.Cruiser; break;
                case ClassOfShip.Destroyer: Texture = Art.Destroyer; break;
                case ClassOfShip.Submarine: Texture = Art.Submarine; break;
                default: throw new InvalidOperationException("Navire inconnue.");
            }

            Origin = new Vector2(Texture.Height / 2, Texture.Height / 2);

            if (ship.Orientation == PlayerBehavior.Ships.Orientation.Vertical)
                Orientation = MathHelper.PiOver2;
        }

        public override void Update()
        {
            Position = new Vector2((ship.TopLeft.X * board.CellSize) + board.SeaPosition.X + (board.CellSize / 2),
                                   (ship.TopLeft.Y * board.CellSize) + board.SeaPosition.Y  + (board.CellSize / 2));
        }
    }
}

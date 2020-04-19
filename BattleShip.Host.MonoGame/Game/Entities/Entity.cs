using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Host.MonoGame.Game.Entities
{
    abstract class Entity
    {
        public Vector2 Position;
        protected Color Color = Color.White;
        public float Orientation;
        protected Texture2D Texture;
        public Vector2 Origin = Vector2.Zero;
        public float Ratio = 1f;

        public Vector2 Size => Texture == null ? Vector2.Zero : new Vector2(Texture.Width * Ratio, Texture.Height * Ratio);

        public abstract void Update();

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Texture != null)
                spriteBatch.Draw(Texture, Position, null, Color, Orientation, Origin, Ratio, 0, 0);
        }
    }
}

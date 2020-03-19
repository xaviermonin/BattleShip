using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Game
{
    abstract class Entity
    {
        public Vector2 Position;
        protected Color color = Color.White;
        public float Orientation;
        protected Texture2D image;

        public Vector2 Size => image == null ? Vector2.Zero : new Vector2(image.Width, image.Height);

        public abstract void Update();
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, Position, null, color, Orientation, Size / 2f, 1f, 0, 0);
        }
    }
}

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Host.MonoGame
{
    static class Art
    {
        public static Texture2D Paper;
        public static Texture2D Battleship;
        public static Texture2D Board;
        public static Texture2D Carrier;
        public static Texture2D Cruiser;
        public static Texture2D Destroyer;
        public static Texture2D Submarine;
        public static Texture2D Miss;
        public static Texture2D Hit;

        public static void Load(ContentManager content)
        {
            Paper = content.Load<Texture2D>("Art/Paper");
            Battleship = content.Load<Texture2D>("Art/Battleship");
            Board = content.Load<Texture2D>("Art/Board");
            Carrier = content.Load<Texture2D>("Art/Carrier");
            Cruiser = content.Load<Texture2D>("Art/Cruiser");
            Destroyer = content.Load<Texture2D>("Art/Destroyer");
            Submarine = content.Load<Texture2D>("Art/Submarine");
            Miss = content.Load<Texture2D>("Art/Miss");
            Hit = content.Load<Texture2D>("Art/Hit");
        }
    }
}

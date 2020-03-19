using BattleShip.PlayerBehavior;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Engine
{
    class Player
    {
        public Player()
        {
            Board = new Board();
        }

        public IPlayerBehavior Behavior { get; set; }

        public Board Board { get; }
    }
}

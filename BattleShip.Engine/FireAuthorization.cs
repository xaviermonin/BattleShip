using BattleShip.PlayerBehavior;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BattleShip.Engine
{
    class FireAuthorization : IFireAuthorization
    {
        private bool fire = false;

        public FireAuthorization(Player enemy)
        {
            Board = enemy.Board;
        }

        public Board Board { get; set; }

        public FireResult Fire(Point coordonate)
        {
            if (fire)
                throw new InvalidOperationException("Vous ne pouvez tirer qu'une seule fois par autorisation de tir !");

            return Board.Fire(coordonate);
        }
    }
}

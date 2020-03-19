using BattleShip.Engine;
using BattleShip.PlayerBehavior.IA;
using System;

namespace BattleShip.Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.InitializePartners(new DumbIA(), new DumbIA());

        }
    }
}

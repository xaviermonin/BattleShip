using System;

namespace BattleShip
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new BattleShip())
                game.Run();
        }
    }
}

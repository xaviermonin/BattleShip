using BattleShip.Engine;
using BattleShip.PlayerBehavior.IA;
using System;

namespace BattleShip.Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simulateur de bataile navale.");

            Console.WriteLine("Initialisation du jeu ...");

            Game game = new Game();
            game.InitializePlayers(new DumbIA(), new DumbIA());

            while (game.State != GameState.End)
                game.Update();

            if (game.Winner == GameWinner.Player1)
                Console.WriteLine("Le joueur 1 a gagné !");
            else if (game.Winner == GameWinner.Player2)
                Console.WriteLine("Le joueur 2 a gagné !");
        }
    }
}

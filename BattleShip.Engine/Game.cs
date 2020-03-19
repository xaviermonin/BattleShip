using BattleShip.PlayerBehavior;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Engine
{
    public class Game
    {
        Player player1, player2;

        public Game()
        {
            
        }

        public void InitializePartners(IPlayerBehavior partner1, IPlayerBehavior partner2)
        {
            player1 = new Player()
            {
                Behavior = partner1,
            };

            player2 = new Player()
            {
                Behavior = partner2,
            };

            player1.Board.PlaceShip(player1.Behavior.ShipPositions);
            player2.Board.PlaceShip(player2.Behavior.ShipPositions);
        }

        public void Update()
        {
            player1.Behavior.Fire(new FireAuthorization(player2));
            player2.Behavior.Fire(new FireAuthorization(player1));
        }
    }
}

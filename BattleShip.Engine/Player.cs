using BattleShip.PlayerBehavior;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BattleShip.Engine
{
    /// <summary>
    /// Joueur de la bataille navale.
    /// Décrit son comportement et son plateau.
    /// </summary>
    class Player
    {
        /// <summary>
        /// Construit un joueur à partir son comportement.
        /// </summary>
        /// <param name="playerBehavior"></param>
        public Player(IPlayerBehavior playerBehavior)
        {
            Board = new Board();
            Behavior = playerBehavior;
        }

        /// <summary>
        /// Comportement du joueur.
        /// </summary>
        private IPlayerBehavior Behavior { get; }

        /// <summary>
        /// Plateau de jeu du joueur.
        /// </summary>
        public Board Board { get; }

        /// <summary>
        /// Etat du joueur: A gagné, perdu.
        /// </summary>
        public PlayerState State
        {
            get
            {
                if (Board.IsAllShipsSunk)
                    return PlayerState.Lost;
                else
                    return PlayerState.Playing;
            }
        }

        /// <summary>
        /// Tir sur le joueur ennemi.
        /// </summary>
        /// <param name="enemy"></param>
        internal void Fire(Player enemy)
        {
            Behavior.Fire(new FireAuthorization(enemy));
        }

        /// <summary>
        /// Place les navires sur le plateau.
        /// </summary>
        internal void PlaceShip()
        {
            Board.PlaceShip(Behavior.ShipPositions);
        }
    }
}

using BattleShip.PlayerBehavior;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BattleShip.Engine.Exception;

namespace BattleShip.Engine
{
    /// <summary>
    /// Joueur de la bataille navale.
    /// Décrit son comportement et son plateau.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Construit un joueur à partir son comportement.
        /// </summary>
        /// <param name="playerBehavior"></param>
        internal Player(IPlayerBehavior playerBehavior)
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
        /// Autorisation de tir en cours.
        /// </summary>
        private FireAuthorization FireAuthorization { get; set; }

        /// <summary>
        /// Entrain de tirer ?
        /// </summary>
        public bool Shooting => FireAuthorization?.FireDone == false;

        /// <summary>
        /// Etat du joueur: Gagné/Perdu
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
        /// Demande au joueur de tirer sur joueur ennemi.
        /// </summary>
        /// <param name="enemy"></param>
        internal void Fire(Player enemy)
        {
            if (Shooting)
                throw new InvalidFireException("Le joueur est déjà entrain de tirer.");

            FireAuthorization = new FireAuthorization(enemy);

            Behavior.Fire(FireAuthorization);
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

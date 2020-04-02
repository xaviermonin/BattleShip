using BattleShip.PlayerBehavior;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Engine
{
    /// <summary>
    /// Partie de bataille navale.
    /// Confronte 2 joueurs.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Joueurs en confrontation.
        /// </summary>
        Player player1, player2;

        /// <summary>
        /// Etat de la partie.
        /// </summary>
        public GameState State { get; private set; }

        /// <summary>
        /// Joueur victorieux de cette partie.
        /// </summary>
        public GameWinner Winner
        {
            get
            {
                if (player1.State == PlayerState.Lost)
                    return GameWinner.Player2;
                else if (player2.State == PlayerState.Lost)
                    return GameWinner.Player1;

                return GameWinner.None;
            }
        }

        /// <summary>
        /// Constructeur par défaut de <see cref="Game"/>.
        /// </summary>
        public Game()
        {
            State = GameState.New;
        }

        /// <summary>
        /// Initialise les plateaux des joueurs.
        /// Demande à chaque joueur de positionner les navires sur le plateau.
        /// </summary>
        /// <param name="playerBehavior1"></param>
        /// <param name="playerBehavior2"></param>
        public void InitializePlayers(IPlayerBehavior playerBehavior1, IPlayerBehavior playerBehavior2)
        {
            if (playerBehavior1 == null)
                throw new ArgumentNullException(nameof(playerBehavior1));

            if (playerBehavior2 == null)
                throw new ArgumentNullException(nameof(playerBehavior2));

            player1 = new Player(playerBehavior1);
            player2 = new Player(playerBehavior2);

            player1.PlaceShip();
            player2.PlaceShip();

            State = GameState.Initialized;
        }

        /// <summary>
        /// Met à jour le jeu.
        /// Demande à chaque joueur d'effectuer sa logique de jeu.
        /// </summary>
        public void Update()
        {
            if (State == GameState.Initialized)
                State = GameState.Running;

            if (State != GameState.Running)
                throw new InvalidOperationException("Etat du jeu invalide.");
            
            player1.Fire(player2);
            if (player1.State == PlayerState.Lost)
            {
                State = GameState.End;
                return;
            }

            player2.Fire(player1);
            if (player2.State == PlayerState.Lost)
            {
                State = GameState.End;
                return;
            }
        }
    }
}

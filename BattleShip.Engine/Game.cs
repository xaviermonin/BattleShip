﻿using BattleShip.PlayerBehavior;
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
        /// Joueur 1.
        /// </summary>
        public Player Player1 { get; private set; } 


        /// <summary>
        /// Joueur 2.
        /// </summary>
        public Player Player2 { get; private set; }

        /// <summary>
        /// Etat de la partie.
        /// </summary>
        public GameState State { get; private set; }

        /// <summary>
        /// Etat de l'exécution du jeu.
        /// </summary>
        public RunningState RunningState { get; private set; }

        /// <summary>
        /// Joueur victorieux de cette partie.
        /// </summary>
        public GameWinner? Winner
        {
            get
            {
                if (Player1.State == PlayerState.Lost && Player2.State == PlayerState.Lost)
                    return GameWinner.Draw;
                else if (Player1.State == PlayerState.Lost)
                    return GameWinner.Player2;
                else if (Player2.State == PlayerState.Lost)
                    return GameWinner.Player1;

                return null;
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

            Player1 = new Player(playerBehavior1);
            Player2 = new Player(playerBehavior2);

            Player1.PlaceShip();
            Player2.PlaceShip();

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

            if (Player1.Shooting || Player2.Shooting)
                return; // En attente d'un tir

            if (Player1.State == PlayerState.Lost || Player2.State == PlayerState.Lost)
            {
                State = GameState.End;
                return;
            }

            // Demande aux deux joueurs de tirer en même temps.
            // Le statut de la partie est déterminé une fois les tirs de chaque joueur résolus.
            // Une égalité est donc possible si les 2 joueurs ont coulés leur dernier navire enemi pendant le même tour.

            Player1.Fire(Player2);
            Player2.Fire(Player1);
        }
    }
}

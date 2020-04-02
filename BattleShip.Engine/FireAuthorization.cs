using BattleShip.PlayerBehavior;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BattleShip.Engine
{
    /// <summary>
    /// Autorisation de tir.
    /// Permet d'effectuer un tir sur le plateau ennemi et d'obtenir le résultat du tir.
    /// </summary>
    class FireAuthorization : IFireAuthorization
    {
        /// <summary>
        /// Tir effectué ?
        /// </summary>
        private bool fire = false;

        public FireAuthorization(Player enemy)
        {
            Board = enemy.Board;
        }

        /// <summary>
        /// Plateau cible.
        /// </summary>
        internal Board Board { get; set; }

        /// <summary>
        /// Action de tir sur le plateau ennemi.
        /// </summary>
        /// <param name="coordonate"></param>
        /// <returns></returns>
        public FireResult Fire(Point coordonate)
        {
            if (fire)
                throw new InvalidOperationException("Vous ne pouvez tirer qu'une seule fois par autorisation de tir !");

            fire = true;

            return Board.Fire(coordonate);
        }
    }
}

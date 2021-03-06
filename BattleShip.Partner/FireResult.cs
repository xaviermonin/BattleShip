﻿using BattleShip.PlayerBehavior.Ships;

namespace BattleShip.PlayerBehavior
{
    /// <summary>
    /// Résultat du tir.
    /// </summary>
    public class FireResult
    {
        /// <summary>
        /// Navire touché ou coulé.
        /// Renseigné uniquement lorsque le navire est touché ou coulé.
        /// </summary>
        public ClassOfShip? Ship { get; set; }

        /// <summary>
        /// Etat du tir: Touché, Coulé, Manqué.
        /// </summary>
        public FireState State { get; set; }
    }
}
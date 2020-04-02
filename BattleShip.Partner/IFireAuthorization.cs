using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BattleShip.PlayerBehavior
{
    /// <summary>
    /// Autorisation de tirer. Permet d'effectuer un tir à des coordonnées du plateau de jeu.
    /// Le plateau de jeu est de 10x10, commence à 0x0 et se termine à 9x9.
    /// </summary>
    public interface IFireAuthorization
    {
        /// <summary>
        /// Tirer à des coordonnées du plateau de jeu.
        /// Le plateau de jeu est de 10x10, commence aux coordonnées 0x0 et se termine à 9x9.
        /// </summary>
        /// <param name="coordonate">Coordonnées de tir (X, Y)</param>
        /// <returns>Résultat du tir (Touché, Coulé, Manqué)</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1030:Utiliser des événements quand cela est approprié", Justification = "Fire ne veut pas dire lancer un évènement mais tirer")]
        FireResult Fire(Point coordonate);
    }
}

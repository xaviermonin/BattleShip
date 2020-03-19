using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BattleShip.PlayerBehavior
{
    /// <summary>
    /// Autorisation de tirer. Permet d'effectuer un tir à des coordonnées du plateau de jeu.
    /// </summary>
    public interface IFireAuthorization
    {
        /// <summary>
        /// Tirer à des coordonnées du plateau de jeu.
        /// </summary>
        /// <param name="coordonate">Coordonnées de tir (X, Y)</param>
        /// <returns>Résultat du tir (Touché, Coulé, Manqué)</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1030:Utiliser des événements quand cela est approprié", Justification = "Fire ne veut pas dire lancer un évènement mais tirer")]
        FireResult Fire(Point coordonate);
    }
}

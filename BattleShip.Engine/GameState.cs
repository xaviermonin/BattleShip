namespace BattleShip.Engine
{
    /// <summary>
    /// Etat du jeu de bataille navale.
    /// </summary>
    public enum GameState
    {
        /// <summary>
        /// Nouvelle partie.
        /// </summary>
        New,
        /// <summary>
        /// Partie initialisée. Les navires ont été positionnés.
        /// </summary>
        Initialized,
        /// <summary>
        /// Partie en cours.
        /// </summary>
        Running,
        /// <summary>
        /// Partie terminée.
        /// </summary>
        End
    }
}
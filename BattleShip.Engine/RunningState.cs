namespace BattleShip.Engine
{
    /// <summary>
    /// Etat de l'exécution du jeu.
    /// </summary>
    public enum RunningState
    {
        /// <summary>
        /// Le jeu n'est pas en cours d'exécution.
        /// </summary>
        NotRunning,

        /// <summary>
        /// En attente du joueur 1.
        /// </summary>
        WaitingPlayer1,

        /// <summary>
        /// En attente du joueur 2.
        /// </summary>
        WaitingPlayer2
    }
}
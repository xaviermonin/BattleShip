namespace BattleShip.PlayerBehavior
{
    /// <summary>
    /// Etat du tir: Manqué, touché ou coulé.
    /// </summary>
    public enum FireState
    {
        /// <summary>
        /// Touché.
        /// </summary>
        Hit,
        /// <summary>
        /// Coulé.
        /// </summary>
        Sunk,
        /// <summary>
        /// Manqué.
        /// </summary>
        Miss
    }
}
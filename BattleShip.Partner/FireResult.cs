using BattleShip.PlayerBehavior.Ships;

namespace BattleShip.PlayerBehavior
{
    /// <summary>
    /// Résultat du tir.
    /// </summary>
    public struct FireResult : System.IEquatable<FireResult>
    {
        /// <summary>
        /// Navire touché ou coulé. Nul si le tir est manqué.
        /// </summary>
        public ClassOfShip? Ship { get; set; }

        /// <summary>
        /// Etat du tir: Touché, Coulé, Manqué.
        /// </summary>
        public FireState State { get; set; }

        public override bool Equals(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }

        public static bool operator ==(FireResult left, FireResult right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FireResult left, FireResult right)
        {
            return !(left == right);
        }

        public bool Equals(FireResult other)
        {
            throw new System.NotImplementedException();
        }
    }

    public enum FireState
    {
        Hit,
        Sunk,
        Miss
    }
}
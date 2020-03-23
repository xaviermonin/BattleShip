using System;

namespace BattleShip.PlayerBehavior.Ships
{
    /// <summary>
    /// Information sur la classe de navire.
    /// </summary>
    public class ClassOfShipInfo
    {
        private ClassOfShipInfo() { }

        /// <summary>
        /// Nom du navire.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Taille du navire.
        /// </summary>
        public int Lenght { get; private set; }

        /// <summary>
        /// Classe du navire.
        /// </summary>
        public ClassOfShip ClassOfShip { get; private set; }

        /// <summary>
        /// Obtient l'information du navire à partir de la classe de navire.
        /// </summary>
        /// <param name="classOfShip"></param>
        /// <returns></returns>
        public static ClassOfShipInfo FromClassOfShip(ClassOfShip classOfShip)
        {
            switch (classOfShip)
            {
                case ClassOfShip.Destroyer:     return new ClassOfShipInfo() { Name = "Destroyer",   Lenght = 2, ClassOfShip = classOfShip };
                case ClassOfShip.Cruiser:       return new ClassOfShipInfo() { Name = "Cruiser",     Lenght = 3, ClassOfShip = classOfShip };
                case ClassOfShip.BattleShip1:   return new ClassOfShipInfo() { Name = "BattleShip",  Lenght = 4, ClassOfShip = classOfShip };
                case ClassOfShip.BattleShip2:   return new ClassOfShipInfo() { Name = "BattleShip",  Lenght = 2, ClassOfShip = classOfShip };
                case ClassOfShip.Carrier:       return new ClassOfShipInfo() { Name = "Carrier",     Lenght = 5, ClassOfShip = classOfShip };
                default:
                    throw new InvalidOperationException("Type de navire inconnue");
            }
        }
    }
}

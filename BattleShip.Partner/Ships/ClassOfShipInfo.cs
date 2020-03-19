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
        public int Size { get; private set; }

        /// <summary>
        /// Obtient l'information du navire à partir de la classe de navire.
        /// </summary>
        /// <param name="classOfShip"></param>
        /// <returns></returns>
        public static ClassOfShipInfo FromClassOfShip(ClassOfShip classOfShip)
        {
            switch (classOfShip)
            {
                case ClassOfShip.Destroyer:     return new ClassOfShipInfo() { Name = "Destroyer",   Size = 2 };
                case ClassOfShip.Cruiser:       return new ClassOfShipInfo() { Name = "Cruiser",     Size = 3 };
                case ClassOfShip.BattleShip1:   return new ClassOfShipInfo() { Name = "BattleShip",  Size = 4 };
                case ClassOfShip.BattleShip2:   return new ClassOfShipInfo() { Name = "BattleShip",  Size = 2 };
                case ClassOfShip.Carrier:       return new ClassOfShipInfo() { Name = "Carrier",     Size = 5 };
                default:
                    throw new InvalidOperationException("Type de navire inconnue");
            }
        }
    }
}

using BattleShip.PlayerBehavior.Ships;
using System.Collections.Generic;
using System.Drawing;

namespace BattleShip.PlayerBehavior.IA
{
    public class DumbIA : IPlayerBehavior
    {
        public IEnumerable<ShipPosition> ShipPositions => new List<ShipPosition>()
        {
            new ShipPosition(){
                ClassOfShip = ClassOfShip.BattleShip1,
                Coordonate = new Point(4, 5),
                Orientation = Orientation.Horizontal
            },
        };

        public void Fire(IFireAuthorization fireAuthorization)
        {
            var result = fireAuthorization.Fire(new Point(1, 2));

            switch (result.State)
            {
                case FireState.Hit: break;
                case FireState.Miss: break;
                case FireState.Sunk: break;
            }

            if (result.Ship.HasValue)
            {
                var classOfShipInformation = ClassOfShipInfo.FromClassOfShip(result.Ship.Value);
                int size = classOfShipInformation.Size;
            }
        }
    }
}

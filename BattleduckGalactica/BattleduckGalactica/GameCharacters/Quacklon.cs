using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleduckGalactica.GameCharacters
{
    public class Quacklon : Character
    {
        public string EnemyShipType { get; set; }

        public void SetShipType()
        {
            Random RNGeezus = new Random();
            int ShipChoice = RNGeezus.Next(0, 3);
            QuacklonFactory.Factory QuacklonzYo = new QuacklonFactory.Factory();
            QuacklonFactory.QuacklonShipType ShipType = QuacklonzYo.QuacklonShips(ShipChoice);
            EnemyShipType = ShipType.GetQuacklonType();


        }
    }
}

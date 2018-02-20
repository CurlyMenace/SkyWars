using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleduckGalactica.GameCharacters
{
    public class Player : Character
    {
        public string PlayerMode{get;set;}
        
        public Player()
        {
            ID = "Player";
        }
        public void SetShipMode(int number)
        {
            Strategy.IMode ShipMode = null;

            if(number == 0)
            {
                ShipMode = new Strategy.DefensiveMode();
            }

            else
            {
                ShipMode = new Strategy.OffensiveMode();
            }

            PlayerMode = ShipMode.ShipMode();
        }
    }
}

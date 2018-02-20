using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleduckGalactica.Strategy
{
    public class DefensiveMode : IMode
    {

        public string ShipMode()
        {
            return "Defensive";
        }
    }
}

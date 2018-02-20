using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleduckGalactica.GameCharacters
{
    public abstract class Character
    {
        public string TypeOfShip { get; set; }

        public int MoveCounter { get; set; }

        public string ID { get; set; }
        public Location CurrentLocation { get; set; }

        public void SetQuacklonDefaultPos()
        {
            Location NewLocation = new Location();
            NewLocation.XCoordinate = 0;
            NewLocation.YCoordinate = 0;

            CurrentLocation = NewLocation;
        }

        public void MakeMove()
        {
            int x;
            int y;

            Random RNG = new Random();
            x = RNG.Next(0, 3);
            y = RNG.Next(0, 3);
            if (!(x == 0 && y == 0))
            {
                Location NewLocation = new Location();
                NewLocation.XCoordinate = x;
                NewLocation.YCoordinate = y;

                CurrentLocation = NewLocation;
            }
        }
    }
}

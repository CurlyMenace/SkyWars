using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleduckGalactica.QuacklonFactory
{
   public class Factory
    {
       public QuacklonShipType QuacklonShips(int i) 
       {
           QuacklonShipType QuackQuack = null;

           if(i == 0)
           {
               QuackQuack = new QuacklonBattlestar();
           }

           else if(i == 1)
           {
               QuackQuack = new QuacklonBattlecruiser();
           }

           else if(i == 2)
           {
               QuackQuack = new QuacklonRaider();
           }

           else
           {
               QuackQuack = new QuacklonBattlestar();
           }
           return QuackQuack;
       }
    }
}

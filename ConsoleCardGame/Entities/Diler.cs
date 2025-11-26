using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCardGame.Entities
{
    internal class Diler
    {
        public List<Card> dilerCards = new List<Card>();
        public static List<Card> dilerCardsonTable = new List<Card>();


        public void CardsOnTable()
        {
            dilerCardsonTable = dilerCards;
        }
    }
}

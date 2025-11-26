using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCardGame.Entities
{
    internal class Player
    {
        public List<Card> playerCards = new List<Card>();
        public static List<Card> playerCardsonTable = new List<Card>();

        public void CardsOnTable()
        {
            playerCardsonTable = playerCards;
        }

        public bool Check21()
        {
            int sum = 0;
            foreach (Card card in playerCardsonTable)
            {
                switch (card.sign)
                {
                    case "2":
                        sum += 2;
                        break;
                    case "3":
                        sum += 3;
                        break;
                    case "4":
                        sum += 4;
                        break;
                    case "5":
                        sum += 5;
                        break;
                    case "6":
                        sum += 6;
                        break;
                    case "7":
                        sum += 7;
                        break;
                    case "8":
                        sum += 8;
                        break;
                    case "9":
                        sum += 9;
                        break;
                    case "10":
                        sum += 10;
                        break;
                    case "В":
                        sum += 10;
                        break;
                    case "Д":
                        sum += 10;
                        break;
                    case "К":
                        sum += 10;
                        break;
                    case "Т":
                        if (sum + 10 <= 21)
                        {
                            sum += 10;
                        }
                        else
                        {
                            sum++;
                        }
                        break;
                }                    
            }
            if (sum <= 21)
            {
                return false;
            }
            return true;
        }
    }
}

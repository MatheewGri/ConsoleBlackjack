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
            CountCards();
            if (CountCards() <= 21)
            {
                return false;
            }
            return true;
        }

        public int CountCards()
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
                    case "J":
                        sum += 10;
                        break;
                    case "Q":
                        sum += 10;
                        break;
                    case "K":
                        sum += 10;
                        break;
                    case "A":
                        if (sum + 11 <= 21)
                        {
                            sum += 11;
                        }
                        else
                        {
                            sum++;
                        }
                        break;
                }
            }
            return sum;
        }
    }
}

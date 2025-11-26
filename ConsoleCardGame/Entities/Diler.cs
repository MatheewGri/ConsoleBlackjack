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
        private List<Card> playerCards;
        private int playerSum = 0;


        public void CardsOnTable()
        {
            dilerCardsonTable = dilerCards;
        }

        public bool Play(int playerSum)
        {
            
            
            int sum = CountCards();
            if (sum >= playerSum) { return false; }
            if (sum <= 11) { return true; }
            else if (playerSum > 12 && sum <= 12) { return true; }
            else if (playerSum > 13 && sum <= 13) { return true; }
            else if (playerSum > 14 && sum <= 14) { return true; }
            else if (playerSum > 15 && sum <= 15) { return true; }
            else if (playerSum > 16 && sum <= 16) { return true; }

            return false;
        }

        public bool Check21()
        {
            int sum = 0;
            foreach (Card card in dilerCardsonTable)
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
            if (sum <= 21)
            {
                return false;
            }
            return true;
        }

        public int CountCards()
        {
            int sum = 0;
            foreach (Card card in dilerCardsonTable)
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

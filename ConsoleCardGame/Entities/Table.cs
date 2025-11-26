using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCardGame.Entities
{
    internal class Table
    {
        public void DrawDilerCards(string language)
        {
            int i = 0;
            if (language == "RUS") { Console.WriteLine("+++++< Карты дилера >+++++"); }
            if (language == "ENG") { Console.WriteLine("+++++< Diler cards >+++++"); }
            Console.WriteLine(string.Empty);
            List<string> table = ["", "", "", "", "", ""];
            foreach (Card card in Diler.dilerCardsonTable)
            {
                if (i == 0)
                {
                    if (card.isClosed)
                    {
                        table[0] = $"          ";
                        table[1] = $"  ________";
                        table[2] = $" /+#+#+#+#|";
                        table[3] = $" |#+#+#+#+|";
                        table[4] = $" |+#+#+#+#|";
                        table[5] = $" |#+#+#+#+|";
                    }
                    else if (card.sign != "10")
                    {
                        table[0] = $"          ";
                        table[1] = $"  ________";
                        table[2] = $" / {card.suit}{card.sign}     |";
                        table[3] = $" |        |";
                        table[4] = $" |        |";
                        table[5] = $" |        |";
                    }
                    else
                    {
                        table[0] = $"          ";
                        table[1] = $"  ________";
                        table[2] = $" / {card.suit}{card.sign}    |";
                        table[3] = $" |        |";
                        table[4] = $" |        |";
                        table[5] = $" |        |";
                    }
                    
                }
                else
                {
                    if (card.sign != "10")
                    {
                        table[0] += $" ________ ";
                        table[1] += $"/ {card.suit}{card.sign}     |";
                        table[2] += $"          |";
                        table[3] += $"          |";
                        table[4] += $"          |";
                        table[5] += $"        / ";
                    }
                    else
                    {
                        table[0] += $" ________ ";
                        table[1] += $"/ {card.suit}{card.sign}    |";
                        table[2] += $"          |";
                        table[3] += $"          |";
                        table[4] += $"          |";
                        table[5] += $"        / ";
                    }
                }
                i++;
            }
            foreach (string str in table)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine(string.Empty);
            
        }

        public void DrawPlayerCards(string language)
        {
            int i = 0;
            Console.WriteLine(string.Empty);
            List<string> table = ["", "", "", "", "", ""];
            foreach (Card card in Player.playerCardsonTable)
            {
                if (i == 0)
                {
                    if (card.sign != "10")
                    {
                        table[0] = $"          ";
                        table[1] = $"  ________";
                        table[2] = $" / {card.suit}{card.sign}     |";
                        table[3] = $" |        |";
                        table[4] = $" |        |";
                        table[5] = $" |        |";
                    }
                    else
                    {
                        table[0] = $"          ";
                        table[1] = $"  ________";
                        table[2] = $" / {card.suit}{card.sign}    |";
                        table[3] = $" |        |";
                        table[4] = $" |        |";
                        table[5] = $" |        |";
                    }

                }
                else
                {
                    if (card.sign != "10")
                    {
                        table[0] += $"  ________ ";
                        table[1] += $" / {card.suit}{card.sign}     |";
                        table[2] += $"         |";
                        table[3] += $"         |";
                        table[4] += $"         |";
                        table[5] += $"         / ";
                    }
                    else
                    {
                        table[0] += $"  ________ ";
                        table[1] += $" / {card.suit}{card.sign}    |";
                        table[2] += $"         |";
                        table[3] += $"         |";
                        table[4] += $"         |";
                        table[5] += $"         / ";
                    }
                }
                i++;
            }
            foreach (string str in table)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine(string.Empty);
            if (language == "RUS") { Console.WriteLine("=====| Ваши карты |====="); }
            if (language == "ENG") { Console.WriteLine("=====| Your cards |====="); }


        }

        public void DrawCard(Card card)
        {
            List<string> table = ["", "", "", "", "", ""];
            if (card.sign != "10")
            {
                table[0] = $" ________ ";
                table[1] = $"/ {card.suit}{card.sign}     |";
                table[2] = $"         |";
                table[3] = $"         |";
                table[4] = $"         |";
                table[5] = $"         / ";
            }
            else
            {
                table[0] = $" ________ ";
                table[1] = $"/ {card.suit}{card.sign}    |";
                table[2] = $"         |";
                table[3] = $"         |";
                table[4] = $"         |";
                table[5] = $"         / ";
            }
            foreach (string str in table)
            {
                Console.WriteLine(str);
            }
        }

        
    }
}

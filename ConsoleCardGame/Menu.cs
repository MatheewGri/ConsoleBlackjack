using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace ConsoleCardGame
{
    internal class Menu
    {
        public static List<Card> cards = new List<Card>();
        public static List<string> suits = new List<string> { "♥", "♦", "♣", "♠" };
        public static List<string> signs = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "В", "Д", "К", "Т" };

        public static List<Card> playerCards = new List<Card>();
        public static List<Card> dilerCards = new List<Card>();

        public static List<Card> dilerCardsToDraw = new List<Card>();
        public static List<Card> playerCardsToDraw = new List<Card>();

        public int typeId;
        private string[] menuItems = {  };
        public int actualItem = 0;
        public bool exit = false;
        public bool run = false;
        public bool isStarted = false;
        public int money = 10000;
        public int debt = 0;

        List<ConsoleKey> numberKeys = new List<ConsoleKey> { ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5, ConsoleKey.D6, ConsoleKey.D7, ConsoleKey.D8, ConsoleKey.D9, ConsoleKey.D0 };

        ConsoleKeyInfo pressedButton;

        public Menu(int typeId) { this.typeId = typeId; }

        public void InitializeMenu(int typeId, int item)
        {
            Console.Clear();
            if (typeId == 0)
            {
                menuItems = ["Сделать ставку",
                "Выход"];
            }
            else if (typeId == 1)
            {
                menuItems = ["Еще карта",
                "Достаточно",
                "Выход"];
            }
            else if (typeId == 2)
            {
                menuItems = ["Еще карта",
                "Достаточно",
                "Разделить",
                "Выход"];
            }
            actualItem = item;
            if (isStarted)
            {
                
                Console.WriteLine("+++++< Карты дилера >+++++");
                Console.WriteLine(string.Empty);
                DrawCards(dilerCards);
                Console.WriteLine(string.Empty);
                Console.WriteLine(string.Empty);
                Console.WriteLine(string.Empty);
                DrawCards(playerCards);
                Console.WriteLine(string.Empty);
                Console.WriteLine("=====| Ваши карты |=====");
            }
            Console.WriteLine($"СТАВКА: {debt}");
            Console.WriteLine($"СРЕДСТВА: {money}");
            Console.WriteLine("+=+=+=+=+=| Выберите действие |+=+=+=+=+=");
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i != item) { Console.WriteLine("  " + Convert.ToString(i + 1) + ". " + menuItems[i]); }
                else { Console.WriteLine("> " + Convert.ToString(i + 1) + ". " + menuItems[i] + " <"); }
            }
            while (!exit)
            {
                Console.WriteLine(Convert.ToString(typeId) + Convert.ToString(item));
                pressedButton = Console.ReadKey();
                if (pressedButton.Key is ConsoleKey.DownArrow || pressedButton.Key is ConsoleKey.S) { switchItemDown(); }
                else if (pressedButton.Key is ConsoleKey.UpArrow || pressedButton.Key is ConsoleKey.W) { switchItemUp(); }
                else if (pressedButton.Key is ConsoleKey.Enter)
                {
                    RunItem();
                    if (exit) { break; }
                }
                
                else { foreach (var Button in numberKeys) { if (pressedButton.Key == Button) { actualItem = ((int)pressedButton.Key); run = true; RunItem(); } } }
            }

            
        }

        public void switchItemDown()
        {
            if (actualItem < menuItems.Length - 1)
            {
                actualItem += 1;
                Console.Clear();
                InitializeMenu(typeId, actualItem);
            }
            else { actualItem = 0; Console.Clear(); InitializeMenu(typeId, actualItem); }
        }
        public void switchItemUp()
        {
            if (actualItem > 0)
            {
                actualItem -= 1;
                Console.Clear();
                InitializeMenu(typeId, actualItem);
            }
            else { actualItem = menuItems.Length - 1;Console.Clear(); InitializeMenu(typeId, actualItem); }
        }

        public void RunItem()
        {
            run = false;
            if (typeId == 0)
            {
                if (actualItem == 0)
                {
                    Console.WriteLine("$$$ Введите ставку $$$");
                    debt = int.Parse(Console.ReadLine());
                    StartGame();
                    return;
                }
                if (actualItem == 1)
                {
                    exit = true;
                    return;
                }
            }
            if (typeId == 1)
            {
                if (actualItem == 0)
                {
                    OneMoreCard();
                    return;
                }
                if (actualItem == 1)
                {
                    Enough();
                    return;
                }
                if (actualItem == 2)
                {
                    exit = true;
                }
            }


        }

        public void StartGame()
        {
            isStarted = true;
            CreateCards();
            SwitchCards();
            GivingCards();
            Console.WriteLine($"СТАВКА: {debt}");
            money -= debt;
            Console.WriteLine($"СРЕДСТВА: {money}");
            if (playerCards[0] == playerCards[1])
            {
                typeId = 2;
                actualItem = 0;
                this.InitializeMenu(2, 0);
                
            }
            else if (playerCards[0] != playerCards[1])
            {
                typeId = 1;
                actualItem = 0;
                this.InitializeMenu(1, 0);

            }
        }

        private static void CreateCards()
        {
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Card card = new Card(suits[j], signs[i]);
                    cards.Add(card);
                    cards.Add(card);
                }
            }
        }

        private static void SwitchCards()
        {
            Random random = new Random();
            Card cardToSwithc;
            for (int i = 0; i < cards.Count() - 1; i++)
            {
                int j = random.Next(i + 1, cards.Count());
                cardToSwithc = cards[j];
                cards[j] = cards[i];
                cards[i] = cardToSwithc;
            }
        }

        private static void GivingCards()
        {
            foreach (var card in cards)
            {
                if (!card.isGived) { playerCards.Add(card); card.isGived = true; break; }
            }
            foreach (var card in cards)
            {
                if (!card.isGived) { playerCards.Add(card); card.isGived = true;  break; }
            }
            foreach (var card in cards)
            {
                if (!card.isGived) { dilerCards.Add(card); card.isGived = true; break; }
            }
            foreach (var card in cards)
            {
                if (!card.isGived) { dilerCards.Add(card); card.isGived = true; card.isClosed = true; break; }
            }

            

            Card closedCard = new Card("0", "0");
            
        }

        private static void DrawCards(List<Card> cardsToDraw)
        {
            if (cardsToDraw.Count == 2) 
            {
                Card card1 = cardsToDraw[0];
                Card card2 = cardsToDraw[1];
                if (card1.sign != "10" && card2.isClosed)
                {
                    Console.WriteLine("            ________");
                    Console.WriteLine($"  ________ /X#X#X#X#X|");
                    Console.WriteLine($" /  {card1.suit}{card1.sign}    |X#X#X#X#X#|");
                    Console.WriteLine("|         |#X#X#X#X#X|");
                    Console.WriteLine("|         |X#X#X#X#X#|");
                    Console.WriteLine("|         |#X#X#X#X#X|");
                }
                else if (card1.sign == "10" && card2.isClosed)
                {
                    Console.WriteLine("            ________");
                    Console.WriteLine($"  ________ /X#X#X#X#X|");
                    Console.WriteLine($" /  {card1.suit}{card1.sign}   |X#X#X#X#X#|");
                    Console.WriteLine("|         |#X#X#X#X#X|");
                    Console.WriteLine("|         |X#X#X#X#X#|");
                    Console.WriteLine("|         |#X#X#X#X#X|");
                }
                else if (card1.sign != "10" && card2.sign != "10")
                {
                    Console.WriteLine("            ________");
                    Console.WriteLine($"  ________ /  {card2.suit}{card2.sign}     |");
                    Console.WriteLine($" /  {card1.suit}{card1.sign}    |          |");
                    Console.WriteLine("|         |          |");
                    Console.WriteLine("|         |          |");
                    Console.WriteLine("|         |          |");
                }
                else if (card1.sign != "10" && card2.sign == "10")
                {
                    Console.WriteLine("            ________");
                    Console.WriteLine($"  ________ /  {card2.suit}{card2.sign}    |");
                    Console.WriteLine($" /  {card1.suit}{card1.sign}    |          |");
                    Console.WriteLine("|         |          |");
                    Console.WriteLine("|         |          |");
                    Console.WriteLine("|         |          |");
                }
                else if (card1.sign == "10" && card2.sign != "10")
                {
                    Console.WriteLine("            ________");
                    Console.WriteLine($"  ________ /  {card2.suit}{card2.sign}     |");
                    Console.WriteLine($" /  {card1.suit}{card1.sign}   |          |");
                    Console.WriteLine("|         |          |");
                    Console.WriteLine("|         |          |");
                    Console.WriteLine("|         |          |");
                }
                else
                {
                    Console.WriteLine("            ________");
                    Console.WriteLine($"  ________ /  {card2.suit}{card2.sign}    |");
                    Console.WriteLine($" /  {card1.suit}{card1.sign}   |          |");
                    Console.WriteLine("|         |          |");
                    Console.WriteLine("|         |          |");
                    Console.WriteLine("|         |          |");
                }
            }
            else if (cardsToDraw.Count == 3)
            {
                Card card1 = cardsToDraw[0];
                Card card2 = cardsToDraw[1];
                Card card3 = cardsToDraw[2];
                if (card1.sign != "10" && card2.sign != "10" && card3.sign != "10")
                {
                    Console.WriteLine("            ________   _________");
                    Console.WriteLine($"  ________ /  {card2.suit}{card2.sign}     /  {card3.suit}{card3.sign}      |");
                    Console.WriteLine($" /  {card1.suit}{card1.sign}    |          |          |");
                    Console.WriteLine("|         |          |          |");
                    Console.WriteLine("|         |          |          |");
                    Console.WriteLine("|         |          |          |");
                }
                else if (card1.sign != "10" && card2.sign == "10" && card3.sign != "10")
                {
                    Console.WriteLine("            ________   _________");
                    Console.WriteLine($"  ________ / {card2.suit}{card2.sign}     /  {card3.suit}{card3.sign}      |");
                    Console.WriteLine($" /  {card1.suit}{card1.sign}    |          |          |");
                    Console.WriteLine("|         |          |          |");
                    Console.WriteLine("|         |          |          |");
                    Console.WriteLine("|         |          |          |");
                }
                else if (card1.sign == "10" && card2.sign != "10" && card3.sign != "10")
                {
                    Console.WriteLine("            ________   _________");
                    Console.WriteLine($"  ________ /  {card2.suit}{card2.sign}     /  {card3.suit}{card3.sign}      |");
                    Console.WriteLine($" / {card1.suit}{card1.sign}    |          |          |");
                    Console.WriteLine("|         |          |          |");
                    Console.WriteLine("|         |          |          |");
                    Console.WriteLine("|         |          |          |");
                }
                else if (card1.sign != "10" && card2.sign!= "10" && card3.sign == "10")
                {
                    Console.WriteLine("            ________   _________");
                    Console.WriteLine($"  ________ /  {card2.suit}{card2.sign}     / {card3.suit}{card3.sign}      |");
                    Console.WriteLine($" /  {card1.suit}{card1.sign}    |          |          |");
                    Console.WriteLine("|         |          |          |");
                    Console.WriteLine("|         |          |          |");
                    Console.WriteLine("|         |          |          |");
                }
                else if (card1.sign == "10" && card2.sign == "10" && card3.sign != "10")
                {
                    Console.WriteLine("            ________   _________");
                    Console.WriteLine($"  ________ / {card2.suit}{card2.sign}     /  {card3.suit}{card3.sign}      |");
                    Console.WriteLine($" / {card1.suit}{card1.sign}    |          |");
                    Console.WriteLine("|         |          |          |");
                    Console.WriteLine("|         |          |          |");
                    Console.WriteLine("|         |          |          |");
                }
                else if (card1.sign != "10" && card2.sign == "10" && card3.sign == "10")
                {
                    Console.WriteLine("            ________   _________");
                    Console.WriteLine($"  ________ / {card2.suit}{card2.sign}     / {card3.suit}{card3.sign}      |");
                    Console.WriteLine($" /  {card1.suit}{card1.sign}    |          |          |");
                    Console.WriteLine("|         |          |          |");
                    Console.WriteLine("|         |          |          |");
                    Console.WriteLine("|         |          |          |");
                }
                else if (card1.sign == "10" && card2.sign!= "10" && card3.sign == "10")
                {
                    Console.WriteLine("            ________   _________");
                    Console.WriteLine($"  ________ /  {card2.suit}{card2.sign}     / {card3.suit}{card3.sign}      |");
                    Console.WriteLine($" / {card1.suit}{card1.sign}    |          |          |");
                    Console.WriteLine("|         |          |          |");
                    Console.WriteLine("|         |          |          |");
                    Console.WriteLine("|         |          |          |");
                }
                else
                {
                    Console.WriteLine("            ________   _________");
                    Console.WriteLine($"  ________ / {card2.suit}{card2.sign}     / {card3.suit}{card3.sign}      |");
                    Console.WriteLine($" / {card1.suit}{card1.sign}    |          |          |");
                    Console.WriteLine("|         |          |          |");
                    Console.WriteLine("|         |          |          |");
                    Console.WriteLine("|         |          |          |");
                }
            }
            else if (cardsToDraw.Count == 4)
            {
                Card card1 = cardsToDraw[0];
                Card card2 = cardsToDraw[1];
                Card card3 = cardsToDraw[2];
                Card card4 = cardsToDraw[3];
            }
            else if (cardsToDraw.Count == 5)
            {
                Card card1 = cardsToDraw[0];
                Card card2 = cardsToDraw[1];
                Card card3 = cardsToDraw[2];
                Card card4 = cardsToDraw[3];
                Card card5 = cardsToDraw[4];
            }


            


        }

        private static void OneMoreCard()
        {
            foreach (var card in cards)
            {
                if (card.isGived == false)
                {
                    playerCards.Add(card);
                    break;
                }
            }
            

        }
        private void Enough()
        {
            Console.WriteLine("Enough");
        }


       
    }

    public class Card
    {
        public string suit { get; }
        public string sign { get; }
        public bool isGived { get; set; }
        public bool isClosed { get; set; }
        public Card(string suit, string sign) { this.sign = sign; this.suit = suit; isGived = false; isClosed = false; }
    }
}

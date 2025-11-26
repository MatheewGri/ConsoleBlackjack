using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Runtime.CompilerServices;
using ConsoleCardGame.Entities;

namespace ConsoleCardGame
{
    internal class Menu
    {
        public int typeId;
        private string[] menuItems = {  };
        public int actualItem = 0;
        public bool exit = false;
        public bool run = false;
        public bool isPlayed = false;
        public bool isStarted = false;
        public int money = 10000;
        public int debt = 0;
        Deck deck = new Deck();
        Player player = new Player();
        Diler diler = new Diler();
        Table table = new Table();

        

        List<ConsoleKey> numberKeys = new List<ConsoleKey> { ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5, ConsoleKey.D6, ConsoleKey.D7, ConsoleKey.D8, ConsoleKey.D9, ConsoleKey.D0 };

        ConsoleKeyInfo pressedButton;

        public Menu(int typeId) { this.typeId = typeId; }

        public void InitializeMenu(int typeId, int item)
        {
            if (typeId == 0)
            {
                menuItems = ["Начать",
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
                    Console.Clear();
                    StartGame();
                    actualItem = 0;
                    typeId = 1;
                    InitializeMenu(1, 0);
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
                    Console.Clear();
                    deck.GiveCard(player.playerCards);
                    player.CardsOnTable();
                    table.DrawDilerCards();
                    table.DrawPlayerCards();
                    if (player.Check21())
                    {
                        Console.WriteLine("Перебор!");
                        player.playerCards.Clear();
                        player.CardsOnTable();
                        diler.dilerCards.Clear();
                        diler.CardsOnTable();
                        actualItem = 0;
                        typeId = 0;
                        InitializeMenu(0, 0);
                        return;
                    }
                    typeId = 1;
                    InitializeMenu(1, 0);

                    return;
                }
                if (actualItem == 1)
                {
                    
                }
                if (actualItem == 2)
                {
                    exit = true;
                    return;
                }
            }


        }

        public void StartGame()
        {
            deck.CreateCards();
            deck.SwitchCards();
            Console.WriteLine("$$$ Введите ставку $$$");
            debt = int.Parse(Console.ReadLine());
            deck.GiveCard(player.playerCards);
            deck.GiveCard(diler.dilerCards);
            diler.dilerCards[0].isClosed = true;
            deck.GiveCard(player.playerCards);
            deck.GiveCard(diler.dilerCards);
            player.CardsOnTable();
            diler.CardsOnTable();
            table.DrawDilerCards();
            table.DrawPlayerCards();
            isStarted = true;


        }

        

        

        

     





       
    }

    
}

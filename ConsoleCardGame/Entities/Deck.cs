using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCardGame.Entities;

namespace ConsoleCardGame.Entities
{
    public class Deck
    {
        public List<Card> cards = new List<Card>();
        public static List<string> suits = new List<string> { "♥", "♦", "♣", "♠" };
        public static List<string> signs = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        public void CreateCards()
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

        public void SwitchCards()
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

        public void GiveCard(List<Card> personDeck)
        {
            cards[0].isGived = true;
            personDeck.Add(cards[0]);
            cards.RemoveAt(0);
        }

        public void GiveCardsBackinDeck(List<Card> personDeck)
        {
            foreach (Card card in personDeck)
            {
                cards.Add(card);
            }
            personDeck.Clear();
        }
    }


}

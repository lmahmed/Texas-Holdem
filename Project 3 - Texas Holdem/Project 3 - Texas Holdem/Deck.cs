using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_3___Texas_Holdem
{
    public class Deck
    {

        private List<Card> deck;

        public int size => deck.Count;

        public Deck()
        {
            deck = new List<Card>();
            for (int suitIndex = 1; suitIndex <= 4; suitIndex++)
            {
                for (int rankIndex = 2; rankIndex <= 14; rankIndex++)
                {
                    deck.Add(new Card(suitIndex, rankIndex));
                }
            }
            shuffle();
        }

        public void shuffle()
        {
            Random random = new Random();
            
            List<Card> tempDeck = new List<Card>();
            while (deck.Count > 0)
            {
                Card card = deck[random.Next(deck.Count)];
                deck.Remove(card);
                tempDeck.Add(card);
            }
            deck = tempDeck;
        }

        public Card draw()
        {
            Card card = deck[deck.Count-1];
            deck.Remove(card);
            return card;
        }
    }
}

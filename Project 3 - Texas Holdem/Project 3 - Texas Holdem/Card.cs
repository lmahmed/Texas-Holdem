using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Project_3___Texas_Holdem
{
    public enum Rank
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }

    public enum Suit
    {
        Clubs = 1,
        Diamonds = 2,
        Hearts = 3,
        Spades = 4
    }

    
    public class Card
    {
        public Suit Suit { get; }
        public Rank Rank { get; }
        
        public Card(int suit, int rank)
        {
            this.Suit = (Suit)suit;
            this.Rank = (Rank)rank;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }


    }
}

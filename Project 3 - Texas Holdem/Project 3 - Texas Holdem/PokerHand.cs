using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3___Texas_Holdem
{
    public enum HandRank
    {
        HighCard = 1,
        Pair = 2,
        TwoPair = 3,
        ThreeOfAKind = 4,
        Straight = 5,
        Flush = 6,
        FullHouse = 7,
        FourOfAKind = 8,
        StraightFlush = 9
    }
    public class PokerHand : IComparable<PokerHand>
    {
        public List<Card> FiveHand { get; }
        public HandRank HandRank { get; }

        public PokerHand(List<Card> fiveHand, HandRank handRank) 
        {
            FiveHand = fiveHand;
            HandRank = handRank;
        }

        public int CompareTo(PokerHand? other)
        {
            if (other == null) return 1;

            if ((int)HandRank > (int)other.HandRank )
            {
                return 1;
            }
            else if ((int)HandRank < (int)other.HandRank)
            {
                return -1;
            }    
            else
            {
                for (int index = FiveHand.Count-1; index >= 0; index--)
                {
                    if ((int)FiveHand[index].Rank > (int)other.FiveHand[index].Rank)
                    {
                        return 1;
                    }
                    else if ((int)FiveHand[index].Rank < (int)other.FiveHand[index].Rank)
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }
    }
}

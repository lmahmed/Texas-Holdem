using Project_3___Texas_Holdem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 

namespace Project_3___Texas_Holdem
{
    

    public class HoldemHand : IComparable<HoldemHand>
    {

        bool twoPairExists(params int[] rankCount)
        {
            int countOfPair = 0;
            foreach (int count in rankCount) 
            {
                if (count == 2)
                {
                    countOfPair++;
                }    
            }
            return countOfPair == 2;
        }

        void getCombinations(List<Card> Cards, int k, List<List<Card>> list)
        {
            List<Card> temp = new List<Card>() { Cards[0], Cards[1], Cards[2], Cards[3], Cards[4] };

            combinationUtil(Cards, Cards.Count, k, 0, temp, 0,  list);

        }

        // https://www.geeksforgeeks.org/print-all-possible-combinations-of-r-elements-in-a-given-array-of-size-n/, changed for adding to list
        void combinationUtil(List<Card> Cards, int n,
                               int r, int index,
                               List<Card> data, int i, List<List<Card>> list)
        {
            // Current combination is ready
            // to be printed, print it
            if (index == r)
            {
                list.Add(new List<Card>(data));
                return;
            }

            // When no more elements are
            // there to put in data[]
            if (i >= n)
                return;

            // current is included, put
            // next at next location
            data[index] = Cards[i];
            combinationUtil(Cards, n, r,
                            index + 1, data, i + 1,  list);

            // current is excluded, replace
            // it with next (Note that
            // i+1 is passed, but index
            // is not changed)
            combinationUtil(Cards, n, r, index,
                            data, i + 1,  list);
        }

        public List <Card> CardList { get; }

        public HoldemHand(Card cardOne, Card cardTwo)
        {
            CardList = new List<Card> { cardOne, cardTwo };
        }

        public void Add(Card card) 
        {
            CardList.Add(card);
        }

        private PokerHand getBestPossiblePokerHand()
        {
            PokerHand bestHand = null;
            List<List<Card>> cardCombinations = new List<List<Card>>();

            // list is sorted
            CardList.Sort((x, y) => ((int)x.Rank).CompareTo((int)y.Rank));


            // lists in list are sorted from two, three, four, ..., to ace
            getCombinations(CardList, 5, cardCombinations);

            for (int index = 0; index < cardCombinations.Count; index++)
            {
                List <Card> currHand = cardCombinations[index];

                int cAce = currHand.Where(c => c.Rank == Rank.Ace).Count();
                int cTwo = currHand.Where(c => c.Rank == Rank.Two).Count();
                int cThree = currHand.Where(c => c.Rank == Rank.Three).Count();
                int cFour = currHand.Where(c => c.Rank == Rank.Four).Count();
                int cFive = currHand.Where(c => c.Rank == Rank.Five).Count();
                int cSix = currHand.Where(c => c.Rank == Rank.Six).Count();
                int cSeven = currHand.Where(c => c.Rank == Rank.Seven).Count();
                int cEight = currHand.Where(c => c.Rank == Rank.Eight).Count();
                int cNine = currHand.Where(c => c.Rank == Rank.Nine).Count();
                int cTen = currHand.Where(c => c.Rank == Rank.Ten).Count();
                int cJack = currHand.Where(c => c.Rank == Rank.Jack).Count();
                int cQueen = currHand.Where(c => c.Rank == Rank.Queen).Count();
                int cKing = currHand.Where(c => c.Rank == Rank.King).Count();

                bool isStraight;
                bool isFlush;

                if ((cAce == 1 && cTwo == 1 && cThree == 1 && cFour == 1 && cFive == 1) ||
                    (cTwo == 1 && cThree == 1 && cFour == 1 && cFive == 1 && cSix == 1) ||
                    (cThree == 1 && cFour == 1 && cFive == 1 && cSix == 1 && cSeven == 1) ||
                    (cFour == 1 && cFive == 1 && cSix == 1 && cSeven == 1 && cEight == 1) ||
                    (cFive == 1 && cSix == 1 && cSeven == 1 && cEight == 1 && cNine == 1) ||
                    (cSix == 1 && cSeven == 1 && cEight == 1 && cNine == 1 && cTen == 1) ||
                    (cSeven == 1 && cEight == 1 && cNine == 1 && cTen == 1 && cJack == 1) ||
                    (cEight == 1 && cNine == 1 && cTen == 1 && cJack == 1 && cQueen == 1) ||
                    (cNine == 1 && cTen == 1 && cJack == 1 && cQueen == 1 && cKing == 1) ||
                    (cTen == 1 && cJack == 1 && cQueen == 1 && cKing == 1 && cAce == 1))
                {
                    isStraight = true;
                }
                else
                {
                    isStraight = false;
                }

                if ((currHand[0].Suit == currHand[1].Suit) &&
                     (currHand[1].Suit == currHand[2].Suit) &&
                     (currHand[2].Suit == currHand[3].Suit) &&
                     (currHand[3].Suit == currHand[4].Suit))
                {
                    isFlush = true;
                }
                else
                {
                    isFlush = false;
                }

                PokerHand tempHand = null;
                // straight flush
                if (isStraight && isFlush)
                {
                    // list is currently two,three,four,five,ace which would be incorrectly rated higher than all other straights except royal flush
                    if (cAce == 1 && cTwo == 1 && cThree == 1 && cFour == 1 && cFive == 1)
                    {
                        Card cardTemp = currHand[4];
                        currHand.RemoveAt(4);
                        currHand.Insert(0, cardTemp);
                        // list is now ace, two, three, four, five
                    }
                    tempHand = new PokerHand(currHand, HandRank.StraightFlush);
                }
                // four of a kind
                else if ((cAce == 4) || (cTwo == 4) || (cThree == 4) || (cFour == 4) || (cFive == 4) || (cSix == 4) || 
                         (cSeven == 4) || (cEight == 4) || (cNine == 4) || (cTen == 4) || (cJack == 4) || (cQueen == 4) || (cKing == 4) )
                {
                    // move fifth card to front of list if not part of four of a kind 
                    if (currHand[0].Rank == currHand[1].Rank)
                    {
                        Card cardTemp = currHand[4];
                        currHand.RemoveAt(4);
                        currHand.Insert(0, cardTemp);
                    }    

                    tempHand = new PokerHand(currHand, HandRank.FourOfAKind);
                }
                // full house
                else if (((cAce == 3) || (cTwo == 3) || (cThree == 3) || (cFour == 3) || (cFive == 3) || (cSix == 3) ||
                         (cSeven == 3) || (cEight == 3) || (cNine == 3) || (cTen == 3) || (cJack == 3) || (cQueen == 3) || (cKing == 3)) &&
                         ((cAce == 2) || (cTwo == 2) || (cThree == 2) || (cFour == 2) || (cFive == 2) || (cSix == 2) ||
                         (cSeven == 2) || (cEight == 2) || (cNine == 2) || (cTen == 2) || (cJack == 2) || (cQueen == 2) || (cKing == 2)))
                {
                    // move pair to front of list
                    if (currHand[0].Rank == currHand[2].Rank)
                    {
                        Card cardTemp = currHand[4];
                        currHand.RemoveAt(4);
                        currHand.Insert(0, cardTemp);
                        cardTemp = currHand[4];
                        currHand.RemoveAt(4);
                        currHand.Insert(0, cardTemp);
                    }
                    tempHand = new PokerHand(currHand, HandRank.FullHouse);
                }
                // flush
                else if (isFlush)
                {
                    tempHand = new PokerHand(currHand, HandRank.Flush);
                }
                // straight
                else if (isStraight)
                {
                    // list is currently two,three,four,five,ace which would be incorrectly rated higher than all other straights except ace high straight
                    if (cAce == 1 && cTwo == 1 && cThree == 1 && cFour == 1 && cFive == 1)
                    {
                        Card cardTemp = currHand[4];
                        currHand.RemoveAt(4);
                        currHand.Insert(0, cardTemp);
                        // list is now ace, two, three, four, five
                    }
                    tempHand = new PokerHand(currHand, HandRank.Straight);
                }
                // three of a kind
                else if ((cAce == 3) || (cTwo == 3) || (cThree == 3) || (cFour == 3) || (cFive == 3) || (cSix == 3) ||
                         (cSeven == 3) || (cEight == 3) || (cNine == 3) || (cTen == 3) || (cJack == 3) || (cQueen == 3) || (cKing == 3))
                {
                    // move 2 back cards to front, so 3 3 3 4 7 becomes 4 7 3 3 3
                    if (currHand[0].Rank == currHand[2].Rank)
                    {
                        Card cardTemp = currHand[4];
                        currHand.RemoveAt(4);
                        currHand.Insert(0, cardTemp);
                        cardTemp = currHand[4];
                        currHand.RemoveAt(4);
                        currHand.Insert(0, cardTemp);
                    }
                    // move back last card to first index, so 3 4 4 4 5 becomes 3 5 4 4 4
                    else if (currHand[1].Rank == currHand[3].Rank)
                    {
                        Card cardTemp = currHand[4];
                        currHand.RemoveAt(4);
                        currHand.Insert(1 ,cardTemp);
                    }
                    tempHand = new PokerHand(currHand, HandRank.ThreeOfAKind);
                }
                // two pairs
                else if (twoPairExists(cAce,cTwo,cThree,cFour,cFive,cSix,cSeven,cEight,cNine,cTen,cJack,cQueen,cKing))
                {
                    // pair in front needs to move towards back
                    if (currHand[0].Rank == currHand[1].Rank)
                    {
                        // second pair needs to move also. Move last card to front
                        if (currHand[2].Rank == currHand[3].Rank)
                        {
                            Card cardTemp = currHand[4];
                            currHand.RemoveAt(4);
                            currHand.Insert(0, cardTemp);
                        }
                        else
                        // Move middle card to front. 3 3 4 5 5 becomes 4 3 3 5 5
                        {
                            Card cardTemp = currHand[2];
                            currHand.RemoveAt(2);
                            currHand.Insert(0, cardTemp);
                        }
                    }

                    tempHand = new PokerHand(currHand, HandRank.TwoPair);
                }
                // pair
                else if((cAce == 2) || (cTwo == 2) || (cThree == 2) || (cFour == 2) || (cFive == 2) || (cSix == 2) ||
                         (cSeven == 2) || (cEight == 2) || (cNine == 2) || (cTen == 2) || (cJack == 2) || (cQueen == 2) || (cKing == 2))
                {
                    // move pair cards to back depending on where they are located
                    // 2 2 3 4 5 becomes 3 4 5 2 2
                    if (currHand[0].Rank == currHand[1].Rank)
                    {
                        Card cardTemp = currHand[0];
                        currHand.RemoveAt(0);
                        currHand.Add(cardTemp);
                        cardTemp = currHand[0];
                        currHand.RemoveAt(0);
                        currHand.Add(cardTemp);
                    }
                    // 2 3 3 4 5 becomes 2 4 5 3 3
                    else if (currHand[1].Rank == currHand[2].Rank)
                    {
                        Card cardTemp = currHand[1];
                        currHand.RemoveAt(1);
                        currHand.Add(cardTemp);
                        cardTemp = currHand[1];
                        currHand.RemoveAt(1);
                        currHand.Add(cardTemp);
                    }
                    // 2 3 4 4 5 becomes 2 3 5 4 4
                    else if (currHand[2].Rank == currHand[3].Rank)
                    {
                        Card cardTemp = currHand[2];
                        currHand.RemoveAt(2);
                        currHand.Add(cardTemp);
                        cardTemp = currHand[2];
                        currHand.RemoveAt(2);
                        currHand.Add(cardTemp);
                    }
                    tempHand = new PokerHand(currHand, HandRank.Pair);
                }
                // high card
                else
                {
                    tempHand = new PokerHand(currHand, HandRank.HighCard);
                }

                if (tempHand.CompareTo(bestHand) > 0)
                {
                    bestHand = tempHand;
                }
            }

            return bestHand;
        }

        public int CompareTo(HoldemHand? other)
        {
            return getBestPossiblePokerHand().CompareTo(other.getBestPossiblePokerHand());
        }
    }
}

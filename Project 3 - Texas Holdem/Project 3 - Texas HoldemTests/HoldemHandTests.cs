using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_3___Texas_Holdem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3___Texas_Holdem.Tests
{
    [TestClass()]
    public class HoldemHandTests
    {
        [TestMethod()]
        public void HoldemHandTest()
        {
            HoldemHand playerOne = new HoldemHand(new Card((int)Suit.Hearts , (int)Rank.Ace), new Card( (int)Suit.Hearts, (int)Rank.Queen));
            HoldemHand playerTwo = new HoldemHand(new Card( (int)Suit.Spades, (int)Rank.Ace), new Card( (int)Suit.Spades, (int)Rank.Eight));
            List <HoldemHand> holdemHandList = new List<HoldemHand> { playerOne, playerTwo};
            foreach (HoldemHand holdemHand in holdemHandList) 
            {
                holdemHand.Add(new Card( (int)Suit.Diamonds, (int)Rank.King));
                holdemHand.Add(new Card( (int)Suit.Hearts, (int)Rank.Ten));
                holdemHand.Add(new Card((int)Suit.Hearts, (int)Rank.King));
                holdemHand.Add(new Card( (int)Suit.Hearts, (int)Rank.Jack));
                holdemHand.Add(new Card((int)Suit.Diamonds, (int)Rank.Six));
            }
            playerOne.CompareTo(playerTwo);

            Assert.Fail();
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CompareToTest()
        {
            Assert.Fail();
        }
    }
}
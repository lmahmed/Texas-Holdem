using Project_3___Texas_Holdem.Properties;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Project_3___Texas_Holdem
{
    public partial class Form1 : Form
    {
        Dictionary< (Rank,Suit), Image> CardImage;
        private Deck PokerDeck;

        private HoldemHand PlayerOne;
        private HoldemHand PlayerTwo;
        private int PlayerOneMoney;
        private int PlayerTwoMoney;

        const int TOTAL_ROUNDS = 4;
        int CurrentRound;
        int CurrentPlayer;

        int PotMoney;

        int CallAmount;
        public Form1()
        {
            InitializeComponent();
            CardImage = new Dictionary<(Rank, Suit), Image>();
            addDictionary(CardImage);

            PokerDeck = new Deck();

            PlayerOne = new HoldemHand(PokerDeck.draw(), PokerDeck.draw());
            PlayerTwo = new HoldemHand(PokerDeck.draw(), PokerDeck.draw());

            PlayerOneCardOne.Image = CardImage[(PlayerOne.CardList[0].Rank, PlayerOne.CardList[0].Suit)];
            PlayerOneCardTwo.Image = CardImage[(PlayerOne.CardList[1].Rank, PlayerOne.CardList[1].Suit)];

            PlayerTwoCardOne.Image = CardImage[(PlayerTwo.CardList[0].Rank, PlayerTwo.CardList[0].Suit)];
            PlayerTwoCardTwo.Image = CardImage[(PlayerTwo.CardList[1].Rank, PlayerTwo.CardList[1].Suit)];

            CurrentRound = 1;
            CurrentPlayer = 1;

            PotMoney = 0;
            PotMoneyLabel.Text = PotMoney.ToString();

            PlayerOneMoney = 100;
            Player1MoneyLabel.Text = PlayerOneMoney.ToString();
            PlayerTwoMoney = 100;
            Player2MoneyLabel.Text = PlayerTwoMoney.ToString();

            CallAmount = 0;
        }

        private void addDictionary(Dictionary <(Rank,Suit),Image> dictionary)
        {
            dictionary.Add((Rank.Ace, Suit.Clubs), Resources.ace_of_clubs);
            dictionary.Add((Rank.Ace, Suit.Diamonds), Resources.ace_of_diamonds);
            dictionary.Add((Rank.Ace, Suit.Hearts), Resources.ace_of_hearts);
            dictionary.Add((Rank.Ace, Suit.Spades), Resources.ace_of_spades);

            dictionary.Add((Rank.Two, Suit.Clubs), Resources._2_of_clubs);
            dictionary.Add((Rank.Two, Suit.Diamonds), Resources._2_of_diamonds);
            dictionary.Add((Rank.Two, Suit.Hearts), Resources._2_of_hearts);
            dictionary.Add((Rank.Two, Suit.Spades), Resources._2_of_spades);

            dictionary.Add((Rank.Three, Suit.Clubs), Resources._3_of_clubs);
            dictionary.Add((Rank.Three, Suit.Diamonds), Resources._3_of_diamonds);
            dictionary.Add((Rank.Three, Suit.Hearts), Resources._3_of_hearts);
            dictionary.Add((Rank.Three, Suit.Spades), Resources._3_of_spades);

            dictionary.Add((Rank.Four, Suit.Clubs), Resources._4_of_clubs);
            dictionary.Add((Rank.Four, Suit.Diamonds), Resources._4_of_diamonds);
            dictionary.Add((Rank.Four, Suit.Hearts), Resources._4_of_hearts);
            dictionary.Add((Rank.Four, Suit.Spades), Resources._4_of_spades);

            dictionary.Add((Rank.Five, Suit.Clubs), Resources._5_of_clubs);
            dictionary.Add((Rank.Five, Suit.Diamonds), Resources._5_of_diamonds);
            dictionary.Add((Rank.Five, Suit.Hearts), Resources._5_of_hearts);
            dictionary.Add((Rank.Five, Suit.Spades), Resources._5_of_spades);

            dictionary.Add((Rank.Six, Suit.Clubs), Resources._6_of_clubs);
            dictionary.Add((Rank.Six, Suit.Diamonds), Resources._6_of_diamonds);
            dictionary.Add((Rank.Six, Suit.Hearts), Resources._6_of_hearts);
            dictionary.Add((Rank.Six, Suit.Spades), Resources._6_of_spades);

            dictionary.Add((Rank.Seven, Suit.Clubs), Resources._7_of_clubs);
            dictionary.Add((Rank.Seven, Suit.Diamonds), Resources._7_of_diamonds);
            dictionary.Add((Rank.Seven, Suit.Hearts), Resources._7_of_hearts);
            dictionary.Add((Rank.Seven, Suit.Spades), Resources._7_of_spades);

            dictionary.Add((Rank.Eight, Suit.Clubs), Resources._8_of_clubs);
            dictionary.Add((Rank.Eight, Suit.Diamonds), Resources._8_of_diamonds);
            dictionary.Add((Rank.Eight, Suit.Hearts), Resources._8_of_hearts);
            dictionary.Add((Rank.Eight, Suit.Spades), Resources._8_of_spades);

            dictionary.Add((Rank.Nine, Suit.Clubs), Resources._9_of_clubs);
            dictionary.Add((Rank.Nine, Suit.Diamonds), Resources._9_of_diamonds);
            dictionary.Add((Rank.Nine, Suit.Hearts), Resources._9_of_hearts);
            dictionary.Add((Rank.Nine, Suit.Spades), Resources._9_of_spades);

            dictionary.Add((Rank.Ten, Suit.Clubs), Resources._10_of_clubs);
            dictionary.Add((Rank.Ten, Suit.Diamonds), Resources._10_of_diamonds);
            dictionary.Add((Rank.Ten, Suit.Hearts), Resources._10_of_hearts);
            dictionary.Add((Rank.Ten, Suit.Spades), Resources._10_of_spades);

            dictionary.Add((Rank.Jack, Suit.Clubs), Resources.jack_of_clubs2);
            dictionary.Add((Rank.Jack, Suit.Diamonds), Resources.jack_of_diamonds2);
            dictionary.Add((Rank.Jack, Suit.Hearts), Resources.jack_of_hearts2);
            dictionary.Add((Rank.Jack, Suit.Spades), Resources.jack_of_spades2);

            dictionary.Add((Rank.Queen, Suit.Clubs), Resources.queen_of_clubs2);
            dictionary.Add((Rank.Queen, Suit.Diamonds), Resources.queen_of_diamonds2);
            dictionary.Add((Rank.Queen, Suit.Hearts), Resources.queen_of_hearts2);
            dictionary.Add((Rank.Queen, Suit.Spades), Resources.queen_of_spades2);

            dictionary.Add((Rank.King, Suit.Clubs), Resources.king_of_clubs2);
            dictionary.Add((Rank.King, Suit.Diamonds), Resources.king_of_diamonds2);
            dictionary.Add((Rank.King, Suit.Hearts), Resources.king_of_hearts2);
            dictionary.Add((Rank.King, Suit.Spades), Resources.king_of_spades2);
        }

        private void nextCallOrFold()
        {
            if (CurrentPlayer == 1)
            {
                CurrentPlayer = 2;

                Player1Bet.Text = string.Empty;
                Player1BetOrCheckPanel.Visible = false;
                Player2CallOrFoldPanel.Visible = true;
            }
            else if (CurrentPlayer == 2)
            {
                CurrentPlayer = 1;

                Player2Bet.Text = string.Empty;
                Player2BetOrCheckPanel.Visible = false;
                Player1CallOrFoldPanel.Visible = true;
            }
        }

        private void nextRound()
        {
            Panel callOrFoldTemp;
            Panel betOrCheckTemp;
            if (CurrentPlayer == 1)
            {
                callOrFoldTemp = Player1CallOrFoldPanel;
                betOrCheckTemp = Player1BetOrCheckPanel;
            }
            else
            {
                callOrFoldTemp = Player2CallOrFoldPanel;
                betOrCheckTemp = Player2BetOrCheckPanel;
            }
            if (CurrentRound == 1) 
            {
                Card flop1 = PokerDeck.draw();
                Card flop2 = PokerDeck.draw();
                Card flop3 = PokerDeck.draw();
                FlopCardOne.Image = CardImage[(flop1.Rank, flop1.Suit)];
                FlopCardTwo.Image = CardImage[(flop2.Rank, flop2.Suit)];
                FlopCardThree.Image = CardImage[(flop3.Rank, flop3.Suit)];
                PlayerOne.Add(flop1);
                PlayerOne.Add(flop2);
                PlayerOne.Add(flop3);
                PlayerTwo.Add(flop1);
                PlayerTwo.Add(flop2);
                PlayerTwo.Add(flop3);

                callOrFoldTemp.Visible = false;
                betOrCheckTemp.Visible = true;

            }
            else if (CurrentRound == 2)
            {
                Card turn = PokerDeck.draw();
                TurnCard.Image = CardImage[(turn.Rank, turn.Suit)];
                PlayerOne.Add(turn);
                PlayerTwo.Add(turn);

                callOrFoldTemp.Visible = false;
                betOrCheckTemp.Visible = true;
            }
            else if (CurrentRound == 3)
            {
                Card river = PokerDeck.draw();
                RiverCard.Image = CardImage[(river.Rank, river.Suit)];
                PlayerOne.Add(river);
                PlayerTwo.Add(river);

                callOrFoldTemp.Visible = false;
                betOrCheckTemp.Visible = true;
            }
            else if (CurrentRound == TOTAL_ROUNDS)
            {
                int temp = PlayerOne.CompareTo(PlayerTwo);
                if (temp > 0)
                {
                    Player1Winner.Visible = true;
                    PlayerOneMoney += PotMoney;
                    Player1MoneyLabel.Text = PlayerOneMoney.ToString();
                }
                else if (temp < 0)
                {
                    Player2Winner.Visible = true;
                    PlayerTwoMoney += PotMoney;
                    Player2MoneyLabel.Text = PlayerTwoMoney.ToString();
                }
                else
                {
                    Player1Winner.Visible = true;
                    Player2Winner.Visible = true;
                    PlayerOneMoney += (PotMoney / 2);
                    PlayerTwoMoney += (PotMoney / 2);
                    Player1MoneyLabel.Text = PlayerOneMoney.ToString();
                    Player2MoneyLabel.Text = PlayerTwoMoney.ToString();
                }

                PotMoney = 0;
                PotMoneyLabel.Text = PotMoney.ToString();

                callOrFoldTemp.Visible = false;

                // new game
                PlayAgainButton.Visible = true;
            }
            CurrentRound++;

        }
            
            
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Player1BetButton_Click(object sender, EventArgs e)
        {
            int playerOneBet;
            if (int.TryParse(Player1Bet.Text, out playerOneBet))
            {
                if (playerOneBet <= PlayerOneMoney)
                {
                    PlayerOneMoney -= playerOneBet;
                    Player1MoneyLabel.Text = PlayerOneMoney.ToString();
                    PotMoney += playerOneBet;
                    PotMoneyLabel.Text = PotMoney.ToString();
                    CallAmount = playerOneBet;

                    nextCallOrFold();
                }
                else
                {
                    Player1Bet.Text = "Invalid";
                }    
            }
            else
            {
                Player1Bet.Text = "Invalid";
            }
        }

        private void Player2BetButton_Click(object sender, EventArgs e)
        {
            int playerTwoBet;
            if (int.TryParse(Player2Bet.Text, out playerTwoBet))
            {
                if (playerTwoBet <= PlayerTwoMoney)
                {
                    PlayerTwoMoney -= playerTwoBet;
                    Player2MoneyLabel.Text = PlayerTwoMoney.ToString();
                    PotMoney += playerTwoBet;
                    PotMoneyLabel.Text = PotMoney.ToString();
                    CallAmount = playerTwoBet;

                    nextCallOrFold();
                }
                else
                {
                    Player2Bet.Text = "Invalid";
                }
            }
            else
            {
                Player2Bet.Text = "Invalid";
            }
        }

        private void Player1CallButton_Click(object sender, EventArgs e)
        {
            PlayerOneMoney -= CallAmount;
            Player1MoneyLabel.Text = PlayerOneMoney.ToString();
            PotMoney += CallAmount;
            PotMoneyLabel.Text = PotMoney.ToString();

            nextRound();
        }

        private void Player2CallButton_Click(object sender, EventArgs e)
        {
            PlayerTwoMoney -= CallAmount;
            Player2MoneyLabel.Text = PlayerTwoMoney.ToString();
            PotMoney += CallAmount;
            PotMoneyLabel.Text = PotMoney.ToString();

            nextRound();
        }

        private void Player1CheckButton_Click(object sender, EventArgs e)
        {
            Player1Bet.Text = "0";
            Player1BetButton_Click(sender, e);
            Player2CallButton_Click(sender, e);
        }

        private void Player2CheckButton_Click(object sender, EventArgs e)
        {
            Player2Bet.Text = "0";
            Player2BetButton_Click(sender, e);
            Player1CallButton_Click(sender, e);
        }

        private void Player1FoldButton_Click(object sender, EventArgs e)
        {
            Player2Winner.Visible = true;
            PlayerTwoMoney += PotMoney;
            Player2MoneyLabel.Text = PlayerTwoMoney.ToString();
            PotMoney = 0;
            PotMoneyLabel.Text = PotMoney.ToString();

            PlayAgainButton.Visible= true;
        }

        private void Player2FoldButton_Click(object sender, EventArgs e)
        {
            Player1Winner.Visible = true;
            PlayerOneMoney += PotMoney;
            Player1MoneyLabel.Text = PlayerOneMoney.ToString();
            PotMoney = 0;
            PotMoneyLabel.Text = PotMoney.ToString();

            PlayAgainButton.Visible = true;
        }

        private void PlayAgainButton_Click(object sender, EventArgs e)
        {
            PlayAgainButton.Visible = false;
            Player1Winner.Visible = false;
            Player2Winner.Visible = false;

            FlopCardOne.Image = null;
            FlopCardTwo.Image = null;
            FlopCardThree.Image =null;
            TurnCard.Image = null;
            RiverCard.Image = null;

            CurrentRound = 1;
            CurrentPlayer = 1;

            PokerDeck = new Deck();

            PlayerOne = new HoldemHand(PokerDeck.draw(), PokerDeck.draw());
            PlayerTwo = new HoldemHand(PokerDeck.draw(), PokerDeck.draw());

            PlayerOneCardOne.Image = CardImage[(PlayerOne.CardList[0].Rank, PlayerOne.CardList[0].Suit)];
            PlayerOneCardTwo.Image = CardImage[(PlayerOne.CardList[1].Rank, PlayerOne.CardList[1].Suit)];

            PlayerTwoCardOne.Image = CardImage[(PlayerTwo.CardList[0].Rank, PlayerTwo.CardList[0].Suit)];
            PlayerTwoCardTwo.Image = CardImage[(PlayerTwo.CardList[1].Rank, PlayerTwo.CardList[1].Suit)];


            Player1BetOrCheckPanel.Visible = true;
        }
    }
}
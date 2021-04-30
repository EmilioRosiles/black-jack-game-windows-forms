using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace GreenvilleRevenueGUI
{
    public partial class Form1 : Form
    {
        Deck deckOfCards = new Deck();
        Hand playerHand;
        Hand dealerHand;
        bool gameOver = false;
        Funds myfunds = new Funds(500);
        public Form1()
        {
            InitializeComponent();
            CleanTheTable();
            deckOfCards.ShuffleDeck();
            button1.Size = new Size(200, 150);
            button7.Size = new Size(200, 150);
            button8.Size = new Size(200, 150);
            gameOver = true;
            numericUpDown1.Increment = 10;
            numericUpDown1.Minimum = 10;
            numericUpDown1.Maximum = myfunds.getfunds();
            label12.Text = "Total Funds: " + myfunds.getfunds();
        }
        // New Game 
        private void Button1_Click(object sender, EventArgs e)
        {
            startGame();
        }
        public void startGame()
        {
            gameOver = false;
            CleanTheTable();
            playerHand = new Hand("Emilio");
            dealerHand = new Hand("Dealer");

            playerHand.GetACard(deckOfCards.DealACard());
            dealerHand.GetACard(deckOfCards.DealACard());
            playerHand.GetACard(deckOfCards.DealACard());
            dealerHand.GetACard(deckOfCards.DealACard());

            button2.Image = dealerHand.returnXCard(0).GetCardImage();
            button9.Image = playerHand.returnXCard(0).GetCardImage();
            button10.Image = playerHand.returnXCard(1).GetCardImage();

            label1.Text = dealerHand.returnXCard(0).GetCardValue().ToString();
            label2.Text = "???";
            label7.Text = playerHand.returnXCard(0).GetCardValue().ToString();
            label8.Text = playerHand.returnXCard(1).GetCardValue().ToString();
            label13.Text = dealerHand.returnXCard(0).GetCardValue() + "";
            label14.Text = playerHand.getHandlValue() + "";
            
        }
        //hit 
        private void Button7_Click(object sender, EventArgs e)
        {
            cheKForBlackJack();
            if (!gameOver)
            {
                playerHand.GetACard(deckOfCards.DealACard());
                UpdatePlayerHand();
                label13.Text = dealerHand.returnXCard(0).GetCardValue() + "";
                label14.Text = playerHand.getHandlValue() + "";
            }
        }
        //stay
        private void Button8_Click(object sender, EventArgs e)
        {
            cheKForBlackJack();
            if (!gameOver)
            {
                UpdateDealerHand();
                int playerHandValue = playerHand.getHandlValue();
                int dealerHandValue = dealerHand.getHandlValue();
                if (dealerHandValue > 21)
                {
                    DealWithTheDealerAces();
                    dealerHandValue = dealerHand.getHandlValue();
                }
                while (dealerHandValue < 17)
                {
                    dealerHand.GetACard(deckOfCards.DealACard());
                    UpdateDealerHand();
                    DealWithTheDealerAces();
                    dealerHandValue = dealerHand.getHandlValue();
                }
                //logic for the roud results
                if ((playerHandValue > dealerHandValue && playerHandValue <= 21) || (dealerHandValue > 21 && playerHandValue <= 21))
                {
                    MessageBox.Show("You Won!! \n\nDealer: " + dealerHand.getHandlValue() + "\nbPlayer: " + playerHand.getHandlValue());
                    WonBet();
                }
                else if (playerHandValue == dealerHandValue || (playerHandValue > 21 && dealerHandValue > 21))
                {
                    MessageBox.Show("You Tie!! \n\nDealer: " + dealerHand.getHandlValue() + "\nbPlayer: " + playerHand.getHandlValue());

                }
                else if ((playerHandValue < dealerHandValue && dealerHandValue <= 21) || (playerHandValue > 21 && dealerHandValue <= 21))
                {
                    MessageBox.Show("You Lost!! \n\nDealer: "+dealerHand.getHandlValue()+"\nPlayer: "+playerHand.getHandlValue());
                    LostBet();
                }
                gameOver = true;
                label13.Text = dealerHand.getHandlValue() + "";
                label14.Text = playerHand.getHandlValue() + "";
            }
        }

        public void CleanTheTable()
        {
            Image backofcard = Image.FromFile(@"ButtonImages/Wfswbackcard.gif");
            button2.Image = backofcard;
            button3.Image = backofcard;
            button4.Image = backofcard;
            button5.Image = backofcard;
            button6.Image = backofcard;
            button9.Image = backofcard;
            button10.Image = backofcard;
            button11.Image = backofcard;
            button12.Image = backofcard;
            button13.Image = backofcard;
            label1.Text = "-";
            label2.Text = "-";
            label3.Text = "-";
            label4.Text = "-";
            label5.Text = "-";
            label7.Text = "-";
            label8.Text = "-";
            label9.Text = "-";
            label10.Text = "-";
            label11.Text = "-";
            label13.Text = "";
            label14.Text = "";

        }
        private void UpdateDealerHand()
        {

            if (dealerHand.getNumberOfCards() >= 1)
            {
                button2.Image = dealerHand.returnXCard(0).GetCardImage();
                label1.Text = dealerHand.returnXCard(0).GetCardValue().ToString();
            }
            if (dealerHand.getNumberOfCards() >= 2)
            {
                button3.Image = dealerHand.returnXCard(1).GetCardImage();
                label2.Text = dealerHand.returnXCard(1).GetCardValue().ToString();
            }
            if (dealerHand.getNumberOfCards() >= 3)
            {
                button4.Image = dealerHand.returnXCard(2).GetCardImage();
                label3.Text = dealerHand.returnXCard(2).GetCardValue().ToString();
            }
            if (dealerHand.getNumberOfCards() >= 4)
            {
                button5.Image = dealerHand.returnXCard(3).GetCardImage();
                label4.Text = dealerHand.returnXCard(3).GetCardValue().ToString();
            }
            if (dealerHand.getNumberOfCards() == 5)
            {
                button6.Image = dealerHand.returnXCard(4).GetCardImage();
                label5.Text = dealerHand.returnXCard(4).GetCardValue().ToString();
            }

        }
        private void UpdatePlayerHand()
        {
            if (playerHand.getNumberOfCards() >= 1)
            {

                button9.Image = playerHand.returnXCard(0).GetCardImage();
                label7.Text = playerHand.returnXCard(0).GetCardValue().ToString();
            }
            if (playerHand.getNumberOfCards() >= 2)
            {

                button10.Image = playerHand.returnXCard(1).GetCardImage();
                label8.Text = playerHand.returnXCard(1).GetCardValue().ToString();
            }
            if (playerHand.getNumberOfCards() >= 3)
            {

                button11.Image = playerHand.returnXCard(2).GetCardImage();
                label9.Text = playerHand.returnXCard(2).GetCardValue().ToString();
            }
            if (playerHand.getNumberOfCards() >= 4)
            {

                button12.Image = playerHand.returnXCard(3).GetCardImage();
                label10.Text = playerHand.returnXCard(3).GetCardValue().ToString();
            }
            if (playerHand.getNumberOfCards() >= 5)
            {
                button13.Image = playerHand.returnXCard(4).GetCardImage();
                label11.Text = playerHand.returnXCard(4).GetCardValue().ToString();
            }
        }
        private void cheKForBlackJack()
        {
            //game automatically over if blackjack
            if (!gameOver)
            {
                if ((playerHand.getHandlValue() == 21 && playerHand.getNumberOfCards() == 2) || (dealerHand.getHandlValue() == 21 && dealerHand.getNumberOfCards() == 2))
                {
                    UpdateDealerHand();
                    gameOver = true;
                    if (playerHand.getHandlValue() == 21 && playerHand.getNumberOfCards() == 2)
                    {
                        MessageBox.Show("You Won!! You got Black Jack!!");
                        WonBet();
                    }
                    else if (dealerHand.getHandlValue() == 21 && dealerHand.getNumberOfCards() == 2)
                    {
                        MessageBox.Show("You Lost!! Dealer got Black Jack!!");
                        LostBet();
                    }
                    else if ((playerHand.getHandlValue() == 21 && playerHand.getNumberOfCards() == 2) || (dealerHand.getHandlValue() == 21 && dealerHand.getNumberOfCards() == 2))
                    {
                        MessageBox.Show("Is a tie!! Both player got Black Jack");
                    }
                }
            }
        }
        private void DealWithTheDealerAces()
        {
           if(dealerHand.getHandlValue() > 21)
            {
                for(int x = 0; x < dealerHand.getNumberOfCards(); x++)
                {
                    if(dealerHand.returnXCard(x).isAce() && dealerHand.returnXCard(x).GetCardValue() == 11)
                    {
                        dealerHand.returnXCard(x).switchValue();
                        UpdateDealerHand();
                        break;
                    }
                }
            }
        }
        private void Button9_Click(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                if (playerHand.returnXCard(0).isAce())
                {
                    playerHand.returnXCard(0).switchValue();
                }
                label14.Text = playerHand.getHandlValue() + "";
                label7.Text = "" + playerHand.returnXCard(0).GetCardValue();
            }
        }
        private void Button10_Click(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                if (playerHand.returnXCard(1).isAce())
                {
                    playerHand.returnXCard(1).switchValue();
                }
                label14.Text = playerHand.getHandlValue() + "";
                label8.Text = "" + playerHand.returnXCard(1).GetCardValue();
            }
        }
        private void Button11_Click(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                if (playerHand.returnXCard(2).isAce())
                {
                    playerHand.returnXCard(2).switchValue();
                }
                label14.Text = playerHand.getHandlValue() + "";
                label9.Text = "" + playerHand.returnXCard(2).GetCardValue();
            }
        }
        private void Button12_Click(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                if (playerHand.returnXCard(3).isAce())
                {
                    playerHand.returnXCard(3).switchValue();
                }
                label14.Text = playerHand.getHandlValue() + "";
                label10.Text = "" + playerHand.returnXCard(3).GetCardValue();
            }
        }
        private void Button13_Click(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                if (playerHand.returnXCard(4).isAce())
                {
                    playerHand.returnXCard(4).switchValue();
                }
                label14.Text = playerHand.getHandlValue() + "";
                label11.Text = "" + playerHand.returnXCard(4).GetCardValue();
            }
        } 
        private void Button14_Click(object sender, EventArgs e)
        {
            deckOfCards.GetAces();
            startGame();
        }
        private void WonBet()
        {
            label12.Text = "Total Funds: " + myfunds.wonBet();  
        }
        private void LostBet()
        {    
            label12.Text = "Total Funds: " + myfunds.lostBet();
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (gameOver)
            {
                myfunds.changeBet(Convert.ToInt32(numericUpDown1.Value));
            }
            else
            {
                numericUpDown1.Value = myfunds.getBet();
                MessageBox.Show("You can't change the bet in the middle of a game!!");
            }
        }
    }

}


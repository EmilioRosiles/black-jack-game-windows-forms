using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GreenvilleRevenueGUI
{
    class Deck
    {
        private Card[] newDeck = new Card[52];
        Random r = new Random();
        int currentCard = -1;
        public Deck()
        {
            LoadCards();
        }


        private void LoadCards()
        {
            String msg = "";
            int tries = 0;
            try
            { 
            string[] allImages = Directory.GetFiles(@"cards", "*.gif");
            int value;

                for (int index = 0; index < 52; index++)
                {
                    if (index < 32)
                    {
                        value = GetValue(index);
                    }
                    else if (index >= 32 && index <= 35) {
                        value = 11;
                    }
                    else
                    {
                        value = 10;
                    }
                    Image image = Image.FromFile(allImages[index]);
                    newDeck[index] = new Card(value, image);
                    if (value == 11)
                    {
                        newDeck[index].convertToAce();
                    }
                }
            }
            catch (Exception e)
            {
                if (tries < 2)
                {
                    msg = "Error Please make sure the card files in the Directory. \nWhen you put the cards in the Directory hit OK button.\n\n " + e.ToString();
                    MessageBox.Show(msg);
                    tries++;
                    LoadCards();

                }
                else
                {
                    Environment.Exit(1);
                }
            }
            
        }
        private int GetValue(int index)
        {
            int value = (index / 4) + 2;
            return value;
        }
        public Card DealACard()
        {
            if(currentCard < 51)
            {
                
                currentCard++;
            }
            else
            {

                currentCard = 0;
                MessageBox.Show("Dealer is Shuffling the cards ...");
                ShuffleDeck();
            }
            return newDeck[currentCard];
        }
        public void ShuffleDeck()
        {
            
            Card card1;
            Card card2;
            
            for(int x = 0; x < r.Next(100, 200); x++)
            {
                int r1 = r.Next(0, 52);
                int r2 = r.Next(0, 52);
                card1 = newDeck[r1];
                card2 = newDeck[r2];
                newDeck[r1] = card2;
                newDeck[r2] = card1;
            }
            
        }
        public void GetAces()
        {
            //give aces to both players and put jack on 5th position for testing purposes
            currentCard = -1;
            LoadCards();
            Card stAce = newDeck[32];
            Card ndAce = newDeck[33];
            Card rdAce = newDeck[34];
            Card thAce = newDeck[35];
            Card Jack = newDeck[36];

            newDeck[32] = newDeck[0];
            newDeck[33] = newDeck[1];
            newDeck[34] = newDeck[2];
            newDeck[35] = newDeck[3];
            newDeck[36] = newDeck[4];

            newDeck[0] = stAce;
            newDeck[1] = ndAce;
            newDeck[2] = rdAce;
            newDeck[3] = thAce;
            newDeck[4] = Jack;

            //shuffle all cards exept aces and jack
            Card card1;
            Card card2;
            for (int x = 0; x < r.Next(100, 200); x++)
            {
                int r1 = r.Next(5, 52);
                int r2 = r.Next(5, 52);
                card1 = newDeck[r1];
                card2 = newDeck[r2];
                newDeck[r1] = card2;
                newDeck[r2] = card1;
            }
        }
    }
}

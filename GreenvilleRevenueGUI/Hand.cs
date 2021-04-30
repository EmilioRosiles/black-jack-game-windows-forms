using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenvilleRevenueGUI
{
    class Hand
    {
        String Name;
        Card[] myCards = new Card[5];
        int numberOfCards = 0;
        public Hand(String Name)
        {
            this.Name = Name;
        }
        public void GetACard(Card ACard)
        {
            if(numberOfCards < 5)
            {
                myCards[numberOfCards] = ACard;
                numberOfCards++;
            }
        }
        public int getHandlValue()
        {
            int totalValue = 0;
            for(int x = 0; x < 5; x++)
            {
                if (myCards[x] != null)
                {
                    totalValue = totalValue + myCards[x].GetCardValue();
                }
            }
            return totalValue;
        }
        public Card returnXCard(int index)
        {
            return myCards[index];
        }
        public int getNumberOfCards()
        {
            return numberOfCards;
        }
        
    }
}

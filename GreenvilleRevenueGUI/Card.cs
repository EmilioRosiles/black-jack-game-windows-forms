using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace GreenvilleRevenueGUI
{
    class Card
    {
        private int value;
        private Image image;
        private bool isTheAce = false;
        public Card(int myValue, Image myImage)
        {
            value = myValue;
            image = myImage;

        }
        public int GetCardValue()
        {
            return value;
        }
        public Image GetCardImage()
        {
            return image;
        }
        public void switchValue()
        {
            if (isTheAce)
            {
                if (value == 11)
                {
                    value = 1;
                }
                else if (value == 1)
                {
                    value = 11;
                }
            }
        }
        public void convertToAce()
        {
            isTheAce = true;
        }
        public bool isAce()
        {
            return isTheAce;
        }
    }
}

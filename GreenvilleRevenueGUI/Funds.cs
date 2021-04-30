using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenvilleRevenueGUI
{
    class Funds
    {
        private int totalFunds;
        private int betAmount = 10;

        public Funds(int Funds)
        {
            totalFunds = Funds;
        }
        public int getfunds()
        {
            return totalFunds;
        }
        public int wonBet()
        {
            totalFunds = totalFunds + betAmount;
            return totalFunds;
        }
        public int lostBet()
        {
            totalFunds = totalFunds - betAmount;
            return totalFunds;
        }
        public void changeBet(int bet)
        {
            betAmount = bet;
        }
        public int getBet()
        {
            return betAmount;
        }
    }
}

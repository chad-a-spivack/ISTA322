using System;
using System.Collections.Generic;
using System.Text;

namespace Csharpprogex07
{
    class Wallet
    {
        public int ChipAmount { get; set; }
        public int money = 0;
        public Wallet()
        {
            ChipAmount = 0;
        }
        public Wallet(int e)
        {
            money += e;
        }

        public int WinMoney(int e)
        {
           return money += e;
        }
        public int LoseMoney(int e)
        {
            return money -= e;
        }
    }
}

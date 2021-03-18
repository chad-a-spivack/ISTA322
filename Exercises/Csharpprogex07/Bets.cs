using System;
using System.Collections.Generic;
using System.Text;

namespace Csharpprogex07
{
    class Bets
    {
        public int BetAmount { get; set; }
        public Bets()
        {
            BetAmount = 0;
        }
       
        public virtual void PlaceBets(int b)
        {
            int potentialWin = b;
        }

        public virtual int WinLoss()
        {
            return 0;
        }
        public virtual int Winnings()
        {
            return 0;
        }
        public  int Losses()
        {
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\gasp_x.wav";
            myPlayer1.PlaySync();
            return BetAmount ;
        }
    }
    class SingleBet : Bets
    {
        public int NumberBet { get; set; }
        public SingleBet()
        {
            BetAmount = 0;
        }
        //public override void PlaceBets(int b)
        //{
        //    BetAmount = b;
        //}
        public override int WinLoss()
        {
            Console.WriteLine("What number would you like to bet on?");
            Console.Write("Please enter a number ");
            string enteredNumber = Console.ReadLine();
            NumberBet = int.Parse(enteredNumber);
            return NumberBet;
        }
        public override int Winnings()
        {
            int winnings = BetAmount * 35;
            return winnings;
        }
        //public override int Losses()
        //{
        //    int loss = BetAmount;
        //    return loss;
        //}
    }
    class EvensOddBet : Bets
    {
        public EvensOddBet()
        {
            BetAmount = 0;
        }
        public override int WinLoss()
        {
            Console.Write("Evens or odds? (0 = even/ 1= odd)");
            string evenODD = Console.ReadLine();
            int evenOddInput = int.Parse(evenODD);
            return evenOddInput;
        }
        public override int Winnings()
        {
            int winnings = BetAmount;
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\cash_register2.wav";
            myPlayer1.PlaySync();
            return winnings;
        }
        //public override int Losses()
        //{
        //    return base.Losses();
        //}
    }
    class RedBlackBet : Bets
    {
        public RedBlackBet()
        {
            BetAmount = 0;
        }
        public  char RedBlackWinLoss()
        {
            Console.Write("Red or Black? (r = Red/ b = Black)");
            string redBlack = Console.ReadLine();
            char redBlackInput = char.Parse(redBlack);
            return redBlackInput;
        }
        public override int Winnings()
        {
            int winnings = BetAmount;
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\cash_register2.wav";
            myPlayer1.PlaySync();
            return winnings;
        }
    }
    class HiLoBet : Bets
    {
        public HiLoBet()
        {
            BetAmount = 0;
        }
        public override int WinLoss()
        {
            Console.Write("High or Low? (0 = High / 1= Low) ");
            string highLow = Console.ReadLine();
            int evenOddInput = int.Parse(highLow);

            return evenOddInput;
        }
        public override int Winnings()
        {
            int winnings = BetAmount;
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\cash_register2.wav";
            myPlayer1.PlaySync();
            return winnings;
        }
    }
    class DozensBet : Bets
    {
        public DozensBet()
        {
            BetAmount = 0;
        }
        public override int WinLoss()
        {
            Console.Write("Which dozen would you like? (1 = First(1-12) / 2 = Second(13-24) / 3 = Third(25-36))  ");
            string dozen = Console.ReadLine();
            int dozensInput = int.Parse(dozen);
            return dozensInput;
        }
        public override int Winnings()
        {
            int winnings = BetAmount * 2;
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\cash_register2.wav";
            myPlayer1.PlaySync();
            return winnings;
        }
    }
    class ColumnsBet : Bets
    {
        public ColumnsBet()
        {
            BetAmount = 0;
        }
        public override int WinLoss()
        {
            Console.Write("Which column would you like? (1 = First / 2 = Second / 3 = Third)  ");
            string column = Console.ReadLine();
            int columnInput = int.Parse(column);
            return columnInput;
        }
        public override int Winnings()
        {
            int winnings = BetAmount * 2;
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\cash_register2.wav";
            myPlayer1.PlaySync();
            return winnings;
        }
    }
    class StreetBet : Bets
    {
        public StreetBet()
        {
            BetAmount = 0;
        }
        public override int WinLoss()
        {
            Console.Write("Which street would you like? (1 = (1, 2, 3) / 2 = (4, 5, 6) / 3 = (7, 8, 9) 4 = (10, 11, 12) 5 = (13, 14, 15) 6 = (16, 17, 18) 7 = (19, 20, 21) 8 = (22, 23, 24) 9 = (25, 26, 27) 10 = (28, 29, 30) 11 = (31, 32, 33) 12 = (34, 35, 36)) ");
            string street = Console.ReadLine();
            int streetInput = int.Parse(street);
            return streetInput;
        }
        public override int Winnings()
        {
            int winnings = BetAmount * 11;
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\cash_register2.wav";
            myPlayer1.PlaySync();
            return winnings;
        }
    }
    class SixNumbersBet : Bets
    {
        public SixNumbersBet()
        {
            BetAmount = 0;
        }
        public override int WinLoss()
        {
            Console.Write("Which six numbers would you like? (1 = (1-6) / 2 = (7-12) / 3 = (13-18) / 4 = (19-24) / 5 = (25-30) / 6 = (31-36))  ");
            string column = Console.ReadLine();
            int columnInput = int.Parse(column);
            return columnInput;
        }
        public override int Winnings()
        {
            int winnings = BetAmount * 5;
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\cash_register2.wav";
            myPlayer1.PlaySync();
            return winnings;
        }
    }
    class SplitBet : Bets
    {
        public SplitBet()
        {
            BetAmount = 0;
        }
        public override int WinLoss()
        {
            Console.Write("Which number would you like to split" );
            string split = Console.ReadLine();
            int splitInput = int.Parse(split);
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\cash_register2.wav";
            myPlayer1.PlaySync();
            return splitInput;
        }
        public int SplitDirection(int e)
        {
            Console.Write("Which direction would you like to split? (1 = veritcal / 2 = horizontal) ");
            string direction = Console.ReadLine();
            int intDirection = int.Parse(direction);
            if (intDirection == 1)
            {
                int verticalSplit = e + 3;
                return verticalSplit;
            }
            else
            {
                int horizontalSplit = e + 1;
                return horizontalSplit;
            }
        }
        public override int Winnings()
        {
            int winnings = BetAmount * 17;
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\cash_register2.wav";
            myPlayer1.PlaySync();
            return winnings;
        }
    }
    class CornerBet : Bets
    {
        public CornerBet()
        {
            BetAmount = 0;
        }
        public override int WinLoss()
        {
            Console.Write("Which numbers would you like in your corner? (enter the lowest number in your corner)");
            string corner = Console.ReadLine();
            int cornerInput = int.Parse(corner);
            return cornerInput;
        }
        public int[] cornerGroup(int f)
        {
            int[] corner = { f, f + 1, f + 2, f + 3 };
            return corner;
        }
        public override int Winnings()
        {
            int winnings = BetAmount * 8;
            var myPlayer1 = new System.Media.SoundPlayer();
            myPlayer1.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\cash_register2.wav";
            myPlayer1.PlaySync();
            return winnings;
        }
    }

}

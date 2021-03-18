using System;
using System.Linq;
using System.Media;

namespace Csharpprogex07
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to the MSSA casino");
                Console.ReadLine();
                Roulette();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Roulette();
            }
        }
        public static int betAmount()
        {
            Console.Write("How much would you like to bet? ");
            string chipBet = Console.ReadLine();
            int chipAmount = int.Parse(chipBet);
            return chipAmount;
        }

        public static int CollectBets(int[] a, char[] b)
        {
            Console.WriteLine("No more bets! Press enter to roll");
            Table myTable = new Table();
            Console.ReadLine();
            myTable.CreateTable(a, b);
            int Roll()
            {
                int binIndex = 0;
                int totalRolls = 0;
                Random bin = new Random();
                var myPlayer = new System.Media.SoundPlayer();
                myPlayer.SoundLocation = @"C:\Users\Chad Spivack\MSSA2021\ISTA322\Exercises\roulette_wheel.wav";
                myPlayer.PlaySync();
                totalRolls++;
                return binIndex = bin.Next(0, a.Length);
            }
            return Roll();
        }
        public static int BetSelection()
        {
            Console.WriteLine("What would you like to bet?");
            Console.WriteLine("1) Single Number");
            Console.WriteLine("2) Evens/Odds");
            Console.WriteLine("3) Reds/Blacks");
            Console.WriteLine("4) Lows/Highs");
            Console.WriteLine("5) Dozens");
            Console.WriteLine("6) Columns");
            Console.WriteLine("7) Street");
            Console.WriteLine("8) 6 Numbers");
            Console.WriteLine("9) Split");
            Console.WriteLine("10) Corner");
            Console.Write("Enter a number for the type of bet you would like to place: ");
            string betType = Console.ReadLine();
            int betInt = int.Parse(betType);
            return betInt;
        }
        public static void Roulette()
        {
            int[] numbers = { (int)00, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
                                21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36 };
            char[] colors = { 'g', 'g', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r',
                                'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b', 'r', 'b' };

            int[] firstColumn = { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };
            int[] secondColumn = { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };
            int[] thirdColumn = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 };

            Console.Write("How much did you come to bet with today?: ");
            string rentMoney = Console.ReadLine();
            int dollarBillz = int.Parse(rentMoney);
            Gambler Chad = new Gambler(dollarBillz);

            Wallet ChadsWallet = new Wallet(dollarBillz);

            Console.WriteLine($"Total amount in your wallet is {dollarBillz}");

            int betInt = BetSelection();

            int chipsBet = betAmount();

            if (betInt == 1)
            {
                SingleBet SingleNumber = new SingleBet { BetAmount = chipsBet };
                int binBet = SingleNumber.WinLoss();
                int winningBin = CollectBets(numbers, colors);
                Console.WriteLine($"The winning number is {numbers[winningBin]} and the winning color is {colors[winningBin]}");
                if (binBet == winningBin)
                {
                    int totalWon = SingleNumber.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0); 
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else
                {
                    int totalLost = SingleNumber.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }

                }
            }
            else if (betInt == 2)
            {
                EvensOddBet EvensOdds = new EvensOddBet { BetAmount = chipsBet };
                int oddsBet = EvensOdds.WinLoss();
                int winningBin = CollectBets(numbers, colors);
                Console.WriteLine($"The winning number is {numbers[winningBin]} and the winning color is {colors[winningBin]}");
                if (oddsBet == 0 && numbers[winningBin] % 2 == 0)
                {
                    int totalWon = EvensOdds.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (oddsBet == 0 && numbers[winningBin] % 2 != 0)
                {
                    int totalLost = EvensOdds.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (oddsBet == 1 && numbers[winningBin] % 2 == 0)
                {
                    int totalLost = EvensOdds.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (oddsBet == 1 && numbers[winningBin] % 2 != 0)
                {
                    int totalWon = EvensOdds.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }

            }
            else if (betInt == 3)
            {
                RedBlackBet RedBlack = new RedBlackBet { BetAmount = chipsBet };
                int oddsBet = RedBlack.RedBlackWinLoss();
                int winningBin = CollectBets(numbers, colors);
                Console.WriteLine($"The winning number is {numbers[winningBin]} and the winning color is {colors[winningBin]}");
                if (oddsBet == colors[winningBin])
                {
                    int totalWon = RedBlack.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else
                {
                    int totalLost = RedBlack.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
            }
            else if (betInt == 4)
            {
                HiLoBet HiLo = new HiLoBet { BetAmount = chipsBet };
                int hiLO = HiLo.WinLoss();
                int winningBin = CollectBets(numbers, colors);
                Console.WriteLine($"The winning number is {numbers[winningBin]} and the winning color is {colors[winningBin]}");
                if (hiLO == 0 && numbers[winningBin] > 18)
                {
                    int totalWon = HiLo.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (hiLO == 0 && numbers[winningBin] <= 18)
                {
                    int totalLost = HiLo.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (hiLO == 1 && numbers[winningBin] > 18)
                {
                    int totalLost = HiLo.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (hiLO == 1 && numbers[winningBin] <= 18)
                {
                    int totalWon = HiLo.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
            }
            else if (betInt == 5)
            {
                DozensBet Dozens = new DozensBet { BetAmount = chipsBet };
                int dozens = Dozens.WinLoss();
                int winningBin = CollectBets(numbers, colors);
                Console.WriteLine($"The winning number is {numbers[winningBin]} and the winning color is {colors[winningBin]}");
                if (dozens == 1 && numbers[winningBin] < 13)
                {
                    int totalWon = Dozens.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (dozens == 2 && numbers[winningBin] >= 13 && numbers[winningBin] < 25)
                {
                    int totalWon = Dozens.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (dozens == 3 && numbers[winningBin] >= 25)
                {
                    int totalWon = Dozens.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else
                {
                    int totalLost = Dozens.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
            }
            else if (betInt == 6)
            {
                ColumnsBet Columns = new ColumnsBet { BetAmount = chipsBet };
                int columns = Columns.WinLoss();
                int winningBin = CollectBets(numbers, colors);
                Console.WriteLine($"The winning number is {numbers[winningBin]} and the winning color is {colors[winningBin]}");
                if (columns == 1 && firstColumn.Contains(winningBin))
                {
                    int totalWon = Columns.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (columns == 2 && secondColumn.Contains(winningBin))
                {
                    int totalWon = Columns.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (columns == 3 && thirdColumn.Contains(winningBin))
                {
                    int totalWon = Columns.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else
                {
                    int totalLost = Columns.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
            }
            else if (betInt == 7)
            {
                StreetBet Street = new StreetBet { BetAmount = chipsBet };
                int street = Street.WinLoss();
                int winningBin = CollectBets(numbers, colors);
                Console.WriteLine($"The winning number is {numbers[winningBin]} and the winning color is {colors[winningBin]}");
                if (street == 1 && (numbers[winningBin] == 1 || numbers[winningBin] == 2 || numbers[winningBin] == 3))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 2 && (numbers[winningBin] == 4 || numbers[winningBin] == 5 || numbers[winningBin] == 6))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 3 && (numbers[winningBin] == 7 || numbers[winningBin] == 8 || numbers[winningBin] == 9))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 4 && (numbers[winningBin] == 10 || numbers[winningBin] == 11 || numbers[winningBin] == 12))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 5 && (numbers[winningBin] == 13 || numbers[winningBin] == 14 || numbers[winningBin] == 15))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 6 && (numbers[winningBin] == 16 || numbers[winningBin] == 17 || numbers[winningBin] == 18))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 7 && (numbers[winningBin] == 19 || numbers[winningBin] == 20 || numbers[winningBin] == 21))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 8 && (numbers[winningBin] == 22 || numbers[winningBin] == 23 || numbers[winningBin] == 24))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 9 && (numbers[winningBin] == 25 || numbers[winningBin] == 26 || numbers[winningBin] == 27))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 10 && (numbers[winningBin] == 28 || numbers[winningBin] == 29 || numbers[winningBin] == 30))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 11 && (numbers[winningBin] == 31 || numbers[winningBin] == 32 || numbers[winningBin] == 33))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (street == 12 && (numbers[winningBin] == 34 || numbers[winningBin] == 35 || numbers[winningBin] == 36))
                {
                    int totalWon = Street.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else
                {
                    int totalLost = Street.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
            }
            else if (betInt == 8)
            {
                SixNumbersBet SixNumbers = new SixNumbersBet { BetAmount = chipsBet };
                int six = SixNumbers.WinLoss();
                int winningBin = CollectBets(numbers, colors);
                Console.WriteLine($"The winning number is {numbers[winningBin]} and the winning color is {colors[winningBin]}");
                if (six == 1 && numbers[winningBin] < 7)
                {
                    int totalWon = SixNumbers.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (six == 2 && numbers[winningBin] >= 7 && numbers[winningBin] < 13)
                {
                    int totalWon = SixNumbers.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (six == 3 && numbers[winningBin] >= 14 && numbers[winningBin] < 21)
                {
                    int totalWon = SixNumbers.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette(); 
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (six == 4 && numbers[winningBin] >= 21 && numbers[winningBin] < 27)
                {
                    int totalWon = SixNumbers.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (six == 5 && numbers[winningBin] >= 27 && numbers[winningBin] < 31)
                {
                    int totalWon = SixNumbers.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else if (six == 6 && numbers[winningBin] >= 31)
                {
                    int totalWon = SixNumbers.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else
                {
                    int totalLost = SixNumbers.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
            }
            else if (betInt == 9)
            {
                SplitBet Split = new SplitBet { BetAmount = chipsBet };
                int split = Split.WinLoss();
                int splitSecond = Split.SplitDirection(split);
                int winningBin = CollectBets(numbers, colors);
                Console.WriteLine($"The winning number is {numbers[winningBin]} and the winning color is {colors[winningBin]}");
                if (numbers[winningBin] == split || numbers[winningBin] == splitSecond)
                {
                    int totalWon = Split.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else
                {
                    int totalLost = Split.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
            }
            else if (betInt == 10)
            {
                CornerBet Corner = new CornerBet { BetAmount = chipsBet };
                int corner = Corner.WinLoss();
                int[] cornerGroup = Corner.cornerGroup(corner);
                int winningBin = CollectBets(numbers, colors);
                Console.WriteLine($"The winning number is {numbers[winningBin]} and the winning color is {colors[winningBin]}");
                if (cornerGroup.Contains(numbers[winningBin]))
                {
                    int totalWon = Corner.Winnings();
                    Console.WriteLine($"Congratulations! You won {totalWon}");
                    int newWalletTotal = ChadsWallet.WinMoney(totalWon);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
                else
                {
                    int totalLost = Corner.Losses();
                    Console.WriteLine($"Tough luck you lost {totalLost}");
                    int newWalletTotal = ChadsWallet.LoseMoney(totalLost);
                    Console.WriteLine($"New wallet total is {newWalletTotal}");
                    while (newWalletTotal > 0)
                    {
                        Console.Write("Spin again? (y/n)");
                        string spin = Console.ReadLine();
                        if (spin == "y")
                        {
                            Roulette();
                        }
                        else
                            Environment.Exit(0);
                    }
                    if (newWalletTotal == 0)
                    {
                        Console.WriteLine("You're broke.  Please leave");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}

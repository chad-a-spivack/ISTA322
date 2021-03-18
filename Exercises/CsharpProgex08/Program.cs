using System;

namespace CsharpProgex08
{
    class UserGuess
    {
        protected int _randomNumber;
        protected int _userGuess;
        protected int count = 0;

        public UserGuess() 
        {
            Random random = new Random();
            _randomNumber = random.Next(1, 100);
        }
        public virtual bool MyGuess()
        {
            Console.Write("Enter a number: ");
            _userGuess = int.Parse(Console.ReadLine());
            if (_userGuess == _randomNumber)
            {
                Console.WriteLine("Congrats you are correct");
                
                return true;
            }
            else if (_userGuess < _randomNumber)
            {
                Console.WriteLine("Too Low, Guess Again");
                return false;
            }
            else if (_userGuess > _randomNumber)
            {
                Console.WriteLine("Too high, guess again");
                return false;
            }
            else
            {
                Console.WriteLine("Invalid, guess again");
                return false;
            }
        }
        public virtual void isCorrect()
        {
            do
            {
            } while (MyGuess() == false);
        }

    }
    class computerGuess : UserGuess
    {
        public computerGuess()
        {
            Random computerRandom = new Random();
            _randomNumber = computerRandom.Next(1, 1000);
        }
        public override bool MyGuess()
        {
            
            Console.WriteLine("Pick a number between 1 and 1000");
            Console.WriteLine(_randomNumber);
            Console.WriteLine("1) You are correct\n 2) Too high\n 3) Too low");
            int guessAgain = int.Parse(Console.ReadLine());
            if (guessAgain == 1)
            {
                int i = count++;
                Console.WriteLine($"It took you {i} guesses to beat the human" );
                return true;
            }
            else if (guessAgain == 2)
            {
                count++;
                Random lowGuess = new Random();
                _randomNumber = lowGuess.Next(0, _randomNumber);
                return false;
            }
            else if (guessAgain == 3)
            {
                count++;
                Random highGuess = new Random();
                _randomNumber = highGuess.Next(_randomNumber, 1000);
                return false;
            }
            else
            {
                return false;
            }
        }
        public override void isCorrect()
        {
            do
            {
            } while (MyGuess() == false);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            UserGuess Chad = new UserGuess();
            Chad.isCorrect();
            computerGuess cpu = new computerGuess();
            cpu.isCorrect();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Csharpprogex07
{
    class Gambler
    {
        int _cash = 0;
        
        public Gambler()
        {
            Console.WriteLine("You have no money go home");
        }
        public Gambler(int cash)
        {
            _cash = cash;
            if (cash > 1000)
            {
                Console.WriteLine("High Roller coming to the table!");
            }
            else if (cash > 500 && cash <= 1000)
            {
                Console.WriteLine("Woah this guy came to play");
            }
            else if (cash > 100 && cash <= 500)
            {
                Console.WriteLine("Does your wife know you are here?");
            }
            else
            {
                Console.WriteLine("Please get out of my casino before I call security");
            }
        }
       
    }
}

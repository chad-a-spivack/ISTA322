using System;
using System.Collections.Generic;
using System.Text;

namespace Csharpprogex07
{
    class Table
    {
       
        public void CreateTable(int[] a, char[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine($"{a[i]} - {b[i]}");
            }
        }
        
       
    }
}

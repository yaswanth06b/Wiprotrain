﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Matrixcs
    {
        static void Main()
        {
            int n, m;
            Console.WriteLine("Enter Rows and Columns  ");
            n = Convert.ToInt32(Console.ReadLine());
            m = Convert.ToInt32(Console.ReadLine());
            int[,] x = new int[n, m];

            Console.WriteLine("Enter Array Elements (total {0})  ", n * m);
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(n - 1); j++)
                {
                    x[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine("Display Elements in Matrix Format  ");
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    Console.Write(x[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
    }
}
 
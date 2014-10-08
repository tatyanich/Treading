using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ConsoleApplication1
{
    class Program
    { 
        static public double[,] Multiply(Matrix mas, int a)
        {   Block[,] blocks;
        int x = 2;
        int y = 2;

            int n;
             int m;
            
            //Dobavila peremennue no vot kak izvlech dlinny Matrix mas ne uverenna chto pravilno
            if (mas.n % x > 0)
            {
                n = mas.n / x + 1;
            }
            else
            {
                n = mas.n / x;
            }
            if (mas.m % y > 0)
            {
                m = mas.m / y + 1;
            }
            else
            {
                m = mas.m / y;
            }
        blocks = new Block[n,m];
           // double [][] res = new double[mas.Length][];
            for(int i=0; i<n; i++){
           //     res[i] = new double[mas[i].Length];

             for(int j=0; j<m; j++){
                blocks[i/n,j/n].add(new Index(i,j));// Dobavila vot eto no uverenna potomu cht ne pashet
           //      if
           //      //mas[i][j] = mas[i][j] * a;
           // }
           //}
           // return res;
       }
        private delegate double dUtreatMult(int a, double[][] matr);


    
        static void Main(string[] args)
        {
            System.Console.Write("{0}", 3/1);

            //double [][] array = new double[][] 
            //    {
            //    new double[] {1,3,5,7,9},
            //    new double[] {0,2,4,6},
            //    new double[] {11,22}
            //    };
            //int a = 2;
            //double[][] arr = Multiply(array, a);

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    System.Console.Write("Element({0}): ", i);

            //    for (int j = 0; j < arr[i].Length; j++)
            //    {
            //        System.Console.Write("{0}{1}", array[i][j], j == (array[i].Length - 1) ? "" : " ");
            //    }
            //    System.Console.WriteLine();
            //}
            System.Console.WriteLine("  Press any key to exit.");
            System.Console.ReadKey();
        }

    }
}

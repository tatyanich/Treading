using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ConsoleApplication1
{
    class Program
    { 
        static public double[,] Multiply(Matrix mas, int a)
        {   Block[][] blocks;
            int n;
            int newVariable; 
            // TODO razmer bloka eto ne massiv, nado vynesty ego v peremennie 'x' i 'y' - eto ya dobavil
            double [,] block = new double[2,2];
            if (mas.n% block.Length > 0) {
                n = mas.n /block.Length + 1;
               
            } 
            else
                n = mas.n /block.Length;
        blocks = new Block[n][];
           // double [][] res = new double[mas.Length][];
           // for(int i=0; i<mas.Length; i++){
           //     res[i] = new double[mas[i].Length];

           //  for(int j=0; j<mas[i].Length; j++){
                
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

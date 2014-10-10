using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics; 

namespace ConsoleApplication1
{
    class Program
    {
        static public Block[][] PartitionBlocks(Matrix mas, int x, int y)
        {
            Block[][] blocks;
            int n;
            int m;
            if (mas.Columns() % y > 0)
            {
                m = mas.Columns() / y + 1;
            }
            else
            {
                m = mas.Columns() / y;
            }
            if (mas.Rows() % x > 0)
            {
                n = mas.Rows() / x + 1;
            }
            else
            {
                n = mas.Rows() / x;
            }
            blocks = new Block[n][];

            for (int i = 0; i < n; i++)
            {
                blocks[i] = new Block[m];
                for (int j = 0; j < m; j++)
                {
                    blocks[i][j] = new Block();


                }
            }
            for (int i = 0; i < mas.Rows(); i++)
            {
                for (int j = 0; j < mas.Columns(); j++)
                {
                    blocks[i / x][j / y].AddIndexes(new Index(i, j));

                }
            }
            return blocks;
        }

        static public void Multiply(Block[][] blocks, Matrix mas, int a)
        {
            double h;

            for (int i = 0; i < blocks.Length; i++)
            {
                for (int j = 0; j < blocks[i].Length; j++)
                {
                    for (int k = 0; k < blocks[i][j].Indexes.Count; k++)
                    {
                        Index ind = blocks[i][j].Indexes[k];

                        h = mas.GetElement(ind)*a;

                        mas.SetElement(h, ind);
                    }
                

                }
            }

        }



    //    static void Main(string[] args)
    //    {


    //        double[][] arr = new double[][] 
    //            {
    //            new double[] {1,3,5,7,9,8},
    //            new double[] {0,2,4,6,7,1},
    //            new double[] {11,22,5,4,3,2},
    //            new double[] {3,2,4,6,7,1},
    //            new double[] {9,10,5,4,3,0}
    //           };

    //        int b = 2;
    //        int x = 2;
    //        int y = 2;
    //        Matrix mass = new Matrix(arr);


    //        Block[][] tread;
    //        tread = PartitionBlocks(mass, x, y);

    //        Stopwatch sWatch = new Stopwatch();

    //        sWatch.Start();
    //        for (int i = 0; i < 100; i++)
    //        {
    //            Multiply(tread, mass, b);
    //        }
    //        sWatch.Stop();

    //        Console.WriteLine(sWatch.ElapsedMilliseconds.ToString());
            


    //        for (int i = 0; i < mass.Rows(); i++)
    //        {
    //            System.Console.Write("({0}): ", i);

    //            for (int j = 0; j < mass.Columns(); j++)
    //            {
    //                System.Console.Write("{0}{1}", mass.GetElement(new Index(i, j)), j == (mass.Columns() - 1) ? "" : " ");
    //            }
    //            System.Console.WriteLine();
    //        }
    //        System.Console.WriteLine("  Press any key to exit.");
    //        System.Console.ReadKey();
    //    }

    }
}

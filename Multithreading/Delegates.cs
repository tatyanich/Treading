using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics; 
namespace ConsoleApplication1
{
    class Delegates
    {
        static private void UThreadMult(List<Block> blocks, Matrix matr, double a)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                Block block = blocks[i];
                for (int k = 0; k < block.Indexes.Count; k++)
                {
                    Index ind = block.Indexes[k];

                    double h = matr.GetElement(ind) * a;

                    matr.SetElement(h, ind);
                }
            }
        }
        private delegate void dUThreadMult(List<Block> block, Matrix matr, double a);
        private dUThreadMult dU = UThreadMult;



        public void Multiply(List<Block> treadList, Matrix mas, int a)
        {
            int N = 8; // event chto-to tam takoe
            int treadBlocksCount = treadList.Count / N;
            List<IAsyncResult> ares = new List<IAsyncResult>();

            if (treadBlocksCount == 0)
            {
                int count = treadList.Count;
                for (int i = 0; i < count; i++)
                {
                    List<Block> t = new List<Block>();
                    t.Add(treadList[0]);
                    treadList.RemoveAt(0);
                    ares.Add(dU.BeginInvoke(t, mas, a, null, null));
                }               
            }
            else
            {
                for (int i = 0; i < N - 1; i++)
                {
                    List<Block> t = new List<Block>();
                    for (int j = 0; j < treadBlocksCount; j++)
                    {
                        t.Add(treadList[0]);
                        treadList.RemoveAt(0);
                    }
                    ares.Add(dU.BeginInvoke(t, mas, a, null, null));
                }
                ares.Add(dU.BeginInvoke(treadList, mas, a, null, null));
            }

            s: while (true)
                {
                    for (int i = 0; i < ares.Count; i++)
                        if (!ares[i].IsCompleted) goto s;
                    break;
                }
                for (int i = 0; i < ares.Count; i++)
                    dU.EndInvoke(ares[i]);               
        }
    }

    class ProgramDelgates
    {


        static void Main(string[] args)
        {


            double[][] arr = new double[][] 
                {
                new double[] {1,3,5,7,9,8},
                new double[] {0,2,4,6,7,1},
                new double[] {11,22,5,4,3,2},
                new double[] {3,2,4,6,7,1},
                new double[] {9,10,5,4,3,0}
               };

            int b = 2;
            int x = 2;
            int y = 2;
            Matrix mass = new Matrix(arr);


            Block[][] tread = PartitionBlocks(mass, x, y);
            List<Block> treadList = MakeList(tread);

            Stopwatch sWatch = new Stopwatch();

            sWatch.Start();
            for (int i = 0; i < 100; i++)
            {
                Delegates d = new Delegates();
                d.Multiply(treadList, mass, b);
            }
            sWatch.Stop();

            Console.WriteLine(sWatch.ElapsedMilliseconds.ToString());
            
           

            for (int i = 0; i < mass.Rows(); i++)
            {
                System.Console.Write("({0}): ", i);

                for (int j = 0; j < mass.Columns(); j++)
                {
                    System.Console.Write("{0}{1}", mass.GetElement(new Index(i, j)), j == (mass.Columns() - 1) ? "" : " ");
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine("  Press any key to exit.");
            System.Console.ReadKey();

        }

        static List<Block> MakeList(Block[][] tread)
        {
            List<Block> treadList = new List<Block>();
            for (int i = 0; i < tread.Length; i++)
            {
                for (int j = 0; j < tread[i].Length; j++)
                {
                    treadList.Add(tread[i][j]);
                }
            }
            return treadList;
        }

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



    }
}


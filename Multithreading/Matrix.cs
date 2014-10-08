using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Matrix
    {
        private double[,] matrix;
        private int N;
        private int M;

        public Matrix(double[,] arr, int p1, int p2) {
            N = p1;
            M = p2;
            matrix = new double[N,M];
                for(int i=0; i< N; i++){
                    for(int j=0; j< M; j++){
                   matrix[i,j]=arr[i,j]; 
                    }
                }
        }
        public int n
        {
            get
            {
                return N;
            }
        }

        public int m
        {
            get
            {
                return M;
            }
        }


        public double GetElement(Index index) {

            double element = matrix[index.cordI,index.cordJ];
            return element;
 
        }

        public void SetElement(double element,Index index)
        {
            
            matrix[index.cordI,index.cordJ] = element; 
            

        }
        
        
    }
}

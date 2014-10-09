using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Matrix
    {
        private double[][] matrix;
     

        public Matrix(double[][] arr) {
           // N = p1;
           // M = p2;
            matrix = arr;
                
        }

        public int Rows() {
           
           
            return matrix.Length;
        }
        public int Columns()
        {
            return matrix[0].Length;
        }

        public double GetElement(Index index) {

            double element = matrix[index.cordI][index.cordJ];
            return element;
 
        }

        public void SetElement(double element,Index index)
        {
            
            matrix[index.cordI][index.cordJ] = element; 
            

        }
        
        
    }
}

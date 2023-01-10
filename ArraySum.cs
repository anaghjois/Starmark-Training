using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    class sum{
        public void add(int[,] mat)
        {
            int rank = mat.Rank;
            int sum = 0;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    sum = sum + mat[i, j];
                    
                }

            }
            Console.WriteLine(sum);
        }
    }
    class ArraySum
    {
        static void Main(string[] args)
        {
            int[,] mat = new int[,] { { 1, 2, 3 }, { 2, 3, 4 }, { 4, 5, 6 } };
            sum sum = new sum();
            sum.add(mat);
        }
    }
}

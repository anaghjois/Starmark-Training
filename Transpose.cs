using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    class trans
    {
        public void Transpose(int[,] mat)
        {
            int rank = mat.Rank;
            for (int i = 0; i < mat.GetLength(1); i++)
            {
                for (int j = 0; j < mat.GetLength(0); j++)
                {
                    Console.Write(mat[j,i]);
                }
                Console.WriteLine();
            }
        }
    }
    class Transpose
    {
        static void Main(string[] args)
        {
            int[,] mat = new int[,] { { 1, 2, 3 }, { 2, 3, 4 }, { 4, 5, 6 } };
            trans trans = new trans();
            trans.Transpose(mat);

        }
    }
}

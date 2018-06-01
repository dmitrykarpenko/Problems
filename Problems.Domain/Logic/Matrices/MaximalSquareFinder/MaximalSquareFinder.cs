using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Matrices.MaximalSquareFinder
{
    public class MaximalSquareFinder : IMaximalSquareFinder
    {
        /// <summary>
        /// Time Complexity: O(rc*cc).
        /// Auxiliary Space: O(rc*cc).
        /// Here rc is number of rows and n is number of columns in the given <paramref name="matrix"/>.
        /// Algorithmic Paradigm: Dynamic Programming.
        /// </summary>
        /// <param name="matrix">Input matrix, rc x cc (i.e. "row count" x "column count")</param>
        /// <returns>Area of the largest square</returns>
        public int MaximalSquare(char[,] matrix)
        {
            if (matrix == null)
                return 0;

            int r, c;
            int rc = matrix.GetLength(0); // count of rows in matrix
            int cc = matrix.GetLength(1); // count of columns in matrix

            if (rc == 0 || cc == 0)
                return 0;

            // auxiliary matrix that will hold the maximum side of a contiguous square
            int[,] aux = new int[rc, cc];

            // set firs column of aux
            for (r = 0; r < rc; r++)
                aux[r, 0] = ToInt(matrix[r, 0]);

            // set firs row of aux 
            for (c = 0; c < cc; c++)
                aux[0, c] = ToInt(matrix[0, c]);

            // calculate other entries of aux
            for (r = 1; r < rc; r++)
                for (c = 1; c < cc; c++)
                    if (matrix[r, c] == _significant) // same as ToInt(matrix[r, c]) == 1
                    {
                        // if any of the three checked adjacent vertices (i.e. left, top, left-top) is 0,
                        // the current aux will also be zero;
                        // if all of those adjacent vertices are not 0, all of those are on their squares,
                        // thus write "current square side size" = min("adjacent vertices squares sizes") + 1
                        // as the current element made the side longer by 1
                        aux[r, c] =
                            Math.Min(
                                aux[r, c - 1], Math.Min(
                                aux[r - 1, c],
                                aux[r - 1, c - 1]))
                            + 1;
                    }
                    else
                    {
                        // if current matrix element is 0,
                        // it cannnot be a vertex of a rectangle (thus a square too)
                        aux[r, c] = 0;
                    }


            int maxAux = aux[0, 0];

            // find max aux
            for (r = 0; r < rc; r++)
                for (c = 0; c < cc; c++)
                    if (aux[r, c] > maxAux)
                        maxAux = aux[r, c];

            return maxAux * maxAux;
        }

        private const char _significant = '1';
        private static int ToInt(char c) => c == _significant ? 1 : 0;
    }
}

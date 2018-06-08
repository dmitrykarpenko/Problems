using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Domain.Logic.Matrices.PathCounter
{
    /// <summary>
    /// Number of Paths
    /// You’re testing a new driverless car that is located at the Southwest(bottom-left) corner
    /// of an n×n grid.The car is supposed to get to the opposite, Northeast (top-right), corner
    /// of the grid. Given n, the size of the grid’s axes, write a function numOfPathsToDest
    /// that returns the number of the possible paths the driverless car can take.
    /// 
    /// For convenience, let’s represent every square in the grid as a pair (i,j).
    /// The first coordinate in the pair denotes the east-to-west axis, and the second coordinate denotes the south-to-north axis.
    /// The initial state of the car is (0,0), and the destination is (n-1,n-1).
    /// The car must abide by the following two rules: it cannot cross the diagonal border.
    /// In other words, in every step the position (i, j) needs to maintain i >= j.
    /// See the illustration above for n = 5. In every step, it may go one square North (up),
    /// or one square East (right), but not both.E.g. if the car is at (3,1), it may go to(3,2) or(4,1).
    /// 
    /// Explain the correctness of your function, and analyze its time and space complexities.
    /// 
    /// Example:
    /// input:  n = 4
    /// output: 5 # since there are five possibilities:
    ///           # “EEENNN”, “EENENN”, “ENEENN”, “ENENEN”, “EENNEN”,
    ///           # where the 'E' character stands for moving one step
    ///           # East, and the 'N' character stands for moving one step
    ///           # North (so, for instance, the path sequence “EEENNN”
    ///           # stands for the following steps that the car took:
    ///           # East, East, East, North, North, North)
    ///           
    /// Constraints:
    /// [time limit] 5000ms
    /// [input] integer n
    /// 1 ≤ n ≤ 100
    /// [output] integer
    /// </summary>
    public static class StaticPathCounter
    {
        //static void Main(string[] args)
        //{
        //    for (int n = 3; n < 7; ++n)
        //    {
        //        int o = NumOfPathsToDest(n);
        //        Console.WriteLine($"n: {n}, output: {o}");
        //    }
        //}

        public static int NumOfPathsToDest(int n)
        {
            if (n < 2)
                return n;

            _max = n - 1;
            _nums.Clear();
            return GetNumRecursive(0, 0);
        }
        
        private static int _max;

        private static Dictionary<Tuple<int, int>, int> _nums =
            new Dictionary<Tuple<int, int>, int>();

        private static int GetOrCountNum(int ec, int nc)
        {
            var key = new Tuple<int, int>(ec, nc);
            int num;
            if (_nums.TryGetValue(key, out num))
                return num;

            return _nums[key] = GetNumRecursive(ec, nc);
        }

        // ec - east count, nc - north count
        private static int GetNumRecursive(int ec, int nc)
        {
            if (ec == _max && nc == _max)
                return 1;

            if (ec == nc)
                return GetOrCountNum(ec + 1, nc);

            if (ec == _max)
                return GetOrCountNum(ec, nc + 1);

            return
              GetOrCountNum(ec + 1, nc) +
              GetOrCountNum(ec, nc + 1);
        }
    }
}

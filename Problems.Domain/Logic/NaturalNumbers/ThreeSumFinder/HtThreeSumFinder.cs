using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Domain.Logic.NaturalNumbers.ThreeSumFinder
{
    /// <summary>
    /// Ht stands for hash table.
    /// The idea is to put nums to a Dictionary (i.e. hash table) and then to search for
    /// target = -num[i] - num[j] in the Dictionary
    /// </summary>
    public class HtThreeSumFinder : IThreeSumFinder
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return new List<IList<int>>();

            var nl = nums.Length;
            var numInfos = new Dictionary<int, NumInfo>();

            for (int i = 0; i < nl; ++i)
            {
                var num = nums[i];
                NumInfo numInfo;
                if (numInfos.TryGetValue(num, out numInfo))
                {
                    numInfo.Indices.Add(i);
                }
                else
                {
                    numInfo = new NumInfo();
                    numInfo.Indices.Add(i);
                    numInfos.Add(num, numInfo);
                }
            }

            for (int i = 0; i < nl; ++i)
            {
                for (int j = i+1; j < nl; ++j)
                {
                    int numI = nums[i];
                    int numJ = nums[j];
                    int target = -numI - numJ;
                    NumInfo numInfo;
                    if (numInfos.TryGetValue(target, out numInfo))
                    {
                        var indices = numInfo.Indices;

                        // ...

                        // here j is greater than i, so could get indices greater than j and return
                        // all the respectire [i, j, {found index}] triplet;
                        // should check for duplicate triplets then though
                    }
                }
            }

            throw new NotImplementedException();
        }

        private class NumInfo
        {
            /// <summary> Are always ascending </summary>
            public readonly List<int> Indices = new List<int>();
        }
    }
}

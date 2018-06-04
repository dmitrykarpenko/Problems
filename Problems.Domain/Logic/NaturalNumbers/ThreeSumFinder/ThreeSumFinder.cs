using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.ThreeSumFinder
{
    public class ThreeSumFinder : IThreeSumFinder
    {
        /// <summary>
        /// The algorithm is based on sorting:
        /// we sort nums first (which takes at most O(n^2) time) and
        /// then inspect an interval [left, right],
        /// adding triples [nums[i], nums[left], nums[right]] if conditions met
        /// </summary>
        /// <param name="nums">The input numbers</param>
        /// <returns>The output collection of triples</returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var triples = new List<IList<int>>();

            if (nums == null || nums.Length == 0)
                return triples;

            // takes at most O(n^2)
            Sort(nums);

            for (int i = 0; i < nums.Length - 2; ++i)
            {
                // as we are searching for distinct triples, 
                // skip if equal to the previous one:
                if (i > 0 && nums[i - 1] == nums[i])
                    continue;

                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    // here, i < left < right
                    int sum = nums[i] + nums[left] + nums[right];
                    if (sum == 0)
                    {
                        // add the found triple, increment left, and decrement right as we
                        // should not inspect nums at those indices for the current i anymore
                        triples.Add(new List<int> { nums[i], nums[left], nums[right] });

                        // as we are searching for distinct triples, 
                        // skip if equal to the previous ones:
                        while (left < right && nums[left] == nums[left + 1])
                            ++left;
                        while (left < right && nums[right] == nums[right - 1])
                            --right;

                        // increment left, and decrement right
                        // as we should not inspect nums of values nums[left], nums[right]
                        // for the current index i anymore
                        left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        // as nums are ascending, makes sum greater or equal
                        ++left;
                    }
                    else
                    {
                        // as nums are ascending, makes sum less or equal
                        --right;
                    }
                }
            }
            return triples;
        }

        /// <summary> Uses standard sort for now just to keep it simple </summary>
        /// <param name="nums">The array to sort</param>
        private static void Sort(int[] nums)
        {
            var numsList = new List<int>(nums);

            numsList.Sort();

            for (int i = 0; i < nums.Length; i++)
                nums[i] = numsList[i];
        }
    }
}

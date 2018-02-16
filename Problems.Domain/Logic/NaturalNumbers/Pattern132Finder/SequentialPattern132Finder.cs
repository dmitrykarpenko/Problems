using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.Pattern132Finder
{
    public class SequentialPattern132Finder : IPattern132Finder
    {
        public bool Find132pattern(int[] nums)
        {
            return Has132Pattern(nums);
        }

        private class MinMaxModel
        {
            public int Min = int.MaxValue;
            public int Max = int.MinValue;

            public bool Contains(int value) => Min < value && value < Max;

            public bool Is132Valid => Min < Max + 1;
        }

        private static bool Has132Pattern(int[] nums)
        {
            if (nums.Length < 3)
            {
                return false;
            }

            var minMax = new MinMaxModel { Min = Math.Min(nums[0], nums[1]), Max = Math.Max(nums[0], nums[1]) };

            for (int i = 2; i < nums.Length; ++i)
            {
                if (nums[i] < minMax.Min)
                {
                    var iNext = i + 1;
                    if (iNext < nums.Length)
                    {
                        if (minMax.Contains(nums[iNext]))
                        {
                            // found a triad - minMax, nums[iNext]
                            return true;
                        }
                        else if (nums[iNext] > minMax.Max)
                        {
                            // found wider minMax, assign Min, Max, and then continue
                            minMax.Min = nums[i];
                            minMax.Max = nums[iNext];
                            i = iNext;
                            continue;
                        }
                    }

                    minMax.Min = nums[i];
                }
                if (nums[i] > minMax.Max)
                {
                    minMax.Max = nums[i];
                }

                // found a triad - minMax, nums[i]
                if (minMax.Contains(nums[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

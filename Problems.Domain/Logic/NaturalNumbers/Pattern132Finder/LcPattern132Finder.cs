using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.Pattern132Finder
{
    public class LcPattern132Finder : IPattern132Finder
    {
        public bool Find132pattern(int[] nums)
        {
            return Has132Pattern(nums);
        }

        private static bool Has132Pattern(int[] nums)
        {
            if (nums.Length < 3)
            {
                return false;
            }

            var mins = GetMins(nums);

            for (int i = nums.Length - 1, iCandidate = nums.Length; i >= 0; --i)
            {
                if (nums[i] > mins[i])
                {
                    iCandidate = GetIndexOfNextOrLength(nums, iCandidate, num => num > mins[i]);

                    if (iCandidate < nums.Length &&
                        nums[iCandidate] < nums[i])
                    {
                        return true;
                    }

                    nums[--iCandidate] = nums[i];
                }
            }

            return false;
        }

        private static int GetIndexOfNextOrLength(int[] nums, int iMin, Func<int, bool> condition)
        {
            int i = iMin;

            for (; i < nums.Length; ++i)
                if (condition(nums[i]))
                    return i;

            return i;
        }

        private static int[] GetMins(int[] nums)
        {
            var mins = new int[nums.Length];
            mins[0] = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                mins[i] = Math.Min(mins[i - 1], nums[i]);
            }

            return mins;
        }
    }
}

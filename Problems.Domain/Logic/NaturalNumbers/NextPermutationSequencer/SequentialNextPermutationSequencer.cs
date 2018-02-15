using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.NextPermutationSequencer
{
    public class SequentialNextPermutationSequencer : INextPermutationSequencer
    {
        public void NextPermutation(int[] nums)
        {
            var indexBeforeDescending = GetIndexBeforeDescending(nums);
            if (indexBeforeDescending >= 0)
            {
                var indexOfLastGreaterThan = GetIndexOfLastGreaterThan(nums, nums[indexBeforeDescending]);

                Swap(nums, indexBeforeDescending, indexOfLastGreaterThan);
            }
            Reverse(nums, indexBeforeDescending + 1);
        }

        private static int GetIndexOfLastGreaterThan(int[] nums, int num)
        {
            var i = nums.Length - 1;
            while (i >= 0 && nums[i] <= num)
            {
                --i;
            }
            return i;
        }

        private static int GetIndexBeforeDescending(int[] nums)
        {
            var i = nums.Length - 2;
            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                --i;
            }
            return i;
        }

        private static void Reverse(int[] nums, int start)
        {
            int i = start,
                j = nums.Length - 1;

            while (i < j)
            {
                Swap(nums, i++, j--);
            }
        }

        private static void Swap(int[] nums, int i, int j)
        {
            var num = nums[i];
            nums[i] = nums[j];
            nums[j] = num;
        }
    }
}

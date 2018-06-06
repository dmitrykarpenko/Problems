using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Domain.Logic.Collections.ArrayShuffler
{
    public class FisherYatesArrayShuffler : AbstractArrayShuffler
    {
        private readonly int[] _initialNums;

        private int[] _nums;

        public FisherYatesArrayShuffler(int[] nums)
            : base(nums)
        {
            _initialNums = nums;
            Reset();
        }

        public override int[] Reset()
        {
            _nums = new int[_initialNums.Length];

            for (int i = 0; i < _initialNums.Length; i++)
                _nums[i] = _initialNums[i];

            return _nums;
        }

        public override int[] Shuffle()
        {
            Random r = new Random();

            // last index
            int li = _nums.Length - 1;

            for (int i = 0; i < li; i++)
            {
                int j = r.Next(i, li);
                SwapNums(i, j);
            }

            return _nums;
        }

        private void SwapNums(int i, int j)
        {
            var temp = _nums[i];
            _nums[i] = _nums[j];
            _nums[j] = temp;
        }
    }
}

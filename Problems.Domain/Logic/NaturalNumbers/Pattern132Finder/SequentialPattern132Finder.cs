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

        private static bool Has132Pattern(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {

            }

            return false;
        }
    }
}

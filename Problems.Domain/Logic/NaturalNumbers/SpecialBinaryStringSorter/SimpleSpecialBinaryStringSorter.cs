using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.SpecialBinaryStringSorter
{
    public class SimpleSpecialBinaryStringSorter : ISpecialBinaryStringSorter
    {
        public string MakeLargestSpecialAndRemoveSpaces(string input)
        {
            input = input.Replace(" ", "");
            return MakeLargestSpecial(input);
        }

        public string MakeLargestSpecial(string S)
        {
            return CountLargestSpecialString(S);
        }

        private static string CountLargestSpecialString(string input)
        {
            var mountains = GetMountains(input).ToArray();

            return "";
        }

        private class MountainModel
        {
            public int Index;
            public List<int> Heights = new List<int>();
        }

        private static IEnumerable<MountainModel> GetMountains(string input)
        {
            int index = 0,
                height = 0;
            List<int> heights = null;

            // first char should always be one

            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] == '1')
                {
                    // TODO: start of a mountain could be not only at height == 0
                    if (height == 0)
                    {
                        // start of a mountain
                        index = i;
                        heights = new List<int>();
                    }

                    ++height;
                }
                else // if (input[i] == '0')
                {
                    if (height == 0)
                    {
                        // end of a mountain
                        yield return new MountainModel { Index = index, Heights = heights };
                        heights = null;
                    }
                    else if (height > 0 && input[i - 1] == '1')
                    {
                        heights.Add(height);
                    }

                    --height;
                }
            }
        }
    }
}

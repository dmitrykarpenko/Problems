using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.ParenthesisValidator
{
    public class SequentialParenthesisValidator : IParenthesisValidator
    {
        public bool CheckValidString(string s)
        {
            return AreParenthesisValid(s);
        }

        private static bool AreParenthesisValid(string s)
        {
            // interval of possible "Count('(') - Count(')')"
            int minParenthesisCount = 0,
                maxParenthesisCount = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == '(')
                {
                    // interval shifts right
                    ++minParenthesisCount;
                    ++maxParenthesisCount;
                }
                else if (s[i] == ')')
                {
                    // interval shifts left
                    --minParenthesisCount;
                    --maxParenthesisCount;
                }
                else if (s[i] == '*')
                {
                    // interval widens
                    --minParenthesisCount;
                    ++maxParenthesisCount;
                }

                // if too many ')', return false
                if (maxParenthesisCount < 0)
                    return false;
                // some wildcard should be used to close ')', interval narrows a bit
                if (minParenthesisCount < 0)
                    minParenthesisCount = 0;
            }

            return minParenthesisCount == 0;
        }
    }
}

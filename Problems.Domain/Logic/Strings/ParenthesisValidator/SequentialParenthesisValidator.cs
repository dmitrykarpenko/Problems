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
            int parenthesisCount = 0,
                wildcardCount = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == '(')
                    ++parenthesisCount;
                else if (s[i] == ')')
                    --parenthesisCount;
                else if (s[i] == '*')
                    ++wildcardCount;

                // if too many right or too many left, return false
                if (parenthesisCount + wildcardCount < 0 ||
                    parenthesisCount - wildcardCount > s.Length - 1 - i)
                    return false;
            }

            return wildcardCount - Math.Abs(parenthesisCount) > 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.PostfixStarPatternMatcher
{
    public class PostfixStarPatternMatcher : IPostfixStarPatternMatcher, ILcPostfixStarPatternMatcher
    {
        public bool IsMatch(string text, string pattern)
        {
            if (pattern.Length == 0)
            {
                return text.Length == 0;
            }

            if (pattern.Length == 1)
            {
                return pattern[0] == '.' && text.Length == 1 || pattern == text;
            }

            if (pattern[1] == '*')
            {
                // pattern starts with ...
                // _*

                if (text.Length > 0)
                {
                    if (pattern[0] == '.')
                    {
                        // .*

                        // heve we have the ".*" (i.e. "catch'em all") pattern part,
                        // so we either remove the current letter form text
                        // or remove the ".*" part and try to 
                        // here's where exponential complexity emerges
                        return GocIsMatch(text.Substring(1), pattern) ||
                               GocIsMatch(text, pattern.Substring(2));
                    }
                    else if (text[0] == pattern[0])
                    {
                        // a*

                        // thus, remove first a form text
                        return GocIsMatch(text.Substring(1), pattern);
                    }
                }

                // _*

                // didn't match, so should be removed
                return GocIsMatch(text, pattern.Substring(2));
            }

            // .b or ab

            // remove one char from both pattern and text
            return text.Length > 0 && (pattern[0] == '.' || text[0] == pattern[0]) &&
                   GocIsMatch(text.Substring(1), pattern.Substring(1));
        }

        private Dictionary<Tuple<string, string>, bool> _isMatches =
            new Dictionary<Tuple<string, string>, bool>();

        // Get or calculate IsMatch
        private bool GocIsMatch(string text, string pattern)
        {
            var key = new Tuple<string, string>(text, pattern);
            bool isMatch;
            if (_isMatches.TryGetValue(key, out isMatch))
            {
                return isMatch;
            }

            return _isMatches[key] = IsMatch(text, pattern);
        }
    }
}

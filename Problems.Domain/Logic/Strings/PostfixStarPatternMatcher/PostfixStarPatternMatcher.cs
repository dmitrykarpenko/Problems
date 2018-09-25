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
            _text = text;
            _pattern = pattern;

            _isMatches.Clear();

            return IsMatchRecursive(0, 0);
        }

        private string _text;
        private string _pattern;

        private int TextLength(int it) => _text.Length - it;
        private int PatternLength(int ip) => _pattern.Length - ip;

        private char TextChar(int it) => _text[it];
        private char PatternChar(int ip) => _pattern[ip];

        private bool CharsMatch(int it, int ip) =>
            PatternChar(ip) == '.' || TextChar(it) == PatternChar(ip);

        /// <param name="it"> current first text index </param>
        /// <param name="ip"> current first pattern index </param>
        private bool IsMatchRecursive(int it, int ip)
        {
            if (PatternLength(ip) == 0)
            {
                return TextLength(it) == 0;
            }

            if (PatternLength(ip) == 1)
            {
                return TextLength(it) == 1 && CharsMatch(it, ip);
            }

            if (PatternChar(ip + 1) == '*')
            {
                // pattern starts with ...
                // _*

                if (TextLength(it) > 0 && CharsMatch(it, ip))
                {
                    // .* or a*

                    // here we have either "a*" or ".*" (i.e. "catch'em all") pattern part, so we:
                    //  - either remove the current letter form text;
                    //  - or remove the "_*" part and try to match the next chars;
                    // here's where exponential complexity emerges,
                    // thus, use memoization
                    return GocIsMatch(it + 1, ip) ||
                           GocIsMatch(it, ip + 2);
                }

                // _*

                // either text is empty or _* didn't match, so should be removed
                return GocIsMatch(it, ip + 2);
            }

            // .b or ab

            // remove one char from both pattern and text
            return TextLength(it) > 0 && CharsMatch(it, ip) &&
                   GocIsMatch(it + 1, ip + 1);
        }

        private Dictionary<Tuple<int, int>, bool> _isMatches =
            new Dictionary<Tuple<int, int>, bool>();

        // get or calculate IsMatch
        private bool GocIsMatch(int it, int ip)
        {
            var key = new Tuple<int, int>(it, ip);
            bool isMatch;
            if (_isMatches.TryGetValue(key, out isMatch))
            {
                return isMatch;
            }

            return _isMatches[key] = IsMatchRecursive(it, ip);
        }

        // for debug:

        private string CurrentText(int it) => _text.Substring(it);
        private string CurrentPattern(int ip) => _pattern.Substring(ip);
    }
}

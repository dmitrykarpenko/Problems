using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.PatternMatcher
{
    /// <summary>
    /// Implement wildcard pattern matching with support for '?' and '*'.
    /// '?' Matches any single character.
    /// '*' Matches any sequence of characters (including the empty sequence).
    /// The matching should cover the entire input string (not partial).
    /// The function prototype should be:
    /// bool isMatch(const char* s, const char* p)
    /// Some examples:
    /// isMatch("aa","a") → false
    /// isMatch("aa","aa") → true
    /// isMatch("aaa","aa") → false
    /// isMatch("aa", "*") → true
    /// isMatch("aa", "a*") → true
    /// isMatch("ab", "?*") → true
    /// isMatch("aab", "c*a*b") → false
    /// </summary>
    public interface IPatternMatcher
    {
        bool IsMatch(string input, string pattern);
    }
}

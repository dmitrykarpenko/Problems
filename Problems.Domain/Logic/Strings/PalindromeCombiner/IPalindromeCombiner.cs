using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.PalindromeCombiner
{
    public interface IPalindromeCombiner
    {
        /// <summary>
        /// Given a list of unique words, find all pairs of distinct indices (i, j) in the given list,
        /// so that the concatenation of the two words, i.e. words[i] + words[j] is a palindrome.
        /// 
        /// Example 1:
        /// Given words = ["bat", "tab", "cat"]
        /// Return[[0, 1], [1, 0]]
        /// The palindromes are["battab", "tabbat"]
        /// 
        /// Example 2:
        /// Given words = ["abcd", "dcba", "lls", "s", "sssll"]
        /// Return[[0, 1], [1, 0], [3, 2], [2, 4]]
        /// The palindromes are["dcbaabcd", "abcddcba", "slls", "llssssll"]
        /// </summary>
        /// <param name="words">Given words</param>
        /// <returns>List of pairs</returns>
        IList<IList<int>> PalindromePairs(string[] words);
    }
}

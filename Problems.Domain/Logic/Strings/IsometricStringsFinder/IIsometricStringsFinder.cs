using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.IsometricStringsFinder
{
    
    public interface IIsometricStringsFinder
    {
        /// <summary>
        /// https://leetcode.com/problems/substring-with-concatenation-of-all-words/description/
        /// 30. Substring with Concatenation of All Words
        /// 
        /// You are given a string, s, and a list of words, words, that are all of the same length.
        /// Find all starting indices of substring(s) in s that is a concatenation of each word in words exactly once and without any intervening characters.
        /// 
        /// For example, given:
        /// s: "barfoothefoobarman"
        /// words: ["foo", "bar"]
        /// You should return the indices: [0,9].
        /// (order does not matter).
        /// </summary>
        /// <param name="s">input string</param>
        /// <param name="words">an array of words</param>
        /// <returns>A list of indices</returns>
        IList<int> FindSubstring(string s, string[] words);
    }
}

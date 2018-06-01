using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.AnagramSubstringSearcher
{
    public interface ILcAnagramSubstringSearcher
    {
        /// <summary>
        /// https://leetcode.com/problems/find-all-anagrams-in-a-string/description/
        /// 438. Find All Anagrams in a String
        /// 
        /// Given a string s and a non-empty string p,
        /// find all the start indices of p's anagrams in s.
        /// 
        /// Strings consists of lowercase English letters only
        /// and the length of both strings s and p will not be larger than 20,100.
        /// 
        /// (English letters, thus their number is restricted!)
        /// 
        /// The order of output does not matter.
        /// 
        /// ---
        /// Example 1:
        /// 
        /// Input:
        /// s: "cbaebabacd" p: "abc"
        /// 
        /// Output:
        /// [0, 6]
        /// 
        /// Explanation:
        /// The substring with start index = 0 is "cba", which is an anagram of "abc".
        /// The substring with start index = 6 is "bac", which is an anagram of "abc".
        /// 
        /// ---
        /// Example 2:
        /// 
        /// Input:
        /// s: "abab" p: "ab"
        /// 
        /// Output:
        /// [0, 1, 2]
        /// 
        /// Explanation:
        /// The substring with start index = 0 is "ab", which is an anagram of "ab".
        /// The substring with start index = 1 is "ba", which is an anagram of "ab".
        /// The substring with start index = 2 is "ab", which is an anagram of "ab".
        /// 
        /// </summary>
        /// <param name="s">Text to search patterns in, can be large</param>
        /// <param name="p">
        /// Pattern to search it and it's permutations
        /// (i.e. patterns) in <paramref name="s"/>
        /// </param>
        /// <returns>An array of first indices of found permutations' occurrences</returns>
        IList<int> FindAnagrams(string s, string p);
    }
}

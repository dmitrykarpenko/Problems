using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.AnagramSubstringSearcher
{
    public interface IAnagramSubstringSearcher
    {
        /// <summary>
        /// https://www.geeksforgeeks.org/anagram-substring-search-search-permutations/
        /// Anagram Substring Search (Or Search for all permutations)
        /// 
        /// Given a text txt[0..n-1] and a pattern pat[0..m-1],
        /// write a function search(char pat[], char txt[])
        /// that prints all occurrences of pat[]
        /// and its permutations (or anagrams) in txt[].
        /// You may assume that n > m.
        /// 
        /// Expected time complexity is O(n).
        /// 
        /// Examples:
        /// 
        /// 1) Input:  txt[] = "BACDGABCDA"  pat[] = "ABCD"
        ///    Output: [0, 5, 6]
        ///    i.e. found at indices 0, 5, 6
        ///
        /// 2) Input: txt[] =  "AAABABAA" pat[] = "AABA"
        ///    Output: [0, 1, 4]
        ///    i.e. found at indices 0, 1, 4
        /// </summary>
        /// <param name="txt">Text to search patterns in, can be large</param>
        /// <param name="pat">
        /// Pattern to search it and it's permutations
        /// (i.e. patterns) in <paramref name="txt"/>
        /// </param>
        /// <returns>An array of first indices of found permutations' occurrences</returns>
        int[] GetIndices(string txt, string pat);
    }
}

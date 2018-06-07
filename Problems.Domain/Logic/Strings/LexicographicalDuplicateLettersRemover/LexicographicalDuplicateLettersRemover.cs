using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.LexicographicalDuplicateLettersRemover
{
    public class LexicographicalDuplicateLettersRemover : ILexicographicalDuplicateLettersRemover
    {
        public string RemoveDuplicateLetters(string s)
        {
            if (s == null)
                return null;

            return RemoveDuplicateLettersRecursive(s);
        }

        /// <summary>
        /// As we have less or equal to 26 distinct chars in a string;
        /// 
        /// thus, the recursion will be called at most 26 times
        /// and all the operations in this function are O(n)
        /// (n equals to the current string's length);
        /// 
        /// it also takes O(n) memory on each iterration, which
        /// can be freed (garbage-collected) starting from
        /// the next call recursive call; so, also O(n)
        /// (at each moment of time)
        /// </summary>
        /// <param name="s">the current string</param>
        /// <returns>
        /// a lexicographically first string without duplicates
        /// for the current string
        /// </returns>
        private string RemoveDuplicateLettersRecursive(string s)
        {
            if (s.Length == 0)
                return "";

            // counts of chars by number (a's at 0, b's at 1, etc.); O(n)
            int[] counts = GetCharCounts(s);

            // the index of the smallest s[i]; O(n)
            int smi = 0;

            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] < s[smi])
                    smi = i;
                if (--counts[CToI(s[i])] == 0)
                    break;
            }

            // at this point found smi - the index of the smallest char in s
            // such that there is at least one of each greater (than s[smi]) char
            // in the substring to the right of smi

            // leave only the substring to the right of smi; O(n)
            string sNext = s.Substring(smi + 1);

            // current smallest char
            char csc = s[smi];

            // after this, DistinctChars(sNext) == DistinctChars(s) - 1; O(n)
            RemoveChar(ref sNext, csc);

            // further recursive calls; O(DistinctChars(sNext) * n) <
            // < { as DistinctChars(sNext) < 26 } < O(26 * n) == O(n)
            return csc + RemoveDuplicateLettersRecursive(sNext);
        }

        private static int[] GetCharCounts(string s)
        {
            int[] counts = new int[26];
            
            for (int i = 0; i < s.Length; ++i)
                ++counts[CToI(s[i])];

            return counts;
        }

        private static void RemoveChar(ref string sNext, char csc)
        {
            // remove the current smallest char
            // from the substring to the right of smi, O(n)
            sNext = sNext.Replace(csc.ToString(), "");
        }

        // char to int
        private static int CToI(char c) => c - 'a';
    }
}

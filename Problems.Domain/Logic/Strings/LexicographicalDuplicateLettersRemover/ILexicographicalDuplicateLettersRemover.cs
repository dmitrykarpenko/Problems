using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.LexicographicalDuplicateLettersRemover
{
    public interface ILexicographicalDuplicateLettersRemover
    {
        /// <summary>
        /// https://leetcode.com/problems/remove-duplicate-letters/description/
        /// 316. Remove Duplicate Letters
        /// 
        /// Given a string which contains only lowercase letters,
        /// remove duplicate letters so that every letter appear once and only once.
        /// You must make sure your result is the smallest in lexicographical order
        /// among all possible results.
        /// 
        /// Example 1:
        /// 
        /// Input: "bcabc"
        /// Output: "abc"
        /// 
        /// Example 2:
        /// 
        /// Input: "cbacdcbc"
        /// Output: "acdb"
        /// </summary>
        /// <param name="s">Input string</param>
        /// <returns>String of lexicographically first distinct letters</returns>
        string RemoveDuplicateLetters(string s);
    }
}

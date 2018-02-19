using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.WordBreakChecker
{
    public interface IWordBreakChecker
    {
        /// <summary>
        /// Given a non-empty string s and a dictionary wordDict containing a list of non-empty words,
        /// determine if s can be segmented into a space-separated sequence of one or more dictionary words.
        /// You may assume the dictionary does not contain duplicate words.
        /// 
        /// For example, given
        /// s = "leetcode",
        /// dict = ["leet", "code"].
        /// 
        /// Return true because "leetcode" can be segmented as "leet code".
        /// </summary>
        /// <param name="s">given string (to break)</param>
        /// <param name="wordDict">given list of words (to break s on)</param>
        /// <returns></returns>
        bool WordBreak(string s, IList<string> wordDict);
    }
}

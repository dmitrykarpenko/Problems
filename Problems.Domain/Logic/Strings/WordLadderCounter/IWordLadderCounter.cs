using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.WordLadderCounter
{
    public interface IWordLadderCounter
    {
        /// <summary>
        /// https://leetcode.com/problems/word-ladder/description/
        /// 127. Word Ladder
        /// 
        /// Given two words (beginWord and endWord), and a dictionary's word list, find the length of shortest transformation sequence from beginWord to endWord, such that:
        /// 
        /// Only one letter can be changed at a time.
        /// Each transformed word must exist in the word list.Note that beginWord is not a transformed word.
        /// For example,
        /// 
        /// Given:
        /// beginWord = "hit"
        /// endWord = "cog"
        /// wordList = ["hot", "dot", "dog", "lot", "log", "cog"]
        /// As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
        /// return its length 5.
        /// 
        /// Note:
        /// Return 0 if there is no such transformation sequence.
        /// All words have the same length.
        /// All words contain only lowercase alphabetic characters.
        /// You may assume no duplicates in the word list.
        /// You may assume beginWord and endWord are non-empty and are not the same.
        /// </summary>
        /// <param name="beginWord">initial word</param>
        /// <param name="endWord">final word</param>
        /// <param name="wordList">ladder "stairs"</param>
        /// <returns></returns>
        int LadderLength(string beginWord, string endWord, IList<string> wordList);
    }
}

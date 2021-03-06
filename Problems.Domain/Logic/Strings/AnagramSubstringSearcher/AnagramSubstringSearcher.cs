﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.AnagramSubstringSearcher
{
    public class AnagramSubstringSearcher : IAnagramSubstringSearcher, ILcAnagramSubstringSearcher
    {
        /// <summary> <see cref="GetIndices"/> </summary>
        public IList<int> FindAnagrams(string s, string p)
        {
            FillFoundIndices(s, p);
            return _foundIndices;
        }

        /// <summary>
        /// Searches for all the <paramref name="pat"/>
        /// permutations' occurrences in <paramref name="txt"/>
        /// </summary>
        /// <param name="txt">Text to search permutations in</param>
        /// <param name="pat">Pattern</param>
        /// <returns>An array of <see cref="_foundIndices"/></returns>
        public int[] GetIndices(string txt, string pat)
        {
            FillFoundIndices(txt, pat);
            return _foundIndices.ToArray();
        }

        public void FillFoundIndices(string txt, string pat)
        {
            Initialize();

            if (txt == null || pat == null)
                return;

            int txtL = txt.Length;
            int patL = pat.Length;

            if (txtL == 0 || patL == 0 || txtL < patL)
                return;

            // Count char counts for the first text window and the pattern
            for (int i = 0; i < patL; i++)
            {
                ++_twCounts[txt[i] % _numOfChars];
                ++_pCounts[pat[i] % _numOfChars];
            }

            /// The first index of a current txt window (here's why Tw)
            int iTwFirst;
            // The index next to the last index of a current txt window ("over the end")
            int iTwEnd;

            // Traverse through teh remaining characters of the pattern
            for (iTwEnd = patL; iTwEnd < txtL; ++iTwEnd)
            {
                iTwFirst = iTwEnd - patL;

                // Compare counts of current window
                // of text with counts of pattern[]
                AddFoundIndexIfPatternAndTextWindowCountsEqual(iTwFirst);

                // Add the next window's last character to the next window
                ++_twCounts[txt[iTwEnd] % _numOfChars];

                // Remove the first character of the current window
                --_twCounts[txt[iTwFirst] % _numOfChars];
            }

            // last text window's first index
            iTwFirst = txtL - patL;

            // Check for the last text window
            AddFoundIndexIfPatternAndTextWindowCountsEqual(iTwFirst);
        }

        /// <summary>
        /// Assuming that the alphabet size is fixed which is typically true
        /// as we have the maximum of 256 possible characters in ASCII.
        /// We can achieve O(n) time complexity under this assumption.
        /// </summary>
        private const int _numOfChars = 256;

        /// <summary> A list of the values that <see cref="GetIndices"/> returns </summary>
        private List<int> _foundIndices;
        /// <summary> Stores counts of all the characters of the pattern </summary>
        private char[] _pCounts;
        /// <summary> Stores counts of a current window of the text </summary>
        private char[] _twCounts;

        private void Initialize()
        {
            _foundIndices = new List<int>();
            _pCounts = new char[_numOfChars];
            _twCounts = new char[_numOfChars];
        }

        private void AddFoundIndexIfPatternAndTextWindowCountsEqual(int iTwFirst)
        {
            // As we are searching for anagrams, we don't really care of the chars order;
            // if the quantities of each char in the pattern (_pCounts) and the text window (_twCounts)
            // are equal, then the text window substring can be build form the letters of the pattern
            if (Compare(_pCounts, _twCounts))
                _foundIndices.Add(iTwFirst);
        }

        /// <summary>
        /// True is <paramref name="firsts"/> and <paramref name="seconds"/>
        /// are the same, false otherwise.
        /// Runs in O(1) time (i.e. constant time), <see cref="_numOfChars"/> summary.
        /// </summary>
        /// <param name="firsts">First array</param>
        /// <param name="seconds">Second array</param>
        /// <returns></returns>
        private static bool Compare(char[] firsts, char[] seconds)
        {
            for (int i = 0; i < _numOfChars; ++i)
                if (firsts[i] != seconds[i])
                    return false;
            return true;
        }
    }
}

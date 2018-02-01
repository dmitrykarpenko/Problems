using System;
using System.Collections.Generic;

namespace Problems.Domain.Logic.Strings.PatternMatcher
{
    public class SplittingPatternMatcher : IPatternMatcher
    {
        private const char sequenceWildcard = '*';
        private const char charWildcard = '?';

        public bool IsMatch(string input, string pattern)
        {
            if (input == null || pattern == null)
                throw new ArgumentNullException();
            if (input == pattern)
                return true;
            if (input != string.Empty && pattern == string.Empty)
                return false;

            var patternParts = pattern.Split(sequenceWildcard);
            patternParts = RemoveEmpty(patternParts);

            // pattern only contains sequenceWildcards
            if (pattern != string.Empty && patternParts.Length == 0)
                return true;

            var anyStart = pattern[0] == sequenceWildcard;
            var anyEnd = pattern[pattern.Length - 1] == sequenceWildcard;

            return IsMatchRecursive(input, 0,
                patternParts, 0,
                anyStart, anyEnd);
        }

        /// <param name="patternParts">each patternPart will not contain sequenceWildcard (*) - only charWildcard (?)</param>
        private static bool IsMatchRecursive(string input, int firstInputCharIndex,
            string[] patternParts, int firstPatternPartIndex, 
            bool anyStart, bool anyEnd)
        {
            if (firstPatternPartIndex == patternParts.Length)
                return anyEnd || firstInputCharIndex == input.Length;

            var firstPatternPart = patternParts[firstPatternPartIndex];

            var indices = FindIndices(input, firstInputCharIndex, firstPatternPart, anyStart ? int.MaxValue : 1);

            foreach (var index in indices)
            {
                if (!anyStart && index > firstInputCharIndex)
                    return false;

                var isMatch = IsMatchRecursive(input, index + firstPatternPart.Length,
                    patternParts, firstPatternPartIndex + 1,
                    true, anyEnd);

                if (isMatch)
                    return true;
            }

            return false;
        }

        private static int[] FindIndices(string input, int firstInputCharIndex, string patternPart, int maxIndicesCount)
        {
            var indices = new List<int>();
            for (var inputCharIndex = firstInputCharIndex; inputCharIndex < input.Length; ++inputCharIndex)
            {
                if (IsExactMatch(input, inputCharIndex, patternPart))
                    indices.Add(inputCharIndex);
                if (indices.Count == maxIndicesCount)
                    return indices.ToArray();
            }
            return indices.ToArray();
        }

        private static bool IsExactMatch(string input, int firstInputCharIndex, string patternPart)
        {
            var nextAfterLastInputCharIndex = firstInputCharIndex + patternPart.Length;
            if (nextAfterLastInputCharIndex > input.Length)
                return false;

            for (var inputCharIndex = firstInputCharIndex; inputCharIndex < nextAfterLastInputCharIndex; ++inputCharIndex)
            {
                var patternIndex = inputCharIndex - firstInputCharIndex;
                if (patternPart[patternIndex] != input[inputCharIndex] &&
                    patternPart[patternIndex] != charWildcard)
                    return false;
            }

            return true;
        }

        // usually it's done with Linq - implemented just to be less language-specific
        private static string[] RemoveEmpty(string[] patternParts)
        {
            var nonEmptyPatternParts = new List<string>();
            for (int i = 0; i < patternParts.Length; i++)
                if (!string.IsNullOrEmpty(patternParts[i]))
                    nonEmptyPatternParts.Add(patternParts[i]);
            
            return nonEmptyPatternParts.ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.PalindromeCombiner
{
    public class MatchingPalindromeCombiner : IPalindromeCombiner
    {
        public IList<IList<int>> PalindromePairs(string[] words)
        {
            var palindromePairIndices = GetPalindromePairIndices(words);
            var palindromePairs = palindromePairIndices
                .Select(p => (IList<int>)new List<int> { p.Item1, p.Item2 })
                .ToList();
            return palindromePairs;
        }

        private static IEnumerable<(int, int)> GetPalindromePairIndices(string[] words)
        {
            var reversedWords = words.Select(w => new string(w.Reverse().ToArray())).ToArray();
            for (int i = 0; i < words.Length; ++i)
                for (int ir = 0; ir < reversedWords.Length; ++ir)
                    if (i != ir && IsPalindromePair(words[i], reversedWords[ir]))
                        yield return (i, ir);
        }

        public static bool IsPalindromePair(string word, string otherReversedWord)
        {
            var minLength = Math.Min(word.Length, otherReversedWord.Length);
            for (int i = 0; i < minLength; i++)
                if (word[i] != otherReversedWord[i])
                    return false;

            if (word.Length == otherReversedWord.Length)
                return true;
            if (word.Length > otherReversedWord.Length)
                return IsPalindrome(word.Substring(otherReversedWord.Length));
            if (otherReversedWord.Length > word.Length)
                return IsPalindrome(otherReversedWord.Substring(word.Length));

            return true;
        }

        public static bool IsPalindrome(string input)
        {
            for (int i = 0; i < input.Length / 2; ++i)
                if (input[i] != input[input.Length - 1 - i])
                    return false;

            return true;
        }
    }
}

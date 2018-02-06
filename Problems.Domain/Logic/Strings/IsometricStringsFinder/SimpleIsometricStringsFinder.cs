using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.IsometricStringsFinder
{
    public class SimpleIsometricStringsFinder : IIsometricStringsFinder
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            return FindSubstringIndices(s, words).ToList();
        }

        private int _wordLength;
        private Dictionary<string, WordInfo> _words;

        private class WordInfo
        {
            //public string Word;
            public int InitialAvailable;
            public int Available;
        }

        private IEnumerable<int> FindSubstringIndices(string input, string[] words)
        {
            if (input == null || words == null || words.Length == 0)
            {
                yield break;
            }
            if (input.Length == 0)
            {
                for (int i = 0; i < words.Length; i++)
                    if (words[i] != string.Empty)
                        yield break;

                yield return 0;
                yield break;
            }

            InitializeWords(words);

            var wordCombinationLength = (_wordLength = words[0].Length) * words.Length;
            var iMax = input.Length - wordCombinationLength;

            for (int i = 0; i <= iMax; ++i)
            {
                var inputPart = input.Substring(i, wordCombinationLength);
                if (IsCombinationOfWords(inputPart))
                {
                    yield return i;
                }
            }
        }

        private void InitializeWords(string[] words)
        {
            _words = new Dictionary<string, WordInfo>();
            foreach (var word in words)
            {
                if (_words.TryGetValue(word, out WordInfo wordInfo))
                    ++wordInfo.Available;
                else
                    _words.Add(word, new WordInfo { Available = 1 });
            }
            foreach (var pair in _words)
            {
                pair.Value.InitialAvailable = pair.Value.Available;
            }
        }

        private bool IsCombinationOfWords(string inputPart)
        {
            foreach (var word in _words)
                word.Value.Available = word.Value.InitialAvailable;

            for (int i = 0; i < inputPart.Length; i += _wordLength)
            {
                var wordCandidate = inputPart.Substring(i, _wordLength);
                WordInfo wordCandidateInfo;
                if (!_words.TryGetValue(wordCandidate, out wordCandidateInfo))
                {
                    return false;
                }
                if (wordCandidateInfo.Available == 0)
                {
                    return false;
                }
                --wordCandidateInfo.Available;
            }
            return true;
        }
    }
}

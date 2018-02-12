using Problems.Domain.Logic.Trees.Trie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.PrefixSuffixFinder
{
    public class WordFilter : IPrefixSuffixFinder
    {
        private string _prefix;
        private string _reversedSuffix;

        private readonly Trie<WordInfo> _trie;
        private readonly Trie<WordInfo> _trieOfReversed;

        public WordFilter(string[] words)
        {
            _trie = new Trie<WordInfo>();
            _trieOfReversed = new Trie<WordInfo>();


            for (int i = 0; i < words.Length; ++i)
            {
                Func<string, WordInfo> getNodeInfo = s => WordInfo.Create(words[i], i);

                _trie.Insert(words[i], getNodeInfo);

                var reversedWord = new string(words[i].Reverse().ToArray());
                _trieOfReversed.Insert(reversedWord, getNodeInfo);
            }
        }

        public int F(string prefix, string suffix)
        {
            if (prefix == null || suffix == null)
                return -1;

            _prefix = prefix;
            _reversedSuffix = new string(suffix.Reverse().ToArray());

            return GetWordIndex();
        }


        private class WordInfo
        {
            public string OriginalWord;
            public int Weight;

            public override bool Equals(object obj)
            {
                var wordInfo = obj as WordInfo;
                if (wordInfo == null)
                    return false;

                return OriginalWord == wordInfo.OriginalWord && Weight == wordInfo.Weight;
            }

            public override int GetHashCode() => OriginalWord.GetHashCode() ^ Weight.GetHashCode();
            public override string ToString() => $"{nameof(OriginalWord)}: {OriginalWord}, {nameof(Weight)}: {Weight}";

            public static WordInfo Create(string originalWord, int index)
            {
                return new WordInfo
                {
                    OriginalWord = originalWord,
                    Weight = index,
                };
            }
        }

        public int GetWordIndex()
        {
            var prefixWords = _trie.GetTerminalNodes(_prefix)
                .Select(ni => ni.Info)
                .OrderByDescending(wi => wi.Weight);

            var suffixWords = _trieOfReversed.GetTerminalNodes(_reversedSuffix)
                .Select(ni => ni.Info)
                .OrderByDescending(wi => wi.Weight);

            var wordInfo = prefixWords.Intersect(suffixWords).FirstOrDefault();
            if (wordInfo == null)
                return -1;

            return wordInfo.Weight;
        }
    }
}

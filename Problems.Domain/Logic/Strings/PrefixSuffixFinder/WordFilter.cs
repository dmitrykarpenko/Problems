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
        private readonly string[] _words;

        private readonly Trie<WordInfo> _trie;
        private readonly Trie<WordInfo> _trieOfReversed;

        public WordFilter(string[] words)
        {
            _words = words;


            _trie = new Trie<WordInfo>();
            _trie.InsertRange(_words, WordInfo.Create);


            var reversedWords = _words
                .Select(w => new
                {
                    ReversedWord = new string(w.Reverse().ToArray()),
                    OriginalWord = w,
                })
                .ToDictionary(x => x.ReversedWord, x => x.OriginalWord);

            _trieOfReversed = new Trie<WordInfo>();
            _trieOfReversed.InsertRange(reversedWords.Keys.ToArray(), (s, i) => WordInfo.Create(reversedWords[s], i));
        }

        public int F(string prefix, string suffix)
        {
            return GetWordIndex(prefix, suffix);
        }


        class WordInfo
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

        public int GetWordIndex(string prefix, string suffix)
        {
            var prefixWords = _trie.GetStartWith(prefix)
                .Select(ni => ni.Info)
                .OrderByDescending(wi => wi.Weight);

            var suffixWords = _trieOfReversed.GetStartWith(suffix)
                .Select(ni => ni.Info)
                .OrderByDescending(wi => wi.Weight);

            var wordInfo = prefixWords.Intersect(suffixWords).FirstOrDefault();
            if (wordInfo == null)
                return -1;

            return wordInfo.Weight;
        }
    }
}

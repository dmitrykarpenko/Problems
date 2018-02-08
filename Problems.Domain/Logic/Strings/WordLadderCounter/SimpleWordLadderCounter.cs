using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.WordLadderCounter
{
    public class SimpleWordLadderCounter : IWordLadderCounter
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            return CountLadderLength(beginWord, endWord, wordList);
        }

        private class WordInfo
        {
            public string Word;
            public int InitialDifference;
            public int FinalDifference;
        }

        private int _count = int.MaxValue;

        private int CountLadderLength(string initial, string final, IList<string> words)
        {
            var wordInfos = words
                .Select(w => new WordInfo
                {
                    Word = w,
                    InitialDifference = CountDifferentLetters(w, initial),
                    FinalDifference = CountDifferentLetters(w, final),
                })
                .OrderBy(w => w.InitialDifference + w.FinalDifference)
                .ThenBy(w => Math.Abs(w.InitialDifference - w.FinalDifference))
                .ToArray();

            foreach (var mediatorCandidateInfo in wordInfos)
            {
                if (mediatorCandidateInfo.FinalDifference + mediatorCandidateInfo.InitialDifference > _count)
                    break;

                var closestFinalDifference = CountClosestTargetDifference(
                    wordInfos,
                    mediatorCandidateInfo,
                    final,
                    w => w.FinalDifference);

                if (closestFinalDifference > 0)
                    continue;

                var closestInitialDifference = CountClosestTargetDifference(
                    wordInfos,
                    mediatorCandidateInfo,
                    initial,
                    w => w.InitialDifference);

                if (closestInitialDifference > 1)
                    continue;

                var countCandidate =
                    mediatorCandidateInfo.FinalDifference +
                    closestFinalDifference +
                    mediatorCandidateInfo.InitialDifference
                    +
                    closestInitialDifference
                    + 1
                    ;

                if (_count > countCandidate)
                    _count = countCandidate;
            }

            return _count < int.MaxValue ? _count : 0;
        }

        private static int CountClosestTargetDifference(
            IEnumerable<WordInfo> wordInfos,
            WordInfo mediatorCandidateInfo,
            string target,
            Func<WordInfo, int> getTargetDifference)
        {
            var currentTargetDifference = getTargetDifference(mediatorCandidateInfo);
            if (currentTargetDifference == 0)
                return 0;

            var nextTargetDifference = currentTargetDifference - 1;

            var nextWordInfos = wordInfos
                .Where(wi => getTargetDifference(wi) <= nextTargetDifference);
            var nextWordInfoCandidates = nextWordInfos
                .Where(wi => getTargetDifference(wi) == nextTargetDifference);

            foreach (var nextWordInfoCandidate in nextWordInfoCandidates)
            {
                currentTargetDifference = CountClosestTargetDifference(
                    nextWordInfos,
                    nextWordInfoCandidate,
                    target,
                    getTargetDifference);

                if (currentTargetDifference == 0)
                    return 0;
            }

            return currentTargetDifference;
        }

        private static int CountDifferentLetters(string firstChars, string secondChars)
        {
            // All words have the same length, so no length equality check
            var count = 0;
            for (int i = 0; i < firstChars.Length; ++i)
            {
                if (firstChars[i] != secondChars[i])
                    ++count;
            }
            return count;
        }

        //private static void AddToIth(List<List<string>> layeredWords, int i, string item)
        //{
        //    if (i >= layeredWords.Count)
        //        for (int j = layeredWords.Count; j <= i; ++j)
        //        {
        //            layeredWords.Add(new List<string>());
        //        }

        //    layeredWords[i].Add(item);
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.WordBreakChecker
{
    public class SimpleWordBreakChecker : IWordBreakChecker
    {
		private readonly Dictionary<int, Dictionary<string, WordInfo>> _words =
			new Dictionary<int, Dictionary<string, WordInfo>>();
		
        public bool WordBreak(string s, IList<string> wordDict)
        {
			InitializeWords(wordDict);
            return IsWordBreakPossible(s);
        }
		
		private class WordInfo
		{
			public string Word;
			public bool IsUsed;
		}
		
		private bool IsWordBreakPossible(string input)
		{
			for (int i = 1; i < input.Length; ++i)
			{
				//...
			}
            return false;
		}
		
		private bool FindBeginning(string input, int length, out string word)
		{
			word = input.Substring(0, length);
			
			Dictionary<string, WordInfo> current;
			if (! _words.TryGetValue(length, out current))
				return false;

			WordInfo wordInfo;
			if (! current.TryGetValue(word, out wordInfo))
				return false;
			
			wordInfo.IsUsed = true;
			return true;
		}
		
		private void InitializeWords(IList<string> words)
		{
			foreach (var word in words)
			{
				Dictionary<string, WordInfo> current;
				if (_words.TryGetValue(word.Length, out current))
				{
					current.Add(word, new WordInfo { Word = word, IsUsed = false });
				}
				else
				{
					_words[word.Length] = new Dictionary<string, WordInfo>
						{ { word, new WordInfo { Word = word, IsUsed = false } } };
				}
			}
		}
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.PrefixSuffixFinder
{
    public class WordFilter : IPrefixSuffixFinder
    {
        private readonly string[] _words;

        public WordFilter(string[] words)
        {
            _words = words;
        }

        public int F(string prefix, string suffix)
        {
            return GetWordIndex(_words, prefix, suffix);
        }

        //class CharNode
        //{
        //    public char Value;
        //    public SortedList<char, CharNode> Children = new SortedList<char, CharNode>();
        //    public int? Weight;
        //}

        //private CharNode GetTrie(string[] words)
        //{
            
        //    for (int i = 0; i < words.Length; ++i)
        //    {

        //    }
        //}

        //private static void AddWord(CharNode root, string word)
        //{
        //    foreach (var c in word)
        //    {
        //        CharNode cNode;
        //        root.Children.TryGetValue(c, out cNode);
        //        if ()
        //    }
        //}

        //class WordInfo
        //{
        //    //public string Word;
        //    public int Weight;
        //}

        public static int GetWordIndex(string[] words, string prefix, string suffix)
        {
            //words
            //    .Where(w => w.StartsWith(prefix) && w.EndsWith(prefix))
            //    .
            return 0;
        }
    }
}
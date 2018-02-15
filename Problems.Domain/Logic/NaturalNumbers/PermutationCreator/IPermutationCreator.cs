using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.PermutationCreator
{
    public interface IPermutationCreator
    {
        /// <summary>
        /// https://leetcode.com/problems/permutation-sequence/description/
        /// 60. Permutation Sequence
        /// 
        /// The set [1,2,3,…,n] contains a total of n! unique permutations.
        /// 
        /// By listing and labeling all of the permutations in order,
        /// We get the following sequence(ie, for n = 3) :
        /// "123"
        /// "132"
        /// "213"
        /// "231"
        /// "312"
        /// "321"
        /// Given n and k, return the kth permutation sequence.
        /// Note: Given n will be between 1 and 9 inclusive.
        /// </summary>
        /// <param name="n">max number in a set</param>
        /// <param name="k">wanted permutation number</param>
        /// <returns></returns>
        string GetPermutation(int n, int k);
    }
}

using Problems.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.DigitRemover
{
    public class StringNaturalNumber : IComparable<StringNaturalNumber>, IComparable
    {
        public StringNaturalNumber(char[] naturalNumber, params int[] excludedIndices)
        {
            ExcludedIndices = excludedIndices;

            var sourceIndex = 0;
            while (sourceIndex < naturalNumber.Length && naturalNumber[sourceIndex] == '0')
                ++sourceIndex;
            if (sourceIndex == 0)
            {
                NaturalNumber = naturalNumber;
            }
            else
            {
                var length = naturalNumber.Length - sourceIndex;
                NaturalNumber = new char[length];
                Array.Copy(naturalNumber, sourceIndex, NaturalNumber, 0, length);
            }
            EffectiveLength = NaturalNumber.Length - ExcludedIndices.Length;
        }

        public char[] NaturalNumber { get; }
        public int[] ExcludedIndices { get; }
        public int[] EffectiveIndices { get; }
        public int EffectiveLength { get; }

        public int CompareTo(object obj)
        {
            return CompareTo((StringNaturalNumber)obj);
        }

        public int CompareTo(StringNaturalNumber other)
        {
            if (EffectiveLength > other.EffectiveLength)
                return 1;
            if (EffectiveLength < other.EffectiveLength)
                return -1;
            int iOther = 0;
            for (int i = 0; i < NaturalNumber.Length; i++)
            {
                while (ExcludedIndices.Contains(i))
                    ++i;
                if (i >= NaturalNumber.Length)
                    break;
                while (other.ExcludedIndices.Contains(iOther))
                    ++iOther;
                if (iOther >= other.NaturalNumber.Length)
                    break;

                if (NaturalNumber[i] > other.NaturalNumber[iOther])
                    return 1;
                if (NaturalNumber[i] < other.NaturalNumber[iOther])
                    return -1;

                ++iOther;
            }
            return 0;
        }

        public override string ToString()
        {
            return new string(GenericUtil.RemoveAt(NaturalNumber, ExcludedIndices).ToArray());
        }
    }
}

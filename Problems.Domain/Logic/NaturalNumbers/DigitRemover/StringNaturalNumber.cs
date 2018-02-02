using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.DigitRemover
{
    public class StringNaturalNumber : IComparable<StringNaturalNumber>, IComparable
    {
        public StringNaturalNumber(char[] naturalNumber)
        {
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
        }

        public char[] NaturalNumber { get; }

        public int CompareTo(object obj)
        {
            return CompareTo((StringNaturalNumber)obj);
        }

        public int CompareTo(StringNaturalNumber other)
        {
            if (NaturalNumber.Length > other.NaturalNumber.Length)
                return 1;
            if (NaturalNumber.Length < other.NaturalNumber.Length)
                return -1;
            for (int i = 0; i < NaturalNumber.Length; i++)
            {
                if (NaturalNumber[i] > other.NaturalNumber[i])
                    return 1;
                if (NaturalNumber[i] < other.NaturalNumber[i])
                    return -1;
            }
            return 0;
        }

        public override string ToString()
        {
            return new string(NaturalNumber);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.DigitRemover
{
    public class NumberPart : IComparable<NumberPart>, IComparable
    {
        public int Value { get; set; }
        public int QuanOfZeros { get; set; }

        public static NumberPart operator -(NumberPart first, NumberPart second)
        {
            // first is considered greater than second
            var value = first.Value;
            if (first.QuanOfZeros != second.QuanOfZeros)
            {
                var doubleValue = value * Math.Pow(10, first.QuanOfZeros - second.QuanOfZeros);
                value = (int)(doubleValue - second.Value);
            }
            else
            {
                value -= second.Value;
            }
            return new NumberPart
            {
                Value = value,
                QuanOfZeros = second.QuanOfZeros,
            };
        }
        public int CompareTo(object obj)
        {
            return CompareTo((NumberPart)obj);
        }
        public int CompareTo(NumberPart other)
        {
            if (other.QuanOfZeros > QuanOfZeros)
                return -1;
            if (other.QuanOfZeros < QuanOfZeros)
                return 1;
            if (other.Value > Value)
                return -1;
            if (other.Value < Value)
                return 1;
            return 0;
        }

        public override string ToString()
        {
            return $"{Value}*10^{QuanOfZeros}";
        }
    }
}

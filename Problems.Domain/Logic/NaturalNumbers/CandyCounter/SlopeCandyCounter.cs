using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.CandyCounter
{
    public class SlopeCandyCounter : ICandyCounter
    {
        public int Candy(int[] ratings)
        {
            return 0;
            //return SumCandies(ratings);
        }

        //private static int SumCandies(int[] ratings)
        //{
        //    var properSlopes = GetProperSlopes(ratings)
        //        .ToList();
        //    return properSlopes.Sum(s => s.Sum);
        //}

        //private class Slope
        //{
        //    public int StartIndex { get; set; }
        //    public int EndIndex { get; set; }
        //    public SlopeDirection Direction { get; set; }

        //    public int Length => EndIndex - StartIndex;
        //    public int Sum
        //    {
        //        get
        //        {
        //            var length = Length;
        //            return (length + 2)*(length + 1) / 2;
        //        }
        //    }

        //    public override string ToString()
        //    {
        //        return $"[{StartIndex}, {EndIndex}]";
        //    }
        //}

        //private enum SlopeDirection
        //{
        //    Up,
        //    Flat,
        //    Down,
        //}

        //private static IEnumerable<Slope> GetProperSlopes(int[] ratings)
        //{
        //    var slopes = GetSlopes(ratings)
        //        .ToList();
        //    var enumerator = slopes.GetEnumerator();
        //    while (enumerator.MoveNext())
        //    {
        //        var slope = enumerator.Current;
        //        if (!enumerator.MoveNext())
        //            break;
        //        var nextSlope = enumerator.Current;

        //        if (nextSlope.Length >= slope.Length)
        //        {
        //            --slope.EndIndex;
        //            --nextSlope.StartIndex;
        //        }

        //        yield return slope;
        //        yield return nextSlope;
        //    };
        //}

        //private static IEnumerable<Slope> GetSlopes(int[] ratings)
        //{
        //    int slopeStartIndex = 0,
        //        iLast = ratings.Length - 1;
        //    var slopeDirection = GetSlopeDirection(ratings[0], ratings[1]);

        //    for (int i = 0; i < iLast; ++i)
        //    {
        //        var iNext = i + 1;
        //        var currentSlopeDirection = GetSlopeDirection(ratings[i], ratings[iNext]);

        //        if (currentSlopeDirection != slopeDirection)
        //        {
        //            yield return new Slope
        //            {
        //                StartIndex = slopeStartIndex,
        //                EndIndex = i,
        //                Direction = slopeDirection,
        //            };

        //            slopeDirection = currentSlopeDirection;
        //            slopeStartIndex = i = iNext;
        //        }
        //    }

        //    yield return new Slope
        //    {
        //        StartIndex = slopeStartIndex,
        //        EndIndex = iLast,
        //        Direction = GetSlopeDirection(ratings[slopeStartIndex], ratings[iLast]),
        //    };
        //}

        //private static SlopeDirection GetSlopeDirection(int rating, int nextRating)
        //{
        //    return rating < nextRating ? SlopeDirection.Up
        //         : rating == nextRating ? SlopeDirection.Flat
        //         : rating > nextRating ? SlopeDirection.Down
        //         : (SlopeDirection)(-1);
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.CandyCounter
{
    public class SimpleCandyCounter : ICandyCounter
    {
        public int Candy(int[] ratings)
        {
            if (ratings == null || ratings.Length == 0)
                return 0;
            if (ratings.Length == 1)
                return 1;

            int candies = 0,
                upCount = 0,
                downCount = 0;
            var oldSlopeDirection = SlopeDirection.Flat;
            for (int i = 1; i < ratings.Length; ++i)
            {
                var newSlopeDirection = GetSlopeDirection(ratings[i - 1], ratings[i]);
                if (oldSlopeDirection == SlopeDirection.Up && newSlopeDirection == SlopeDirection.Flat ||
                    oldSlopeDirection == SlopeDirection.Down && newSlopeDirection != SlopeDirection.Down)
                {
                    candies += MountainSum(upCount, downCount);
                    upCount = 0;
                    downCount = 0;
                }
                if (newSlopeDirection == SlopeDirection.Up)
                    ++upCount;
                if (newSlopeDirection == SlopeDirection.Down)
                    ++downCount;
                if (newSlopeDirection == SlopeDirection.Flat)
                    ++candies;

                oldSlopeDirection = newSlopeDirection;
            }
            candies += MountainSum(upCount, downCount) + 1;
            return candies;
        }

        private enum SlopeDirection
        {
            Down = -1,
            Flat,
            Up,
        }

        private static SlopeDirection GetSlopeDirection(int rating, int nextRating)
        {
            return rating < nextRating ? SlopeDirection.Up
                 : rating == nextRating ? SlopeDirection.Flat
                 : rating > nextRating ? SlopeDirection.Down
                 : (SlopeDirection)(-1);
        }

        private static int MountainSum(int upCount, int downCount)
        {
            return ArithmeticProgressionSum(upCount)
                 + ArithmeticProgressionSum(downCount)
                 + Math.Max(upCount, downCount);
        }

        private static int ArithmeticProgressionSum(int elementsCount)
        {
            return (elementsCount * (elementsCount + 1)) / 2;
        }
    }
}

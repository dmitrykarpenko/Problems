using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.CoinCounter
{
    public class SimpleCoinCounter : ICoinCounter
    {
        public int CoinChange(int[] coins, int amount)
        {
            _minCoinsCount = int.MaxValue;

            coins = coins.OrderByDescending(c => c).ToArray();
            return GetCoinCount(coins, amount, 0);
        }

        private int _minCoinsCount = int.MaxValue;

        private int GetCoinCount(IEnumerable<int> descendingCoins, int amount, int priorCoinCount)
        {
            if (amount == 0)
                return priorCoinCount;

            var firstCoin = descendingCoins.FirstOrDefault();
            if (firstCoin == 0) // no coin options left and amount is not zero
                return -1;

            var maxFirstCoinCount = amount / firstCoin;
            if (priorCoinCount + maxFirstCoinCount >= _minCoinsCount) // even the best option is worse than _minCoinsCount
                return -1;

            for (int firstCoinCount = maxFirstCoinCount; firstCoinCount >= 0; --firstCoinCount)
            {
                var nextDescendingCoins = descendingCoins.Skip(1)
                    .ToArray();
                var nextAmount = amount - firstCoin * firstCoinCount;
                var nextPriorCoinCount = priorCoinCount + firstCoinCount;

                var coinsCount = GetCoinCount(nextDescendingCoins, nextAmount, nextPriorCoinCount);

                if (0 <= coinsCount && coinsCount < _minCoinsCount)
                    _minCoinsCount = coinsCount;
            }

            return _minCoinsCount < int.MaxValue ? _minCoinsCount : -1;
        }
    }
}

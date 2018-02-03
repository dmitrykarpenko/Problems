using System;
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
            coins = coins.OrderByDescending(c => c).ToArray();
            return GetCoinCount(coins, amount, 0);
        }

        public static int GetCoinCount(IEnumerable<int> descendingCoins, int amount, int priorCoinCount)
        {
            var firstCoin = descendingCoins.FirstOrDefault();
            if (firstCoin == 0) // no coin options left
                if (amount == 0)
                    return priorCoinCount;
                else
                    return -1;

            var maxFirstCoinCount = amount / firstCoin;
            if (maxFirstCoinCount == 0)
            {
                return GetCoinCount(descendingCoins.Skip(1), amount, priorCoinCount);
            }

            for (int firstCoinCount = maxFirstCoinCount; firstCoinCount >= 0; --firstCoinCount)
            {
                var nextAmount = amount - firstCoin * firstCoinCount;
                var nextPriorCoinCount = priorCoinCount + firstCoinCount;

                var coinsCount = GetCoinCount(descendingCoins.Skip(1), nextAmount, nextPriorCoinCount);
                if (coinsCount >= 0)
                    return coinsCount;
            }

            return -1;
        }
    }
}

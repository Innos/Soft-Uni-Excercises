namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        public static void Main(string[] args)
        {
            var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            var targetSum = 923;

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            Dictionary<int,int> result = new Dictionary<int, int>();
            coins = coins.OrderByDescending(x => x).ToList();
            int currentSum = 0;
            int coinsIndex = 0;
            while (currentSum != targetSum && coinsIndex < coins.Count)
            {
                var remainingSum = targetSum - currentSum;
                int coin = coins[coinsIndex];
                var coinsToTake = remainingSum/coin;
                if (coinsToTake > 0)
                {
                    result.Add(coin,coinsToTake);
                    currentSum += coinsToTake * coin;
                }
                coinsIndex++;
            }
            if (targetSum != currentSum)
            {
                throw new InvalidOperationException("Greedy algorithm cannot produce desired sum with specified coins.");
            }
            return result;
        }
    }
}
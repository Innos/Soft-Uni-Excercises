namespace Knapsack_Problem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Knapsack
    {
        public static void Main()
        {
            var items = new[]
            {
                new Item { Weight = 5, Price = 30 },
                new Item { Weight = 8, Price = 120 },
                new Item { Weight = 7, Price = 10 },
                new Item { Weight = 0, Price = 20 },
                new Item { Weight = 4, Price = 50 },
                new Item { Weight = 5, Price = 80 },
                new Item { Weight = 2, Price = 10 }
            };

            var knapsackCapacity = 20;

            var itemsTaken = FillKnapsack(items, knapsackCapacity);

            Console.WriteLine("Knapsack weight capacity: {0}", knapsackCapacity);
            Console.WriteLine("Take the following items in the knapsack:");
            foreach (var item in itemsTaken)
            {
                Console.WriteLine(
                    "  (weight: {0}, price: {1})",
                    item.Weight,
                    item.Price);
            }

            Console.WriteLine("Total weight: {0}", itemsTaken.Sum(i => i.Weight));
            Console.WriteLine("Total price: {0}", itemsTaken.Sum(i => i.Price));
        }

        public static Item[] FillKnapsack(Item[] items, int capacity)
        {
            // capacity + 1 to account for the 0 capacity
            var maxPrice = new int[items.Length, capacity + 1];
            var itemsTaken = new bool[items.Length, capacity + 1];

            // initialize the values for item 0 as a starting point which we'll use to build upon
            for (int c = 0; c <= capacity; c++)
            {
                if (items[0].Weight <= c)
                {
                    maxPrice[0, c] = items[0].Price;
                    itemsTaken[0, c] = true;
                }
               
            }

            // main iteration to fill the knapsack
            for (int i = 1; i < items.Length; i++)
            {
                for (int c = 0; c <= capacity; c++)
                {
                    // price if we don't take the item
                    maxPrice[i, c] = maxPrice[i - 1, c];

                    int capacityLeft = c - items[i].Weight;
                    if (capacityLeft >= 0 && maxPrice[i - 1, capacityLeft] + items[i].Price > maxPrice[i - 1, c])
                    {
                        maxPrice[i, c] = maxPrice[i - 1, capacityLeft] + items[i].Price;
                        itemsTaken[i, c] = true;
                    }
                }
            }

            // retrieve the items
            var itemsUsed = new List<Item>();
            int itemIndex = items.Length - 1;

            while (itemIndex >= 0)
            {
                if (itemsTaken[itemIndex, capacity])
                {
                    itemsUsed.Add(items[itemIndex]);
                    capacity -= items[itemIndex].Weight; 
                }

                itemIndex--;
            }

            itemsUsed.Reverse();
            return itemsUsed.ToArray();
        }
    }
}

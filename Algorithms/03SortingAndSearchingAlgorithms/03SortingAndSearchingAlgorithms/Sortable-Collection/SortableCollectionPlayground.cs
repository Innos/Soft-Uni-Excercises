namespace Sortable_Collection
{
    using System;

    using Sortable_Collection.Contracts;
    using Sortable_Collection.Sorters;

    public class SortableCollectionPlayground
    {
        private static readonly ISorter<int> TestSorter = new Quicksorter<int>();

        private static readonly Random Random = new Random();

        public static void Main(string[] args)
        {
            const int NumberOfElementsToSort = 40;
            const int MaxValue = 150;
            const int MinValue = -150;

            var array = new int[NumberOfElementsToSort];

            for (int i = 0; i < NumberOfElementsToSort; i++)
            {
                array[i] = Random.Next(MinValue, MaxValue);
            }

            var collectionToSort = new SortableCollection<int>(array);
            collectionToSort.Sort(new BucketSorter { Max = MaxValue, Min = MinValue });

            Console.WriteLine(collectionToSort);

            var collection = new SortableCollection<int>(2, -1, 5, 0, -3);
            Console.WriteLine(collection);

            collection.Sort(TestSorter);
            Console.WriteLine(collection);
        }
    }
}

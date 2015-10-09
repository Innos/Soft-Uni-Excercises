namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using Sortable_Collection.Contracts;

    public class BucketSorter : ISorter<int>
    {
        private long totalElements;

        public long Max { get; set; }

        public long Min { get; set; }

        public void Sort(List<int> collection)
        {
            this.totalElements = collection.Count;

            // choose a sorting method depending on if the collection has negative numbers
            if (this.Min < 0)
            {
                this.ComplexBucketSort(collection);
            }
            else
            {
                this.PositiveBucketSort(collection);
            }
        }

        // simple method for getting bucket number, works only with positive numbers
        private long GetBucketNumber(int number)
        {
            return number * this.totalElements / this.Max;
        }

        // simple method works only with positive numbers
        private void PositiveBucketSort(List<int> collection)
        {
            SortableCollection<int>[] buckets = new SortableCollection<int>[this.totalElements + 1];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new SortableCollection<int>();
            }
            for (int i = 0; i < collection.Count; i++)
            {
                buckets[this.GetBucketNumber(collection[i])].Add(collection[i]);
            }

            collection.Clear();
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i].Sort(new InsertionSorter<int>());
                collection.AddRange(buckets[i].Items);
            }
        }

        // bucket sort including negative numbers
        private void ComplexBucketSort(List<int> collection)
        {
            SortableCollection<int>[] positiveBuckets = new SortableCollection<int>[this.totalElements + 1];
            SortableCollection<int>[] negativeBuckets = new SortableCollection<int>[this.totalElements + 1];

            for (int i = 0; i < positiveBuckets.Length; i++)
            {
                positiveBuckets[i] = new SortableCollection<int>();
                negativeBuckets[i] = new SortableCollection<int>();
            }
            for (int i = 0; i < collection.Count; i++)
            {
                this.AddNumberToBucket(collection[i], positiveBuckets, negativeBuckets);
            }

            collection.Clear();
            for (int i = negativeBuckets.Length - 1; i >= 0; i--)
            {
                positiveBuckets[i].Sort(new InsertionSorter<int>());
                negativeBuckets[i].Sort(new InsertionSorter<int>());
                collection.AddRange(negativeBuckets[i].Items);
            }

            for (int i = 0; i < positiveBuckets.Length; i++)
            {
                collection.AddRange(positiveBuckets[i].Items);
            }
        }

        // a method for the Complex bucket sort
        private void AddNumberToBucket(int number, SortableCollection<int>[] positiveBuckets, SortableCollection<int>[] negativeBuckets)
        {
            if (number < 0)
            {
                long index = number * this.totalElements / this.Min;
                negativeBuckets[index].Add(number);
            }
            else
            {
                positiveBuckets[this.GetBucketNumber(number)].Add(number);
            }
        }

    }
}

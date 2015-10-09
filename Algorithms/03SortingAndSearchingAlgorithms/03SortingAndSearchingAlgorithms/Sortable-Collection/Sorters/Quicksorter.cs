namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Sortable_Collection.Contracts;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.Quicksort(collection, 0, collection.Count - 1);
        }

        private static void Swap(List<T> collection, int indexA, int indexB)
        {
            T temp = collection[indexA];
            collection[indexA] = collection[indexB];
            collection[indexB] = temp;
        }

        private void Quicksort(List<T> collection, int start, int end)
        {
            if (start < end)
            {
                int pivot = this.Partition(collection, start, end);
                this.Quicksort(collection, start, pivot);
                this.Quicksort(collection, pivot + 1, end);
            }
        }

        private int Partition(List<T> collection, int start, int end)
        {
            // mid index is a better pivot point 
            int midIndex = (start + end) / 2;
            T pivot = collection[midIndex];
            int low = start - 1;
            int high = end + 1;
            while (true)
            {
                do
                {
                    low += 1;
                }
                while (collection[low].CompareTo(pivot) < 0);

                do
                {
                    high -= 1;
                }
                while (collection[high].CompareTo(pivot) > 0);

                if (low < high)
                {
                    Swap(collection, low, high);
                }
                else
                {
                    return high;
                }
            }

        }
    }
}

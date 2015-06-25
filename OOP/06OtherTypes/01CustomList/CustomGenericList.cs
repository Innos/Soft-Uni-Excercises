using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01CustomList
{
    public class CustomGenericList<T>  where T: IComparable<T>
    {
        private const int defaultCapacity = 16;

        private T[] elements;
        private int currentIndex;
        private int capacity;

        public CustomGenericList()
        {
            this.capacity = defaultCapacity;
             this.elements = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= currentIndex)
                {
                    throw new IndexOutOfRangeException("Index doesn't exist");
                }
                return elements[index];
            }
            set
            {
                if (index < 0 || index >= currentIndex)
                {
                    throw new IndexOutOfRangeException("Index doesn't exist");
                }
                this.elements[index] = value;
            }
        }

        public void Add(T element)
        {
            if (currentIndex >= defaultCapacity)
            {
                this.Resize();
            }

            this.elements[currentIndex] = element;
            currentIndex++;
        }
        public void Remove(T element)
        {
            bool exists = false;
            for (int index = 0; index < this.currentIndex; index++)
            {
                if (this.elements[index].Equals(element))
                {             
                   Reorder(index);
                    exists = true;
                }
            }
            if (!exists)
            {
                throw new ArgumentException("No such element exists.");
            }
            
        }
        public int IndexOf(T element)
        {
            for (int i = 0; i < this.currentIndex; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }
        public T Min()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("List contains no elements.");
            }
            T min = this.elements[0];
            for (int i = 0; i < this.currentIndex; i++)
            {
                if (this.elements[i].CompareTo(min) == -1)
                {
                    min = this.elements[i];
                }
            }
            return min;
        }
        public T Max()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("List contains no elements.");
            }
            T max = this.elements[0];
            for (int i = 0; i < this.currentIndex; i++)
            {
                if (this.elements[i].CompareTo(max) == 1)
                {
                    max = this.elements[i];
                }
            }
            return max;
        }

        private void Resize()
        {
            capacity = capacity * 2;
            T[] newArray = new T[capacity];   
            for (int i = 0; i < this.currentIndex; i++)
            {
                newArray[i] = this.elements[i];
            }
            this.elements = newArray;
        }
        private void Reorder(int index)
        {
            for (int i = index; i < this.currentIndex - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }
            this.elements[currentIndex-1] = default(T);
            currentIndex--;
        }

        public override string ToString()
        {
            return string.Join(", ", this.elements.Take(this.currentIndex));
        }
    }
}

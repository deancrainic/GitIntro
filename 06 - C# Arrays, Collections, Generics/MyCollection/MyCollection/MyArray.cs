using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    internal class MyArray<T>
    {
        private T[] array;

        public MyArray(int size)
        {
            array = new T[size];
        }

        public T GetItemAtGivenIndex(int index)
        {
            if (index < array.Length && index >= 0)
                return array[index];
            else
                throw new Exception("Index out of bounds");
        }

        public void SetItemAtGivenIndex(int index, T item)
        {
            if (index < array.Length && index >= 0)
                array[index] = item;
            else
                throw new Exception("Index out of bounds");
        }

        public void SwapItemsByIndex(int firstIndex, int secondIndex)
        {
            if (firstIndex < array.Length && secondIndex < array.Length && firstIndex >= 0 && secondIndex >= 0)
            {
                T temp = array[firstIndex];
                array[secondIndex] = array[firstIndex];
                array[firstIndex] = temp;
            }
            else
                throw new Exception("Index out of bounds");
        }

        public void SwapItemsByItem(T firstItem, T secondItem)
        {
            int firstIndex = GetIndex(firstItem);
            int secondIndex = GetIndex(secondItem);

            if (firstIndex >= 0 && secondIndex >= 0)
                SwapItemsByIndex(firstIndex, secondIndex);
            else
                throw new Exception("Item not found");
        }

        private int GetIndex(T item)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i].Equals(item))
                    return i;

            return -1;
        }
    }
}

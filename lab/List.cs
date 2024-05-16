using System;
using MyLib;

namespace lab
{
    public class List<T> where T : IInit, ICloneable, new()
    {
        Point<T> beg = null; // начало списка
        Point<T> end = null; // конец списка

        int count = 0; // счётчик элементов в коллекции

        public int Count => count;

        public Point<T> MakeRandomData()
        {
            T data = new T();
            data.RamdomInit();
            return new Point<T>(data);
        }

        public T MakeRandomItem()
        {
            T data = new T();
            data.RandomInit();
            return data;
        }

        // добавление элемента в начало списка
        public void AddToBegin(T item)
        {
            T newData = (T)item.Clone(); // глубокое копирование
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (beg != null)
            {
                end.Next = newItem;
                newItem.Next = beg;
                beg = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        // добавление элемента в конец списка
        public void AddToEnd(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (end != null)
            {
                end.Next = newItem;
                newItem.Next = end;
                end = newItem;
            }
            else
            {
                end = newItem;
                beg = end;
            }
        }

        public List() { }

        public List(int size)
        {
            if (size <= 0)
            {
                throw new Exception("Размер списка не может быть меньше 0");
            }
            
            beg = MakeRandomData();
            end = beg;

            for (int i = 1; i < size; i++)
            {
                T newItem = MakeRandomItem();
                AddToEnd(newItem);
            }
        }

        public List(T[] collection)
        {
            if (collection == null)
            {
                throw new Exception("Пустая коллекция");
            }
            if (collection.Length == 0)
            {
                throw new Exception("Пустая коллекция");
            }

            T newData = (T)collection.Clone();
            beg = new Point<T>(newData);
            end = beg;

            for (int i = 1;  i < collection.Length; i++)
            {
                AddToEnd(collection[i]);
            }
        }

        public void PrintList()
        {
            if (count == 0)
            {
                Console.WriteLine("Список пуст");
            }

            Point<T>>? current = beg;
            for (int i = 0; current != null; i++)
            {
                Console.WriteLine(current);
                current = current.Next;
            }
        }

        public Point<T>? FindItem(T item)
        {
            Point<T>? current = beg;

        }
    }
}

using MyLib;

namespace lab_12
{
    public class MyList<T> where T : IInit, ICloneable//, new()
    {
        Point<T> beg = null; // начало списка
        Point<T> end = null; // конец списка

        int count = 0; // счётчик элементов в коллекции

        public int Count => count;

        // добавление элемента в начало списка
        public void AddToBegin(T item)
        {
            T newData = (T)item.Clone(); // глубокое копирование
            Point<T> newItem = new Point<T>(newData);

            count++;

            if (beg != null)
            {
                newItem.Next = beg;
                beg.Prev = newItem;
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
                newItem.Prev = end;
                end = newItem;
            }
            else
            {
                end = newItem;
                beg = end;
            }
        }


        public MyList() { }

        // нарушен принцип single responsibility
        ////public MyList(int size)
        ////{
        ////    if (size <= 0)
        ////    {
        ////        throw new Exception("Размер списка не может быть меньше 0");
        ////    }

        ////    beg = MakeRandomData();
        ////    end = beg;

        ////    for (int i = 1; i < size; i++)
        ////    {
        ////        T newItem = MakeRandomItem();
        ////        AddToEnd(newItem);
        ////    }
        ////}

        //// не понадобилось
        ////public MyList(T[] collection)
        ////{
        ////    if (collection == null)
        ////    {
        ////        throw new Exception("Пустая коллекция");
        ////    }
        ////    if (collection.Length == 0)
        ////    {
        ////        throw new Exception("Пустая коллекция");
        ////    }

        ////    T newData = (T)collection.Clone();
        ////    beg = new Point<T>(newData);
        ////    end = beg;

        ////    for (int i = 1; i < collection.Length; i++)
        ////    {
        ////        AddToEnd(collection[i]);
        ////    }
        ////}

        public void PrintList()
        {
            if (count == 0)
            {
                Console.WriteLine("\nСписок пуст");
            }
            else
            {
                Console.WriteLine("\nСписок:");

                Point<T>? current = beg;
               
                for (int i = 0; current != null; i++)
                {
                    Console.WriteLine(current);
                    current = current.Next;
                }
            }         
        }

        public Point<T>? FindItem(T item)
        {
            Point<T>? current = beg;

            while (current != null)
            {
                if (current.Data == null)
                {
                    throw new Exception("Коллекция пуста");
                }

                if (current.Data.Equals(item))
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        public bool RemoveItem(T item)
        {
            if (beg == null)
            {
                throw new Exception("Список пуск");
            }

            Point<T>? pos = FindItem(item);

            if (pos == null)
            {
                return false;
            }

            count--;

            // если в списке один элемент
            if (beg == end)
            {
                beg = end = null;
                return true;
            }

            // если удаляем первый элемент
            if (pos.Prev == null)
            {
                beg = beg?.Next;
                beg.Prev = null;
                return true;
            }

            // если удаляем последний элемент
            if (pos.Next == null)
            {
                end = end.Prev;
                end.Next = null;
                return true;
            }

            Point<T> next = pos.Next;
            Point<T> prev = pos.Prev;
            pos.Next.Prev = prev;
            pos.Prev.Next = next;

            return true;
        }

        // удаление элементов с заданным именем
        public void RemoveItemByName(string name)
        {
            if (beg == null)
            {
                throw new Exception("\nСписок пуст");
            }

            Point<T>? current = beg;

            while (current != null)
            {
                if (current.Data is GeometricFigure geometricFigure)
                {
                    if (geometricFigure.Name == name)
                    {
                        RemoveItem(current.Data);
                    }
                }

                current = current.Next;
            }
        }

        // удаление списка из памяти
        public void Clean()
        {
            Point<T>? current = beg;

            while (current != null)
            {
                Point<T>? next = current.Next;
                RemoveItem(current.Data);
                current = next;
            }

            beg = null;
            end = null;
            count = 0;
        }

        // глубокое клонирование списка
        public MyList<T> DeepClone()
        {
            MyList<T> clonedList = new MyList<T>();

            Point<T>? current = beg;

            while (current != null)
            {
                clonedList.AddToEnd((T)current.Data.Clone());
                current = current.Next;
            }

            return clonedList;
        }
    }
}

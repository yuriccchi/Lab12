using MyLib;

namespace lab_12
{
    public class MyHashTable<TKey, TValue> where TValue : IInit, ICloneable
    {
        private class HashTableItem
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }

        private HashTableItem[] table;
        private int count = 0;
        private double fillRatio;

        public int Capacity => table.Length;
        public int Count => count;

        public MyHashTable(int size = 12, double fillRatio = 0.72)
        {
            table = new HashTableItem[size];
            this.fillRatio = fillRatio;
        }

        public bool ContainsKey(TKey key)
        {
            return FindIndex(key) != -1;
        }

        public bool RemoveByKey(TKey key)
        {
            int index = FindIndex(key);

            if (index < 0)
            {
                return false;
            }
            
            count--;
            table[index] = default;
            
            return true;
        }

        public void PrintTable()
        {
            if (Count == 0)
            {
                Console.WriteLine("\nТаблица пуста");
            }
            else
            {
                Console.WriteLine("\nТаблица:");
                foreach (var item in table)
                {
                    if (item != null)
                    {
                        Console.WriteLine($"Ключ: {item.Key}, объект: {item.Value}");
                    }
                }
            }           
        }

        public void AddItem(TKey key, TValue value)
        {
            // увеличение таблицы, если стартовая уже заполнена
            if ((double)Count / Capacity > fillRatio)
            {
                ResizeTable();
            }

            int index = GetIndex(key);

            // Поиск свободной ячейки, если полученная из расчёта не пустая
            while (table[index] != null)
            {
                index = (index + 1) % Capacity;
            }

            table[index] = new HashTableItem { Key = key, Value = value };
            count++;
        }

        private int FindIndex(TKey key)
        {
            int index = GetIndex(key);

            while (table[index] != null)
            {
                // проверка на совпадение
                if (table[index].Key.Equals(key))
                {
                    return index;
                }
                
                // перебор других ячеек на случай, если нужный объект из-за коллизии в другой ячейке
                index = (index + 1) % Capacity;
            }

            return -1;
        }

        // Вычисление индекс хеша от ключа
        private int GetIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % Capacity;
        }

        private void ResizeTable()
        {
            var temp = table;
            table = new HashTableItem[temp.Length * 2];
            count = 0;

            foreach (var item in temp)
            {
                if (item != null)
                    AddItem(item.Key, item.Value);
            }
        }
    }
}

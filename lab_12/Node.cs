using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_12
{
    public enum Color
    {
        Red, Black
    }

    public class Node<TKey, TValue> // класс, определяющий узел для класса MyRBTree
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public Node<TKey, TValue> Parent { get; set; } // хранение информации о предшествующем узле для упрощения балансировки
        public Node<TKey, TValue> Left { get; set; }
        public Node<TKey, TValue> Right { get; set; }
        public Color NodeColor { get; set; }

        public Node()
        {
            this.Key = default(TKey);
            this.Value = default(TValue);
            this.Left = null;
            this.Right = null;
            this.Parent = null;
            this.NodeColor = Color.Black;
        }

        public Node(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
            this.Parent = null;
            this.Left = null;
            this.Right = null;
            this.NodeColor = Color.Red;
        }
    }
}

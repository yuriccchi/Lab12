using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_12
{
    public class Leaf<T> where T : IComparable
    {
        public T? Data { get; set; }
        public Leaf<T>? Left { get; set; } //адрес на левую ветвь
        public Leaf<T>? Right { get; set; } //адрес на правую ветвь

        // не понадобилось
        //public Point()
        //{
        //    this.Data = default(T);
        //    this.Left = null;
        //    this.Right = null;
        //}

        public Leaf(T data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }

        public override string? ToString()
        {
            // полная форма записи
            //if (this.Data == null) return "";
            //else 
            //    return Data.ToString();

            return Data == null ? "" : Data.ToString();
        }

        public int CompareTo(Leaf<T> other)
        {
            return Data.CompareTo(other.Data);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
    public class Point<T>
    {
        public T? Data { get; set; }
        public Point<T>? Next { get; set; } //адрес на следующий элемент
        public Point<T>? Prev { get; set; } //адрес на предыдущий элемент

        public Point()
        {
            this.Data = default(T);
            this.Prev = null;
            this.Next = null;
        }

        public Point(T data)
        {
            this.Data = data;
            this.Prev = null;
            this.Next = null;
        }

        public override string? ToString()
        {
            //if (this.Data == null) return "";
            //else 
            //    return Data.ToString();
            return Data == null ? "" : Data.ToString();
        }

        public override int GetHashCode()
        {
            return Data == null ? 0 : Data.GetHashCode();
        }
    }
}

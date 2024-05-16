using System.Xml.Linq;

namespace lab_12
{
    public class Point<T> // класс, определяющий ячейку для класса MyList
    {
        public T? Data { get; set; }
        public Point<T>? Next { get; set; } //адрес на следующий элемент
        public Point<T>? Prev { get; set; } //адрес на предыдущий элемент

        // не понадобилось
        //public Point()
        //{
        //    this.Data = default(T);
        //    this.Prev = null;
        //    this.Next = null;
        //}

        public Point(T data)
        {
            this.Data = data;
            this.Prev = null;
            this.Next = null;
        }

        public override string? ToString()
        {
            // полная форма записи
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

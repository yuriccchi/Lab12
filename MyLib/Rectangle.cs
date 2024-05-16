namespace MyLib
{
    public class Rectangle : GeometricFigure
    {
        //атрибуты
        protected double length;
        protected double width;

        Random random = new Random();
        string[] names = { "Прямоугольник", "Квадрат", "Квадратик", "Параллелограмм" };

        //свойства атрибута длины
        public double Length
        {
            get
            {
                return length;
            }

            set
            {
                if (value < 1 || value > 1000000)
                {
                    throw new ArgumentException("Ошибка: значение длины должно быть в пределах от 1 до 1 000 000");
                }

                length = value;
            }
        }

        //свойства атрибута ширины
        public double Width
        {
            get
            {
                return width;
            }

            set
            {
                if (value < 1 || value > 1000000)
                {
                    throw new ArgumentException("Ошибка: значение ширины должно быть в пределах от 1 до 1 000 000");
                }

                width = value;
            }
        }

        //конструктор без параметров
        public Rectangle()
        {
            id = new IdNumbers(1);
            Name = "";
            length = 0;
            width = 0;
        }

        //конструктор с параметрами: название, длина, ширина
        public Rectangle(string name, int number, double length, double width) : base(name, number)
        {
            this.Length = length;
            this.Width = width;
        }

        public override string ToString()
        {
            return $"{base.ToString()}длина = {Length}, ширина = {Width}";
        }

        //Создание объекта с клавиатуры
        public override void Init()
        {
            bool isCorrect;

            base.Init();

            do
            {
                Console.Write("Введите значение длины: ");
                string input = Console.ReadLine();
                isCorrect = double.TryParse(input, out length);

                if (!isCorrect || length < 1 || length > 1000000)
                {
                    Console.WriteLine("Ошибка: некорректный ввод. Значение должно быть числом от 1 до 1000000.");
                }
            } while (!isCorrect);

            do
            {
                Console.Write("Введите значение ширины: ");
                string input = Console.ReadLine();
                isCorrect = double.TryParse(input, out width);

                if (!isCorrect || width < 1 || width > 1000000)
                {
                    Console.WriteLine("Ошибка: некорректный ввод. Значение должно быть числом от 1 до 1000000.");
                }
            } while (!isCorrect);

            Length = length;
            Width = width;
        }

        //Создание рандомного объекта
        public override void RandomInit()
        {
            Name = names[random.Next(names.Length)];
            id = new IdNumbers(random.Next(1, 200));
            Length = new Random().Next(1, 1000);
            Width = new Random().Next(1, 1000);
        }

        //Сравнение объектов
        public override bool Equals(object obj)
        {
            if (obj is not Rectangle) return false;
            return ((Rectangle)obj).Length == Length && ((Rectangle)obj).Width == Width && ((Rectangle)obj).Name == this.Name && ((Rectangle)obj).id.ID == this.id.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, id.ID, Length, Width);
        }

        //Нахождение площади
        public override double GetArea()
        {
            return Length * Width;
        }

        public override object Clone() //Глубокое копирование
        {
            return new Rectangle(this.Name, this.id.ID, this.Length, this.Width);
        }
    }
}

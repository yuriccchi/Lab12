namespace MyLib
{
    public class Parallelepiped : Rectangle
    {
        //атрибуты
        private double height;

        Random random = new Random();
        string[] names = { "Параллелепипед", "Куб", "Кубик", "Призма" }; //дай мне сил...

        //Свойство атрибута высоты
        public double Height
        {
            get
            {
                return height;
            }

            set
            {
                if (value < 1 || value > 1000000)
                {
                    throw new ArgumentException("Ошибка: значение высоты должно быть в пределах от 1 до 1 000 000");
                }

                height = value;
            }
        }

        public Rectangle GetBase
        {
            get => new Rectangle(this.Name, this.id.ID, this.Length, this.Width);
        }

        //Пустой конструктор
        public Parallelepiped()
        {
            id = new IdNumbers(1);
            Name = "";
            length = 0;
            width = 0;
            height = 0;
        }

        //Конструтор с параметрами: имя, длина, ширина, высота
        public Parallelepiped(string name, int number, double length, double width, double heigth) : base(name, number, length, width)
        {
            this.Height = heigth;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, высота = {Height}";
        }

        //Создание объекта с клавиатуры
        public override void Init()
        {
            bool isCorrect;

            base.Init();

            do
            {
                Console.Write("Введите значение высоты: ");
                string input = Console.ReadLine();
                isCorrect = double.TryParse(input, out height);

                if (!isCorrect || height < 1 || height > 1000000)
                {
                    Console.WriteLine("Ошибка: некорректный ввод. Значение должно быть числом от 1 до 1000000.");
                }
            } while (!isCorrect);

            Length = length;
            Width = width;
            Height = height;
        }

        //Создание рандомного объекта
        public override void RandomInit()
        {
            Name = names[random.Next(names.Length)];
            id = new IdNumbers(random.Next(1, 200));
            Length = new Random().Next(1, 1000);
            Width = new Random().Next(1, 1000);
            Height = new Random().Next(1, 1000);
        }

        //Сравнение объектов
        public override bool Equals(object obj)
        {
            if (obj is not Parallelepiped) return false;
            return ((Parallelepiped)obj).Length == Length && ((Parallelepiped)obj).Width == Width && ((Parallelepiped)obj).Height == Height && ((Parallelepiped)obj).Name == this.Name && ((Parallelepiped)obj).id.ID == this.id.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, id.ID, Length, Width, Height);
        }

        //Нахождение площади
        public override double GetArea()
        {
            return (2 * (Length + Width) * Height) + 2 * Length * Width;
        }

        public override object Clone() //Глубокое копирование
        {
            return new Parallelepiped(this.Name, this.id.ID, this.Length, this.Width, this.Height);
        }
    }
}

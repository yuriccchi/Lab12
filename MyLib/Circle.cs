namespace MyLib
{
    public class Circle : GeometricFigure
    {
        //атрибуты
        private double radius;

        Random random = new Random();
        string[] names = { "Окружность", "Кружок", "Кружочек", "Круг" };

        //свойства атрибута радиуса
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (value < 1 || value > 1000000)
                {
                    throw new ArgumentException("Ошибка: значение радиуса должно быть в пределах от 1 до 1 000 000");
                }
                radius = value;
            }
        }
        //Конструктор без параметров
        public Circle()
        {
            id = new IdNumbers(1);
            Name = "";
            radius = 0;
        }

        //Конструктор с параметрами: id, имя и радиус
        public Circle(string name, int number, double radius) : base(name, number)
        {
            Radius = radius;
        }

        public override string ToString()
        {
            return $"{base.ToString()}радиус = {Radius}";
        }

        //Создание объекта с клавиатуры
        public override void Init()
        {
            bool isCorrect;

            base.Init();

            do
            {
                Console.Write("Введите значение радиуса окружности: ");
                string input = Console.ReadLine();
                isCorrect = double.TryParse(input, out radius);

                if (!isCorrect || radius < 1 || radius > 1000000)
                {
                    Console.WriteLine("Ошибка: некорректный ввод. Радиус должен быть числом от 1 до 1000000.");
                }
            } while (!isCorrect);

            Radius = radius;
        }

        //Создание рандомного объекта
        public override void RandomInit()
        {
            Name = names[random.Next(names.Length)];
            id.ID = random.Next(1, 200);
            Radius = random.Next(1, 1000);
        }

        //Сравнение объектов
        public override bool Equals(object obj)
        {
            if (obj is not Circle) return false;
            return ((Circle)obj).Radius == Radius && ((Circle)obj).Name == this.Name && ((Circle)obj).id.ID == this.id.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, id.ID, Radius);
        }

        //Нахождение площади
        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
        public override object Clone() //Глубокое копирование
        {
            return new Circle(this.Name, this.id.ID, this.Radius);
        }
    }
}

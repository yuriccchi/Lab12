namespace MyLib
{
    public abstract class GeometricFigure : IInit, ICloneable
    {
        //Атрибуты
        protected string name;
        public IdNumbers id;
        Random random = new Random();

        //Свойства атрибута имени и счётчика
        public string Name { get; set; }

        //Конструктор без параметров
        public GeometricFigure()
        {
            id = new IdNumbers(1);
            Name = "";
        }

        //Конструктор с параметром: id и название фигуры
        public GeometricFigure(string name, int number)
        {
            id = new IdNumbers(number);
            Name = name;
        }

        //Обычный метод печати
        public string Show()
        {
            return $"{id} - {Name}: ";
        }

        //Виртуальный метод печати
        public virtual string VirtualShow()
        {
            return $"{id} - {Name}: ";
        }

        public override string ToString()
        {
            return $"{id} - {Name}: ";
        }

        //Создание объекта с клавиатуры
        public virtual void Init()
        {
            bool isCorrect;
            int number;

            Console.Write("Введите id фигуры: ");
            do
            {
                string input = Console.ReadLine();
                isCorrect = int.TryParse(input, out number);

                if (!isCorrect)
                {
                    Console.Write("Неверный ввод, повторите попытку: ");
                }
            } while (!isCorrect);

            id.ID = number;
            Console.Write("Введите название фигуры: ");
            Name = Console.ReadLine();
        }

        //Создание рандомного объекта
        public abstract void RandomInit();

        //Объявление абстрактного метода поиска площади
        public abstract double GetArea();

        public override bool Equals(object obj)
        {
            if (obj is not GeometricFigure) return false;
            return ((GeometricFigure)obj).Name == this.Name && ((GeometricFigure)obj).id.ID == this.id.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, id.ID);
        }

        public abstract object Clone(); //Глубокое копирование

        public object ShallowCopy() // Поверхностное копирование
        {
            return this.MemberwiseClone();
        }
    }
}
using MyLib;

namespace lab_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("Выберите задание:");
                Console.WriteLine("1. Работа с двунаправленным списком");
                Console.WriteLine("2. Работа с хеш-таблицей");
                Console.WriteLine("3. Работа с красно-чёрным деревом");
                Console.WriteLine("4. Работа с обобщённой коллекцией (ещё не готово)");
                Console.WriteLine("5. Выход");
                Console.Write("Ваш выбор: ");

                choice = EnterNumber();

                switch (choice)
                {
                    case 1:
                        Task_1();
                        break;
                    case 2:
                        Task_2();
                        break;
                    case 3:
                        Task_3();
                        break;
                    case 4:
                        //Task_4();
                        break;
                    case 5:
                        Console.WriteLine("Программа завершена");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        continue;
                }
            } while (choice != 5);
        }

        // ЗАДАНИЕ 1
        static void Task_1()
        {
            MyList<GeometricFigure> myList = new MyList<GeometricFigure>();

            int choice;

            do
            {
                Console.WriteLine("\nВыберите дейстиве:");
                Console.WriteLine("1. Заполнение списка");
                Console.WriteLine("2. Печать списка");
                Console.WriteLine("3. Удалить из списка все элементы с заданным именем");
                Console.WriteLine("4. Добавить К случайных элементов в начало списка");
                Console.WriteLine("5. Выполнить глубокое клонирование списка");
                Console.WriteLine("6. Удалить список из памяти");
                Console.WriteLine("7. Выход");
                Console.Write("Ваш выбор: ");

                choice = EnterNumber();

                switch (choice)
                {
                    case 1:
                        // Добавление объектов в коллекцию
                        for (int i = 0; i < 5; i++)
                        {
                            Circle randCircle = new Circle();
                            randCircle.RandomInit();
                            myList.AddToEnd(randCircle);
                        }
                        for (int i = 0; i < 5; i++)
                        {
                            Rectangle randRectangle = new Rectangle();
                            randRectangle.RandomInit();
                            myList.AddToEnd(randRectangle);
                        }
                        for (int i = 0; i < 5; i++)
                        {
                            Parallelepiped randParallelepiped = new Parallelepiped();
                            randParallelepiped.RandomInit();
                            myList.AddToEnd(randParallelepiped);
                        }
                        break;
                    case 2:
                        myList.PrintList();
                        break;
                    case 3:
                        Console.Write("\nОбъект(ы) с каким именем удалить? ");
                        string name = Console.ReadLine();
                        myList.RemoveItemByName(name);
                        break;
                    case 4:
                        Console.Write("\nСколько чисел добавить в начало списка? ");
                        int number = EnterNumber();

                        for (int i = 0; i < number; i++)
                        {
                            int randFig = new Random().Next(1, 4);

                            switch (randFig)
                            {
                                case 1:
                                    Circle circle = new Circle();
                                    circle.RandomInit();
                                    myList.AddToBegin(circle);
                                    break;
                                case 2:
                                    Rectangle rectangle = new Rectangle();
                                    rectangle.RandomInit();
                                    myList.AddToBegin(rectangle);
                                    break;
                                case 3:
                                    Parallelepiped parallelepiped = new Parallelepiped();
                                    parallelepiped.RandomInit();
                                    myList.AddToBegin(parallelepiped);
                                    break;
                            }
                        }
                        break;
                    case 5:
                        MyList<GeometricFigure> clonedList = myList.DeepClone();
                        clonedList.PrintList();
                        break;
                    case 6:
                        myList.Clean();
                        break;
                    case 7:
                        Console.WriteLine("Программа завершена");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        continue;
                }
            } while (choice != 7);
        }

        static void Task_2()
        {
            MyHashTable<int,GeometricFigure> myTable = new MyHashTable<int,GeometricFigure>();

            int choice;
            int key;

            do
            {
                Console.WriteLine("\nВыберите дейстиве:");
                Console.WriteLine("1. Заполнение хеш-таблицы");
                Console.WriteLine("2. Печать хеш-таблицы");
                Console.WriteLine("3. Поиск элемента по ключу");
                Console.WriteLine("4. Удалить элемент по ключу");
                Console.WriteLine("5. Добавить элемент в таблицу");
                Console.WriteLine("6. Выход");
                Console.Write("Ваш выбор: ");

                choice = EnterNumber();

                switch (choice)
                {
                    case 1:
                        // Добавление объектов в коллекцию
                        for (int i = 0; i < 4; i++)
                        {
                            Circle randCircle = new Circle();
                            randCircle.RandomInit();
                            myTable.AddItem(randCircle.id.ID, randCircle);
                        }
                        for (int i = 0; i < 4; i++)
                        {
                            Rectangle randRectangle = new Rectangle();
                            randRectangle.RandomInit();
                            myTable.AddItem(randRectangle.id.ID, randRectangle);
                        }
                        for (int i = 0; i < 4; i++)
                        {
                            Parallelepiped randParallelepiped = new Parallelepiped();
                            randParallelepiped.RandomInit();
                            myTable.AddItem(randParallelepiped.id.ID, randParallelepiped);
                        }
                        break;
                    case 2:
                        myTable.PrintTable();
                        break;
                    case 3:
                        Console.Write("\nФигуру с каким ключём необходимо найти? ");
                        key = EnterNumber();
                        bool isFind = myTable.ContainsKey(key);
                        if (isFind)
                        {
                            Console.WriteLine("Фигура с заданным ключём найдена");
                        }
                        else
                        {
                            Console.WriteLine("Фигуры с таким ключём нет в таблице");
                        }
                        break;
                    case 4:
                        Console.Write("\nФигуру с каким ключём необходимо удалить? ");
                        key = EnterNumber();
                        myTable.RemoveByKey(key);
                        break;
                    case 5:
                        Console.WriteLine("\nКакую фигуру необходимо добавить? ");
                        ChooseFigureMenu();
                        int newFig = EnterNumber();

                        switch (newFig)
                        {
                            case 1:
                                Circle circle = new Circle();
                                circle.RandomInit();
                                myTable.AddItem(circle.id.ID, circle);
                                Console.WriteLine($"\nБыла добавлена фигура {circle}");
                                break;
                            case 2:
                                Rectangle rectangle = new Rectangle();
                                rectangle.RandomInit();
                                myTable.AddItem(rectangle.id.ID, rectangle);
                                Console.WriteLine($"\nБыла добавлена фигура {rectangle}");
                                break;
                            case 3:
                                Parallelepiped parallelepiped = new Parallelepiped();
                                parallelepiped.RandomInit();
                                myTable.AddItem(parallelepiped.id.ID, parallelepiped);
                                Console.WriteLine($"\nБыла добавлена фигура {parallelepiped}");
                                break;
                        }
                        break;
                    case 6:
                        Console.WriteLine("Программа завершена");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        continue;

                }
            } while (choice != 6);
        }

        static void Task_3()
        {
            MyRBTree<int, GeometricFigure> myTree = new MyRBTree<int, GeometricFigure>();

            int choice;
            int key;

            do
            {
                Console.WriteLine("\nВыберите дейстиве:");
                Console.WriteLine("1. Заполнение дерева");
                Console.WriteLine("2. Печать дерева");
                Console.WriteLine("3. Определение высоты дерева");
                Console.WriteLine("4. Удалить элемент по ключу");
                Console.WriteLine("5. Удалить дерево из памяти");
                Console.WriteLine("6. Выход");
                Console.Write("Ваш выбор: ");

                choice = EnterNumber();

                switch (choice)
                {
                    case 1:
                        for (int i = 0; i < 6; i++)
                        {
                            Circle randCircle = new Circle();
                            randCircle.RandomInit();
                            myTree.Insert(randCircle.id.ID, randCircle);
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            Rectangle randRectangle = new Rectangle();
                            randRectangle.RandomInit();
                            myTree.Insert(randRectangle.id.ID, randRectangle);
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            Parallelepiped randParallelepiped = new Parallelepiped();
                            randParallelepiped.RandomInit();
                            myTree.Insert(randParallelepiped.id.ID, randParallelepiped);
                        }
                        break;
                    case 2:
                        myTree.PrintTree();
                        break;
                    case 3:
                        myTree.PrintBlackHeight();
                        break;
                    case 4:
                        Console.Write("\nФигуру с каким ключём необходимо удалить? ");
                        key = EnterNumber();
                        myTree.Remove(key);
                        break;
                    case 5:
                        myTree.ClearTree();
                        break;
                    case 6:
                        Console.WriteLine("Программа завершена");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        continue;

                }
            } while (choice != 6);
        }

        static void ChooseFigureMenu()
        {
            Console.WriteLine("Выберите тип фигуры для совершения действия:");
            Console.WriteLine("1. Круг");
            Console.WriteLine("2. Прямоугольник");
            Console.WriteLine("3. Параллелепипед");
            Console.Write("Ваш выбор: ");
        }

        static int EnterNumber()
        {
            bool isCorrect;
            int number;
            do
            {
                string input = Console.ReadLine();
                isCorrect = int.TryParse(input, out number);
                if (!isCorrect)
                {
                    Console.Write("Неверный ввод, повторите попытку: ");
                }
            } while (!isCorrect);
            return number;
        }
    }
}

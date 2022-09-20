using System;

namespace LinkedListByMisyuro
{
    internal class Program
    {
        static void CreateAHeadline()
        {
            string Headline = "=======MENU=======";
            int topRightX = Console.WindowWidth / 2 - Headline.Length;

            Console.SetCursorPosition(topRightX, 0);
            Console.WriteLine(Headline + "\n");
        }

        static void MenuItems(out int selection)
        {
            Console.WriteLine("1 - Добавить элемент списка в начало\n" +
                "2 - Добавить элемент списка в конец\n3 - Добавить после определенного элемента\n" +
                "4 - Удалить элемент по значению\n5 - Очистить список\n6 - Просмотр списка\n7 - Выход");
            Console.WriteLine("\nВыберите число от 1 до 7");
            while (!int.TryParse(Console.ReadLine(), out selection))
            {
                Console.WriteLine("Ошибка ввода. Попробуй еще раз!");
            }
            Console.Clear();
        }

        static void Input(out int value)
        {
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Ошибка ввода. Попробуй еще раз!");
            }
            Console.Clear();
        }

        static void OutPut(LinkedList<int> list)
        {
            foreach (var item in list)
            {
                Console.Write($" |{item}| ");
            }
        }

        static void AddWithFirst(LinkedList<int> list)
        {
            int value;
            Console.Write("\nВведите число, которое хотите добавить в начало: ");

            Input(out value);
          
            list.AddToHead(value);
        }

        static void AddWithEnd(LinkedList<int> list)
        {
            int value;
            Console.Write("Введите число, которое хотите добавить в конец: ");

            Input(out value);
            
            list.AddToTail(value);
        }

        static void AddBetweenItems(LinkedList<int> list)
        {
            int value, afterValue;
            Console.Write("Введите число, после которого хотите добавить значение: ");

            Input(out afterValue);

            Console.Write("Введите число, которое хотите добавить: ");

            Input(out value);

            list.AddBetween(afterValue, value);
        }

        static void Delete(LinkedList<int> list)
        {
            int value;
            Console.Write("Введите значение элемента, которое хотите удалить: ");

            Input(out value);

            list.Delete(value);
        }

        static void ClearList(LinkedList<int> list)
        {
            list.Clear();
            Console.WriteLine("Список очищен\n\n");
        }
        static void Main(string[] args)
        {
            int selection;
            var list = new LinkedList<int>();

            CreateAHeadline();

            MenuItems(out selection);
            do
            {
                switch (selection)
                {
                    case 1:
                        AddWithFirst(list);
                        MenuItems(out selection);
                        break;
                    case 2:
                        AddWithEnd(list);
                        MenuItems(out selection);
                        break;
                    case 3:
                        AddBetweenItems(list);
                        MenuItems(out selection);
                        break;
                    case 4:
                        Delete(list);
                        MenuItems(out selection);
                        break;
                    case 5:
                        ClearList(list);
                        MenuItems(out selection);
                        break;
                    case 6:
                        OutPut(list);
                        Console.WriteLine("\n\n");
                        MenuItems(out selection);
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Вы ввели не правильное значение\n\n");
                        MenuItems(out selection);
                        break;
                }
            } while (selection != 7);
        }
    }
}

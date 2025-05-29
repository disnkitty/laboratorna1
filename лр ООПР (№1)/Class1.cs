using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лр_ООПР___1_
{
    internal class Class1
    {
        public static void ShowMenu(RList head)
        {
            while (true)
            {
                Console.WriteLine("Оберіть номер завдання (6, 7, 15, 19, 27, 41, 61, 77, 79) або 0 для виходу:");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "6":
                        Console.WriteLine("6) Елементи списку після рекурсивного методу:");
                        head.PrintList();
                        Console.WriteLine("\n");
                        break;

                    case "7":
                        head.AddToEndNonRecursive(90);
                        head.AddToEndNonRecursive(100);
                        head.AddToEndNonRecursive(110);
                        Console.WriteLine("7) Елементи списку після нерекурсивного додавання:");
                        head.PrintList();
                        Console.WriteLine("\n");
                        break;

                    case "15":
                        head.RemoveLast();
                        head.RemoveLast();
                        head.RemoveLast();
                        Console.WriteLine("15) Елементи списку після рекурсивного видалення:");
                        head.PrintList();
                        Console.WriteLine("\n");
                        break;

                    case "19":
                        Console.Write("Введіть значення для видалення: ");
                        if (int.TryParse(Console.ReadLine(), out int value))
                        {
                            head.RemoveOpredZnach(value);
                            Console.WriteLine($"19) Елементи списку після видалення всіх елементів зі значенням {value}:");
                            head.PrintList();
                        }
                        else
                        {
                            Console.WriteLine("Некоректне введення!");
                        }
                        Console.WriteLine("\n");
                        break;

                    case "27":
                        Console.WriteLine("27) Нерекурсивний метод виводу елементів у стовпчик:");
                        head.PrintListvStolbik();
                        Console.WriteLine("\n");
                        break;

                    case "41":
                        Console.Write("Введіть значення для пошуку: ");
                        if (int.TryParse(Console.ReadLine(), out int searchValue))
                        {
                            int position = head.FindElementPosition(searchValue);
                            if (position != -1)
                            {
                                Console.WriteLine($"41) Позиція елемента зі значенням {searchValue}: {position}");
                            }
                            else
                            {
                                Console.WriteLine($"41) Елемент зі значенням {searchValue} не знайдено.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некоректне введення!");
                        }
                        Console.WriteLine("\n");
                        break;

                    case "61":
                        Console.Write("Введіть початковий індекс: ");
                        int start = int.Parse(Console.ReadLine());
                        Console.Write("Введіть кінцевий індекс: ");
                        int end = int.Parse(Console.ReadLine());

                        try
                        {
                            int maxValue = head[start, end];
                            Console.WriteLine($"61) Максимум між індексами {start} та {end}: {maxValue}");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Помилка: {ex.Message}");
                        }
                        Console.WriteLine("\n");
                        break;

                    case "77":
                        Console.WriteLine("77) Перевірка неявного перетворення списку в bool:");
                        Console.WriteLine(head ? "Список не порожній" : "Список порожній");
                        Console.WriteLine("\n");
                        break;

                    case "79":
                        Console.WriteLine("79) Перевизначена операція додавання для списку:");
                        int sum = +head;
                        Console.WriteLine($"Сума елементів списку: {sum}");
                        Console.WriteLine("\n");
                        break;

                    case "0":
                        Console.WriteLine("Вихід з програми...");
                        return;

                    default:
                        Console.WriteLine("Невірне введення. Спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}

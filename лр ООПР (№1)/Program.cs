using System;
class Program
{
    static void Main()
    {
        //6 завдання
        RList head = new RList(10); // створюємо перший вузол зі значенням 10
        head.AddToEnd(20);
        head.AddToEnd(30);
        head.AddToEnd(40);
        head.AddToEnd(50);
        head.AddToEnd(60);
        head.AddToEnd(70);
        head.AddToEnd(80);

        Console.WriteLine("6)Елементи списку після рекурсивного методу:");
        head.PrintList();
        Console.WriteLine();
        Console.WriteLine();

        //7 завдання 
        head.AddToEndNonRecursive(90);
        head.AddToEndNonRecursive(100);
        head.AddToEndNonRecursive(110);

        Console.WriteLine("7)Елементи списку після нерекурсивного додавання:");
        head.PrintList();
        Console.WriteLine();
        Console.WriteLine();

        //15 завдання 
        head.RemoveLast();
        head.RemoveLast();
        head.RemoveLast();

        Console.WriteLine("15)Елементи списку після рекурсивного видалення:");
        head.PrintList();
        Console.WriteLine();
        Console.WriteLine();

        //19 завдання
        int value = 20;
        head.RemoveOpredZnach(value);
        Console.WriteLine($"19)Елементи списку після видалення всіх елементів зі значенням {value}:");
        head.PrintList();
        Console.WriteLine();
        Console.WriteLine();

        //27 завдання
        Console.WriteLine("27)Нерекурсивний метод друку елементів у стовпчик:");
        head.PrintListvStolbik();
        Console.WriteLine();
        Console.WriteLine();

        //41 завдання
        int alue = 30;
        int position = head.FindElementPosition(alue);
        if (position != -1)
        {
            Console.WriteLine($"41)Позиція елемента зі значенням {alue}: {position}");
        }
        else
        {
            Console.WriteLine($"41)Елемент зі значенням {alue} не знайдено.");
        }
        Console.WriteLine();
        Console.WriteLine();

        //61 завдання
        int start = 2;
        int end = 7;
        Console.WriteLine($"61)Індексатор: пошук максимуму між індексами {start} і {end}");

        try
        {
            int maxValue = head[start, end];
            Console.WriteLine($"Максимум між індексами {start} і {end}: {maxValue}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
        Console.WriteLine();
        Console.WriteLine();

        // 77 завдання
        Console.WriteLine("77)Перевірка неявного перетворення списку у bool:");

        // Перевірка для непорожнього списку
        if (head)
        {
            Console.WriteLine("Список не порожній");
        }
        else
        {
            Console.WriteLine("Список порожній");
        }
        Console.WriteLine();
        Console.WriteLine();

        //79 завдання
        Console.WriteLine("79) Перевизначена операція додавання для списку:");
        int sum = +head;  // + підсумовує всі елементи
        Console.WriteLine($"Сума елементів списку: {sum}");

    }
}
class RList
{
    public int info;
    public RList next;

    public RList(int i)
    {
        info = i;
        next = null;
    }

    public RList(int i, RList n)
    {
        info = i;
        next = n;
    }
    //Перший конструктор — потрібен, якщо ми створюємо окремий вузол без зв’язку. Другий — якщо одразу хочемо зв’язати вузол з іншим.

    //Метод для виведення списку
    public void PrintList()
    {
        Console.Write(info + " ");

        if (next != null)
        {
            next.PrintList();
        }
    }

    // 6) Рекурсивний метод додавання елемента в кінець списку
    public void AddToEnd(int value)
    {
        if (next == null)
        {
            next = new RList(value); // Додаємо новий елемент
        }
        else
        {
            next.AddToEnd(value);
        }
    }

    // 7) Нерекурсивний метод додавання елемента в кінець списку
    public void AddToEndNonRecursive(int value)
    {
        RList current = this;

        while (current.next != null)
        {
            current = current.next;
        }

        current.next = new RList(value);
    }

    // 15) Рекурсивне видалення останнього елемента
    public void RemoveLast()
    {
        if (next != null && next.next == null)
        {
            next = null;
        }
        else
        {
            next?.RemoveLast();
        }
    }

    // 19) Нерекурсивне видалення всіх елементів з заданим значенням
    public void RemoveOpredZnach(int value)
    {
        RList current = this;
        RList previous = null;

        while (current != null)
        {
            if (current.info == value)
            {
                if (previous == null)
                {
                    this.info = current.next?.info ?? 0;
                    this.next = current.next?.next;
                }
                else
                {
                    previous.next = current.next;
                }
            }
            else
            {
                previous = current;
            }

            current = current.next;
        }
    }

    // 27) Нерекурсивне виведення списку в стовпчик
    public void PrintListvStolbik()
    {
        RList current = this;
        while (current != null)
        {
            Console.WriteLine(current.info);
            current = current.next;
        }
    }

    // 41) Пошук елемента і виведення його позиції
    public int FindElementPosition(int value)
    {
        int position = 1;
        RList current = this;

        while (current != null)
        {
            if (current.info == value)
            {
                return position;
            }
            current = current.next;
            position++;
        }

        return -1;
    }

    // 61) Індексатор: пошук максимуму між двома індексами
    public int this[int start, int end]
    {
        get
        {
            if (start > end || start < 1)
            {
                throw new ArgumentException("Некоректні індекси.");
            }

            RList current = this;
            int position = 1;
            int max = int.MinValue;
            bool inRange = false;

            int listLength = 0;
            while (current != null)
            {
                listLength++;
                current = current.next;
            }

            if (end > listLength)
            {
                throw new ArgumentException("Індекс end виходить за межі списку.");
            }

            current = this;
            position = 1;

            while (current != null)
            {
                if (position == start)
                {
                    inRange = true;
                }

                if (inRange)
                {
                    max = Math.Max(max, current.info);
                }

                if (position == end)
                {
                    break;
                }

                current = current.next;
                position++;
            }

            if (!inRange)
            {
                throw new ArgumentException("Один з індексів виходить за межі списку.");
            }

            return max;
        }
    }

    // 77) Неявне перетворення списку в bool
    public static implicit operator bool(RList list)
    {
        return list != null;
    }

    // 79) Перевизначення оператора + для RList (сума всіх елементів)
    public static int operator +(RList list)
    {
        int sum = 0;
        RList current = list;

        while (current != null)
        {
            sum += current.info;
            current = current.next;
        }

        return sum;
    }
}

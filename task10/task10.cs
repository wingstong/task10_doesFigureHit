using System;

class task10
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Введите название фигуры (ладья, слон, король, ферзь):");
            string figure = Console.ReadLine().ToLower();

            // Первое поле
            Random random = new Random();
            char x1 = (char)('a' + random.Next(0, 8));
            int y1 = random.Next(1, 9);

            // Второе поле
            char x2;
            int y2;
            do
            {
                x2 = (char)('a' + random.Next(0, 8));
                y2 = random.Next(1, 9);
            } while (x1 == x2 && y1 == y2); // пока корды не совпадают

            Console.WriteLine($"Поле {x1}{y1}");
            Console.WriteLine($"Поле {x2}{y2}");

            bool isThreatening = false;
            switch (figure)
            {
                case "ладья":
                    isThreatening = rook(x1, y1, x2, y2);
                    break;
                case "слон":
                    isThreatening = bishop(x1, y1, x2, y2);
                    break;
                case "король":
                    isThreatening = king(x1, y1, x2, y2);
                    break;
                case "ферзь":
                    isThreatening = queen(x1, y1, x2, y2);
                    break;
                default:
                    Console.WriteLine("Неизвестная фигура.");
                    return;
            }

            Console.WriteLine(isThreatening ? "Фигура угрожает полю.\n" : "Фигура не угрожает полю.\n"); // условие ? выражение1 : выражение2;
        }
    }

    static bool rook(char x1, int y1, char x2, int y2)
    {
        
        return x1 == x2 || y1 == y2;
    }

    static bool bishop(char x1, int y1, char x2, int y2)
    {
        return Math.Abs(x1 - x2) == Math.Abs(y1 - y2);
    }

    static bool king(char x1, int y1, char x2, int y2)
    {

        return Math.Abs(x1 - x2) <= 1 && Math.Abs(y1 - y2) <= 1;
    }

    static bool queen(char x1, int y1, char x2, int y2)
    {

        return rook(x1, y1, x2, y2) || bishop(x1, y1, x2, y2);
    }
}

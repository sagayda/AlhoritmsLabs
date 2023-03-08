namespace AlhoritmsLab1
{
    internal class Program
    {
        public static void PrintArray(int[,] matrix)
        {
            Console.WriteLine($"Size: {matrix.GetLength(0)} * {matrix.GetLength(1)}");
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    Console.Write($"{matrix[x, y]}, ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("###############################");
        }
        public static int[,] GetArrayFromFile()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введiть шлях до файла:");
                    string path = Console.ReadLine();
                    File.OpenRead(path);

                    List<string> tempList = new List<string>();

                    tempList = File.ReadAllLines(path).ToList();
                    int xLenght = tempList.Count;
                    int yLenght = tempList[0].Split(" ").Length;

                    int[,] array = new int[xLenght, yLenght];

                    for (int i = 0; i < xLenght; i++)
                    {
                        var temp = tempList[i].Split(" ");

                        for (int j = 0; j < yLenght; j++)
                        {
                            array[i, j] = int.Parse(temp[j]);
                        }
                    }
                    PrintArray(array);
                    return array;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public static int[,] GetArrayFromConsole()
        {
            int x;
            int y;
            while (true)
            {
                try
                {
                    Console.Write("Масив n*m\nn: ");
                    x = int.Parse(Console.ReadLine());
                    Console.Write("m: ");
                    y = int.Parse(Console.ReadLine());
                    if (x > 0 && y > 0)
                        break;
                    Console.WriteLine("Invalid array size");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            int[,] array = new int[x, y];
            Console.WriteLine("Введiть масив");
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    while (true)
                    {
                        Console.Write($"{i + 1}, {j + 1}: ");
                        try
                        {
                            array[i, j] = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }

            return array;
        }
        public static int[,] GetRandomArray()
        {
            int x;
            int y;
            while (true)
            {
                try
                {
                    Console.Write("Масив n*m\nn: ");
                    x = int.Parse(Console.ReadLine());
                    Console.Write("m: ");
                    y = int.Parse(Console.ReadLine());
                    if (x > 0 && y > 0)
                        break;
                    Console.WriteLine("Invalid array size");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            int[,] array = new int[x, y];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Random random = new Random();
                    array[i, j] = random.Next(-5000, 5000);
                }
            }

            PrintArray(array);
            return array;
        }
        static void Main(string[] args)
        {
            int enterType = 0;
            while (true)
            {
                Console.WriteLine("Виберiть тип вводу (1 - З консолi, 2 - З файлу, 3 - Рандомний): ");
                try
                {
                    enterType = int.Parse(Console.ReadLine());
                    if (enterType > 3 || enterType < 1)
                    {
                        Console.WriteLine("Invalid number");
                        continue;
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            int[,] array;

            if (enterType == 1)
            {
                array = GetArrayFromConsole();
            }
            else if (enterType == 2)
            {
                array = GetArrayFromFile();
            }
            else
            {
                array = GetRandomArray();
            }

            int minValue = array[0, 0];
            string minValueIndex = "1, 1";

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < minValue)
                    {
                        minValue = array[i, j];
                        minValueIndex = $"{i + 1}, {j + 1}";
                    }
                }
            }
            Console.WriteLine($"Мiнiмальний елемент масиву: {minValue}\nIндекс мiнiмального масиву: {minValueIndex}");
        }
    }
}
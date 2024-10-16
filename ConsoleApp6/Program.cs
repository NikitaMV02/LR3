using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void CalculateFactorialWithThread(int number)
    {
        Thread thread = new Thread(() =>
        {
            Console.WriteLine($"Thread: Обчислення факторіалу числа {number}");
            long factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
                Thread.Sleep(500);
            }
            Console.WriteLine($"Thread: Факторіал числа {number} = {factorial}");
        });
        thread.Start();
        thread.Join();
    }

    static async Task CalculateSumOfSquaresAsync(int limit)
    {
        Console.WriteLine($"Async1: Обчислення суми квадратів чисел до {limit}");
        long sumOfSquares = 0;
        for (int i = 1; i <= limit; i++)
        {
            sumOfSquares += i * i;
            await Task.Delay(300);
        }
        Console.WriteLine($"Async1: Сума квадратів чисел до {limit} = {sumOfSquares}");
    }

    static async Task CalculatePrimesAsync(int limit)
    {
        Console.WriteLine($"Async2: Обчислення простих чисел до {limit}");
        for (int i = 2; i <= limit; i++)
        {
            if (IsPrime(i))
            {
                Console.WriteLine($"Async2: {i} - просте число");
                await Task.Delay(200);
            }
        }
        Console.WriteLine($"Async2: Обчислення простих чисел завершено");
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    static async Task Main(string[] args)
    {
        CalculateFactorialWithThread(5);

        await CalculateSumOfSquaresAsync(5);

        await CalculatePrimesAsync(10);

        Console.WriteLine("Усі операції завершено.");
    }
}

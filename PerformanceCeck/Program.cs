using PerformanceCeck;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance_check
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Stopwatch stopwatch = new Stopwatch();
            Timing timing = new Timing();
            int[] mass = new int[1000000];
            for(int i = 0; i < mass.Length; i++)
            {
                mass[i] = random.Next(10000);
            }
            sortingByChoice(mass, stopwatch, timing);
            sortingByInsert(mass, stopwatch, timing);
            
        }

        //сортировка выбором
        public static void sortingByChoice(int[] mass, Stopwatch stopwatch,Timing timing)
        {
            timing.StartTime();
            stopwatch.Restart();
            for (int i = 0; i < mass.Length - 1; i++)
            {
                //поиск минимального числа
                int min = i;
                for (int j = i + 1; j < mass.Length; j++)
                {
                    if (mass[j] < mass[min])
                    {
                        min = j;
                    }
                }
                //обмен элементов
                int temp = mass[min];
                mass[min] = mass[i];
                mass[i] = temp;
            }
            stopwatch.Stop();
            timing.StopTime();
            Console.WriteLine(stopwatch.ElapsedTicks.ToString());
            Console.WriteLine(timing.Result().ToString());

        }

        //Сортировка вставками
        public static void sortingByInsert(int[] mass, Stopwatch stopwatch,Timing timing)
        {
            timing.StartTime();
            stopwatch.Restart();
            for (int i = 1; i < mass.Length; i++)
            {
                int k = mass[i];
                int j = i - 1;

                while (j >= 0 && mass[j] > k)
                {
                    mass[j + 1] = mass[j];
                    mass[j] = k;
                    j--;
                }
            }
            stopwatch.Stop();
            timing.StopTime();
            Console.WriteLine(stopwatch.ElapsedTicks.ToString());
            Console.WriteLine(timing.Result().ToString());

        }
    }
}



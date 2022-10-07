using PerformanceCeck;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance_check
{
    internal class Program
    {
        static int counter;  
        static int n;
        static void Main(string[] args)
        {
            Random random = new Random();
            Stopwatch stopwatch = new Stopwatch();
            Timing timing = new Timing();
            int[] mass = new int[100];
            for(int i = 0; i < mass.Length; i++)
            {
                mass[i] = random.Next(10000);
            }
            bubleSort(mass, stopwatch, timing);
            sortingByChoice(mass, stopwatch, timing);
            sortingByInsert(mass, stopwatch, timing);
            linePoisk(mass, 7532, stopwatch, timing);
            binPoisk(mass, 7532, stopwatch, timing);
            
        }
        //сортировка обменом
        public static void bubleSort(int[] mass, Stopwatch stopwatch, Timing timing)
        {
            timing.StartTime();
            stopwatch.Restart();
            int temp;
            for (int i = 0; i < mass.Length; i++)
            {
                for (int j = i + 1; j < mass.Length; j++)
                {
                    if (mass[i] > mass[j])
                    {
                        temp = mass[i];
                        mass[i] = mass[j];
                        mass[j] = temp;
                    }
                }
            }
            stopwatch.Stop();
            timing.StopTime();
            Console.WriteLine("Stopwatch: " + stopwatch.ElapsedTicks.ToString());
            Console.WriteLine("Timing: " + timing.Result().ToString());
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
            Console.WriteLine("Stopwatch: " + stopwatch.ElapsedTicks.ToString());
            Console.WriteLine("Timing: " +timing.Result().ToString());

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
            Console.WriteLine("Stopwatch: " + stopwatch.ElapsedTicks.ToString());
            Console.WriteLine("Timing: " + timing.Result().ToString());

        }

        static int linePoisk(int[] mass,int find, Stopwatch stopwatch, Timing timing)
        {
            timing.StartTime();
            stopwatch.Restart();
            int k = -1;
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] == find) { k = i; break; };
            }
            stopwatch.Stop();
            timing.StopTime();
            Console.WriteLine("Stopwatch: " + stopwatch.ElapsedTicks.ToString());
            Console.WriteLine("Timing: " + timing.Result().ToString());
            return k;
        }
        // Бинарный поиск
        static int binPoisk(int[] mass, int find, Stopwatch stopwatch, Timing timing)
        {
            timing.StartTime();
            stopwatch.Restart();
            int k;   // с
            int L = 0;        // левая граница
            int R = mass.Length - 1;    // правая граница
            k = (R + L) / 2;
            counter = 0;
            while (L < R - 1)
            {
                counter++;
                k = (R + L) / 2;
                if (mass[k] == find)
                    return k;
                counter++;
                if (mass[k] < find)
                    L = k;
                else
                    R = k;
            }
            if (mass[k] != find)
            {
                if (mass[L] == find)
                    k = L;
                else
                {
                    if (mass[R] == find)
                        k = R;
                    else
                        k = -1;
                };
            }
            stopwatch.Stop();
            timing.StopTime();
            Console.WriteLine("Stopwatch: " + stopwatch.ElapsedTicks.ToString());
            Console.WriteLine("Timing: " + timing.Result().ToString());
            return k;
        }
    }
}



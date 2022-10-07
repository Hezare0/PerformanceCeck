using PerformanceCeck;
using System;
using System.Collections;
using System.Diagnostics;

namespace Performance_check
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable(10000);
            
            Stopwatch stopwatch = new Stopwatch();
            Timing timing = new Timing();
            int[] mass = new int[10000];

            Random random = new Random();
            for (int i = 0; i < hashtable.Count; i++)
            {
                hashtable.Add(i, random.Next(10000));
            }

            //сортировка обменом
            //Stopwatch test: 11413123 ms
            //Timing test: 00:00:00.6562500
            fillArray(mass);
            timing.StartTime();
            bubleSort(mass, stopwatch);
            timing.StopTime();
            Console.WriteLine("Timing: " + timing.Result().ToString());

            //сортировка выбором
            //Stopwatch test: 3994279 ms
            //Timing test: 00:00:00.3593750
            fillArray(mass);
            timing.reset();
            timing.StartTime();
            sortingByChoice(mass, stopwatch);
            timing.StopTime();
            Console.WriteLine("Timing: " + timing.Result().ToString());

            //Сортировка вставками
            //Stopwatch test: 3773448 ms
            //Timing test: 00:00:00.3281250
            fillArray(mass);
            timing.reset();
            timing.StartTime();
            sortingByInsert(mass, stopwatch);
            timing.StopTime();
            Console.WriteLine("Timing: " + timing.Result().ToString());

            //Линейный поиск
            //Stopwatch test: 525 ms
            //Timing test:  00:00:00
            fillArray(mass);
            timing.reset();
            timing.StartTime();
            linePoisk(mass, 7532, stopwatch);
            timing.StopTime();
            Console.WriteLine("Timing: " + timing.Result().ToString());

            // Бинарный поиск
            //Stopwatch test: 18 ms
            //Timing test:  00:00:00
            fillArray(mass);
            timing.reset();
            timing.StartTime();
            binPoisk(mass, 7532, stopwatch);
            timing.StopTime();
            Console.WriteLine("Timing: " + timing.Result().ToString());

            // поиск в Hashtable
            //Stopwatch test: 8606 ms
            //Timing test:  00:00:00.0156250
            timing.reset();
            timing.StartTime();
            stopwatch.Restart();
            findElement(hashtable, 2);
            stopwatch.Stop();
            timing.StopTime();
            Console.WriteLine("Stopwatch: " + stopwatch.ElapsedTicks.ToString());
            Console.WriteLine("Timing: " + timing.Result().ToString());

        }

        //Заполнение массива
        public static void fillArray(int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(10000);
            }
           
        }

        // поиск в Hashtable
        public static int findElement(Hashtable hashtable, int element)
        {

            foreach (DictionaryEntry el in hashtable)
            {
                if (el.Value.Equals(element))
                    return (int)el.Key;
            }

            return -1;
        }

        //сортировка обменом
        public static void bubleSort(int[] mass, Stopwatch stopwatch)
        {

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

            Console.WriteLine("Stopwatch: " + stopwatch.ElapsedTicks.ToString());

        }

        //сортировка выбором
        public static void sortingByChoice(int[] mass, Stopwatch stopwatch)
        {

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

            Console.WriteLine("Stopwatch: " + stopwatch.ElapsedTicks.ToString());


        }

        //Сортировка вставками
        public static void sortingByInsert(int[] mass, Stopwatch stopwatch)
        {

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

            Console.WriteLine("Stopwatch: " + stopwatch.ElapsedTicks.ToString());


        }

        //Линейный поиск
        static int linePoisk(int[] mass, int find, Stopwatch stopwatch)
        {

            stopwatch.Restart();
            int k = -1;
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] == find) { k = i; break; };
            }
            stopwatch.Stop();

            Console.WriteLine("Stopwatch: " + stopwatch.ElapsedTicks.ToString());

            return k;
        }
        // Бинарный поиск
        static int binPoisk(int[] mass, int find, Stopwatch stopwatch)
        {

            stopwatch.Restart();
            int k;   // с
            int L = 0;        // левая граница
            int R = mass.Length - 1;    // правая граница
            k = (R + L) / 2;

            while (L < R - 1)
            {

                k = (R + L) / 2;
                if (mass[k] == find)
                    return k;

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

            Console.WriteLine("Stopwatch: " + stopwatch.ElapsedTicks.ToString());

            return k;
        }
    }
}



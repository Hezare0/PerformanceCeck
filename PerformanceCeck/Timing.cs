using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceCeck
{
    internal class Timing
    {

        TimeSpan duration; //хранение результата измерения
        TimeSpan[] threads; // значения времени для всех потоков процесса
        public Timing()
        {
            duration = new TimeSpan(0);
            threads = new TimeSpan[Process.GetCurrentProcess().
            Threads.Count];
        }
        public void StartTime() //инициализация массива threads после вызова сборщика мусора
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            for (int i = 0; i < threads.Length; i++)
                threads[i] = Process.GetCurrentProcess().Threads[i].
                UserProcessorTime;
        }
        public void StopTime() //повторный запрос текущего времени и выбирается тот, у которого результат отличается от
        {				//предыдущего
            TimeSpan tmp;
            for (int i = 0; i < threads.Length; i++)
            {
                tmp = Process.GetCurrentProcess().Threads[i].
                UserProcessorTime.Subtract(threads[i]);
                if (tmp > TimeSpan.Zero)
                    duration = tmp;
            }
        }

        public void reset()
        {
            duration = new TimeSpan(0);
        }
        public TimeSpan Result()
        {
            return duration;
        }


    }
}

  

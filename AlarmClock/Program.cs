using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock
{
    class Program
    {
        private static readonly TimeSpan SleepTime = TimeSpan.FromSeconds(1);

        static void Main(string[] args)
        {
            //User input
            Console.WriteLine("Alarm Clock v1.0");
            Console.WriteLine("\nAlarm 1\n");

            //Hour input
            Console.Write("Hour: ");
            int hr = int.Parse(Console.ReadLine());
            Console.WriteLine("You have entered: {0}", hr);

            //Minute input
            Console.Write("Minute: ");
            int min = int.Parse(Console.ReadLine());
            Console.WriteLine("You have entered: {0}", min);

            //AM or PM
            Console.WriteLine("PM? [Y/n]: ");

            if (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                hr += 12;
            }

            var startTime = DateTime.Now;
            var alarmTimeOfDay = new TimeSpan(hr, min, 0);

            
            Console.Clear();

            //Time testing
            do
            {
                Console.WriteLine("Start:\t\t{0}", startTime);

                //Console.WriteLine(startTime);

                Console.WriteLine("Current:\t{0}", DateTime.Now);

                Console.WriteLine("Alarm:\t\t{0:c}", alarmTimeOfDay);

                if (DateTime.Now.TimeOfDay >= alarmTimeOfDay)
                {
                    Console.WriteLine("\nAlarm1!\n");
                    
                    Console.WriteLine(@"Time elapsed from alarm: {0:H\:mm\:ss}", DateTime.Now.Subtract(alarmTimeOfDay));
                }
                
                Console.WriteLine("\n\nPress ESC to exit");

                Thread.Sleep(SleepTime);
                Console.Clear();
            } while (!ExitRequested());
        }

        private static bool ExitRequested()
        {
            return Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape;
        }
    }
}

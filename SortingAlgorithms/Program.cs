using System;
using System.Timers;
using System.Diagnostics;
namespace SortingAlgorithms
{
    public class Program
    {
        public static Stopwatch sw;
        private static System.Timers.Timer aTimer;

        static void Main()
        {
            string fileDirectory = "/Users/devinsalgado35/Desktop/SortingAlgorithms/SortingAlgorithms/scores.txt";

            sw = new Stopwatch();
            sort s = new sort();

            int[] data = s.fileCovertToArray(fileDirectory);


            //Displays Numbers in array of lines

            //s.InsertionSort(data);
            //s.SelectionSort(data);


            //SetTimer();
            sw.Start();
            //s.BubbleSort(data);
            //s.InsertionSort(data);
            //s.SelectionSort(data);
            //s.HeapSort(data);
            //s.QuickSort(data, 0, data.Length - 1);
            s.MergeSort(data, 0, data.Length -1);
            sw.Stop();
            Console.WriteLine($"\nTime taken by Bubble Sort: {sw.ElapsedMilliseconds} milliseconds");
            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            
            aTimer.Stop();

            aTimer.Dispose();
            //Console.ReadLine();

            Console.WriteLine("Terminating the application...");


            //Console.ReadKey();

        }
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }
    }
}



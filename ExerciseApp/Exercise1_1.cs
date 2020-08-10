using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseApp
{
    class Exercise1_1 : IExercise
    {
        public void Run()
        {
            double d = (double)(1 << 2);
            double e = (double)(1 << 4);

            Console.WriteLine($"Values: {e}, {d}");

            // sum
            LogWithTag<double>("SUM", d + e);
            // difference
            LogWithTag<double>("DIF", e - d);
            // fraction
            LogWithTag<double>("FRA", e / d);
            // product
            LogWithTag<double>("PRO", e * d);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit back to main menu");
            Console.ReadKey(false);
        }

        private void LogWithTag<T>(string TAG, T value)
        {
            Console.WriteLine($"{TAG.ToUpper()} { value.ToString()}");
        }
    }
}

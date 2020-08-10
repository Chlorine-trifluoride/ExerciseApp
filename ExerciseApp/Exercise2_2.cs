using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseApp
{
    class Exercise2_2 : IExercise
    {
        const int MAX_VALUE = 40;

        // This is very hacky
        public void Run()
        {
            for (int i = 2; i <= MAX_VALUE; i++)
            {
                bool isDivisible = false;

                for (int j = 2; j < i; j++)
                {
                    if (i == j)
                        continue;

                    if (i % j == 0)
                        isDivisible = true;
                }

                if (!isDivisible)
                    Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}

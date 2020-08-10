using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExerciseApp
{
    class Exercise1_2 : IExercise
    {
        private enum Weekday
        {
            UNDEFINED = 0,
            MONDAY,
            TUESDAY,
            WEDNESDAY,
            THURSDAY,
            FRIDAY,
            SATURDAY,
            SUNDAY
        }

        public void Run()
        {
            Console.WriteLine("Welcome to weekend calculator.");
            Console.WriteLine("Reply q, quit or exit to go back to main menu.");
            Console.WriteLine("-------------");

            bool exit = false;
            do
            {
                exit = DoWeekdayPrompt();
            } while (!exit);
        }

        private bool DoWeekdayPrompt()
        {
            Weekday day = Weekday.UNDEFINED;
            do
            {
                Console.WriteLine("Please enter a weekday");
                string input = Console.ReadLine().ToUpper();

                if (CheckForExitString(input)) // exit signal
                    return true;

                (bool, Weekday) validatedInput = ValidateInput(input);
                if (validatedInput.Item1)
                    day = validatedInput.Item2;
                else
                    Console.WriteLine("Invalid input...");
            } while (day == Weekday.UNDEFINED);

            int daysUntilMonday = DaysUntilDay(day, Weekday.MONDAY);
            Console.Write($"Days remaining until Monday = {daysUntilMonday}. ");
            // if the result is more than 3, print “Have a nice week!”. Otherwise, print “Have a nice weekend!”.
            if (daysUntilMonday > 3)
                Console.WriteLine("Have a nice week!");
            else
                Console.WriteLine("Have a nice weekend!");

            return false;
        }

        private (bool, Weekday) ValidateInput(string input)
        {
            if (!Enum.IsDefined(typeof(Weekday), input))
                return (false, Weekday.UNDEFINED);

            Weekday day = (Weekday)Enum.Parse(typeof(Weekday), input);
            return (true, day);
        }

        private int DaysUntilDay(Weekday currentDay, Weekday targetDay)
        {
            int daysRemaining = targetDay - currentDay;

            if (daysRemaining == 0)
                daysRemaining = 7;

            if (daysRemaining < 0) 
                daysRemaining += 7;

            return daysRemaining;
        }

        private bool CheckForExitString(string input)
        {
            switch (input.ToLower())
            {
                case "q":
                case "exit":
                case "quit":
                    return true;
            }

            return false;
        }
    }
}

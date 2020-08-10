using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseApp
{
    class Exercise1_3 : IExercise
    {
        class Log
        {
            public static void LogToConsole(string text)
            {
                if (text.Length >= 30)
                    LogToConsoleLong(text);
                else
                    LogToConsoleShort(text);
            }

            private static void LogToConsoleShort(string text)
            {
                string formattedTime = DateTime.Now.ToString("HH\\:mm\\:ss");
                Console.WriteLine($"[{formattedTime}] {text}");
            }

            private static void LogToConsoleLong(string text)
            {
                string formattedTime = DateTime.Now.ToString("HH\\:mm\\:ss");
                Console.WriteLine($"[{formattedTime}]");
                Console.WriteLine(text);
            }
        }

        public void Run()
        {
            Console.WriteLine("Welcome to a note echoer.");
            Console.WriteLine("Reply q, quit or exit to go back to main menu.");
            Console.WriteLine("-------------");

            bool exit = false;
            do
            {
                if (!DoNotesExerc())
                    exit = true;

            } while (!exit);
        }

        private bool DoNotesExerc()
        {
            Console.WriteLine("Please enter a note...");
            string input = "";
            do
            {
                input = Console.ReadLine();

                if (CheckForExitString(input))
                    return false;

            } while (input == "");

            Console.WriteLine(); // some spaces
            Log.LogToConsole(input);
            Console.WriteLine();

            return true;
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

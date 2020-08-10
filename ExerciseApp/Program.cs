using System;
using System.Runtime.CompilerServices;

namespace ExerciseApp
{
    class Program
    {
        static void DisplayAvailableCommands()
        {
            Console.Write("\n\n");
            Console.WriteLine("Available commands:");
            Console.WriteLine("[Command] \t [Function]");
            Console.WriteLine("H \t\t Displays this help message");
            Console.WriteLine("Q \t\t Exits the application");

            Console.ReadKey();
        }

        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to exercise application.");
            Console.WriteLine("Type q to exit the application");
            Console.WriteLine("Type h for a list of helpful commands");
            Console.WriteLine();
        }

        static void DisplayMainMenu()
        {
            Console.Clear();
            DisplayWelcomeMessage();
            Console.WriteLine("Choose an exercise to run: ");
            Console.WriteLine("--------------");

            Console.WriteLine("A) Double math");
            Console.WriteLine("B) Monday Calculator");
            Console.WriteLine("C) Note echo");
            Console.WriteLine("D) Prime numbers");
            Console.WriteLine("E) Note keeping program");

            var keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.A:
                    RunExercise<Exercise1_1>();
                    break;

                case ConsoleKey.B:
                    RunExercise<Exercise1_2>();
                    break;

                case ConsoleKey.C:
                    RunExercise<Exercise1_3>();
                    break;

                case ConsoleKey.D:
                    RunExercise<Exercise2_2>();
                    break;

                case ConsoleKey.E:
                    RunExercise<Exercise2_3>();
                    break;

                case ConsoleKey.Q:
                    System.Environment.Exit(0);
                    break;

                case ConsoleKey.H:
                    DisplayAvailableCommands();
                    break;

                default:
                    Console.WriteLine("Invalid input\n");
                    Console.ReadKey();
                    break;
            }
        }

        // Helper function for running the tasks and clearning the screen
        static void RunExercise(Action action)
        {
            action.Invoke();
        }

        // wub, generics
        static void RunExercise<T>() where T : IExercise, new()
        {
            Console.Clear();
            new T().Run();
        }

        static void Main(string[] args)
        {
            for (; ; )
            {
                DisplayMainMenu();
            }
        }
    }
}

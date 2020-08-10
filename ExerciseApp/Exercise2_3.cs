using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseApp
{
    class Exercise2_3
    {
        private static List<string> notes = new List<string>();

        public static void Run()
        {
            ListUserCommands();

            bool exit = false;
            do
            {
                if (!GetUserInput())
                    exit = true;

            } while (!exit);
        }

        private static void ListUserCommands()
        {
            Console.WriteLine("[Command] \t\t [Description]");
            Console.WriteLine("quit \t\t exit to main menu");
            Console.WriteLine("list \t\t list all saved notes");
            Console.WriteLine("add \t\t add a new note");
            Console.WriteLine("del \t\t remove a note with specified index");
        }

        private static bool GetUserInput()
        {
            bool extraParams = false;
            string command, text = "";

            string input = Console.ReadLine();
            int indexOfSpace = input.IndexOf(' ');

            // TODO: horrible implementation
            if (indexOfSpace != -1)
            {
                extraParams = true;
                command = input.Substring(0, indexOfSpace).ToLower();
                text = input.Substring(indexOfSpace + 1);
            }
            else
                command = input.ToLower();

            switch (command)
            {
                case "list":
                    PrintListOfNotes();
                    break;

                case "add":
                    if (!extraParams)
                        break;

                    string note = text;
                    AddNewNote(note);
                    break;

                case "del":
                    if (!extraParams)
                        break;

                    int i;
                    if (!int.TryParse(text, out i))
                        break;
                    RemoveNote(i);
                    break;

                case "q":
                case "quit":
                case "exit":
                    return false;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }

            return true;
        }

        private static void RemoveNote(int index)
        {
            if (index < notes.Count)
                notes.RemoveAt(index);

            // TODO: error
        }

        private static void AddNewNote(string note)
        {
            notes.Add(note);
        }

        private static void PrintListOfNotes()
        {
            for (int i = 0; i < notes.Count; i++)
            {
                Console.WriteLine($"{i}\t{GetStringOfMaxLen(notes[i], 30)}");
            }
        }

        private static string GetStringOfMaxLen(string text, int len)
        {
            return text.Substring(0, Math.Min(len, text.Length));
        }
    }
}

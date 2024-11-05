using System;
using System.Collections.Generic;

namespace TaskManager
{
    class Program
    {
        static List<string> tasks = new List<string>();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                SafeClear(); 
                Console.WriteLine("==== Task Manager ====");
                Console.WriteLine("1. View Tasks");
                Console.WriteLine("2. Add Task");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewTasks();
                        break;
                    case "2":
                        AddTask();
                        break;
                    case "3":
                        RemoveTask();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void SafeClear()
        {
            try
            {
                Console.Clear();
            }
            catch (IOException) // Handle if the console doesn't support clearing
            {
                // Do nothing; just avoid crashing the app
            }
        }

        static void ViewTasks()
        {
            SafeClear();
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks to show.");
            }
            else
            {
                Console.WriteLine("Tasks:");
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }
            }
            Console.WriteLine("\nPress Enter to return to the main menu.");
            Console.ReadLine();
        }

        static void AddTask()
        {
            SafeClear();
            Console.Write("Enter a new task: ");
            string newTask = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newTask))
            {
                tasks.Add(newTask);
                Console.WriteLine("Task added successfully.");
            }
            else
            {
                Console.WriteLine("Task cannot be empty.");
            }
            Console.WriteLine("Press Enter to return to the main menu.");
            Console.ReadLine();
        }

        static void RemoveTask()
        {
            SafeClear();
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks to remove.");
            }
            else
            {
                Console.WriteLine("Select a task to remove:");
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }

                Console.Write("Enter task number to remove: ");
                if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
                {
                    tasks.RemoveAt(taskNumber - 1);
                    Console.WriteLine("Task removed successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid task number.");
                }
            }
            Console.WriteLine("Press Enter to return to the main menu.");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskService taskService = new TaskService();
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("=== TaskTracker ===");
                Console.WriteLine("1) View tasks");
                Console.WriteLine("2) Add task");
                Console.WriteLine("3) Mark task as done");
                Console.WriteLine("4) Quit");
                Console.Write("Choose an option (1-4): ");

                string choice = Console.ReadLine();

                switch (choice)                                                                                                                                                   
                {
                    case "1":
                        ShowTasks(taskService);
                        break;
                    case "2":
                        AddTask(taskService);
                        break;
                    case "3":
                        CompleteTask(taskService);
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ShowTasks(TaskService service)
        {
            Console.Clear();
            Console.WriteLine("=== Your Tasks ===");

            var tasks = service.GetAllTasks();
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks yet!");
            }
            else
            {
                foreach (var task in tasks)
                {
                    Console.WriteLine(task);
                }
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        private static void AddTask(TaskService service)
        {
            Console.Clear();
            Console.WriteLine("=== Add Task ===");
            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.Write("Due date (yyyy-MM-dd) or leave blank: ");
            string dueInput = Console.ReadLine();

            DateTime? dueDate = null;

            if (!string.IsNullOrWhiteSpace(dueInput))
            {
                if (DateTime.TryParse(dueInput, out var parsedDate))
                {
                    dueDate = parsedDate;
                }
                else
                {
                    Console.WriteLine("Could not understand that date. Leaving due date empty.");
                }
            }

            try
            {
                // UPDATED: now pass dueDate into AddTask
                var task = service.AddTask(description ?? string.Empty, dueDate);
                Console.WriteLine("Added task #{0}", task.Id);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        private static void CompleteTask(TaskService service)
        {
            Console.Clear();
            Console.WriteLine("=== Complete Task ===");
            Console.Write("Enter task Id: ");
            string input = Console.ReadLine();

            int id;
            if (!int.TryParse(input, out id))
            {
                Console.WriteLine("Invalid Id.");
            }
            else
            {
                bool success = service.MarkTaskDone(id);
                Console.WriteLine(success ? "Task marked as done." : "Task not found.");
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }
}
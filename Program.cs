using ALGO_PROJECT_;
using System;

namespace ToDoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ToDoList toDoList = new ToDoList();
            string input;

            Console.WriteLine("                                                To-Do List Application");
            Console.WriteLine("All Commands: 'All Commands', 'Remove Completed Tasks', 'Add Task', 'Remove Task', 'Print All', 'Complete Task', 'Edit Task Description', 'Clear Tasks', 'Stop'");

            while (true)
            {
                Console.WriteLine("Enter a command:");
                input = Console.ReadLine().Trim().ToLower();

                if (input == "stop")
                {
                    break;
                }

                switch (input)
                {
                    case "add task":
                        Console.Write("Enter task description: ");
                        string desc = Console.ReadLine().Trim();
                        toDoList.AddTask(desc);
                        break;

                    case "remove completed tasks":
                        toDoList.RemoveCompletedTasks();
                        break;

                    case "remove task":
                        Console.Write("Enter task ID to delete:");
                        int ID = int.Parse(Console.ReadLine().Trim());
                        toDoList.RemoveTaskByID(ID);
                        break;

                    case "print all":
                        toDoList.PrintAllTasks();
                        break;

                    case "complete task":
                        Console.Write("Enter task ID to mark as completed:");
                        int ID1 = int.Parse(Console.ReadLine().Trim());
                        toDoList.MarkTask(ID1);
                        break;

                    case "edit task description":
                        Console.Write("Enter task ID to edit:");
                        int ID2 = int.Parse(Console.ReadLine().Trim());
                        Console.Write("Enter new description:");
                        string newDesc = Console.ReadLine().Trim();
                        toDoList.EditTaskDesc(ID2, newDesc);
                        break;

                    case "clear tasks":
                        toDoList.ClearTasks();
                        break;

                    case "all commands":
                        Console.WriteLine("All Commands: 'All Commands', 'Remove Completed Tasks', 'Add Task', 'Remove Task', 'Print All', 'Complete Task', 'Edit Task Description', 'Clear Tasks', 'Stop'");
                        break;

                    default:
                        Console.WriteLine("Unknown command. Please try again.");
                        break;
                }
            }

            Console.WriteLine("Exiting ToDo List Application.....");
        }
    }
}

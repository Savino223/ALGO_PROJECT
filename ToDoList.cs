using System;
using Queue;

namespace ALGO_PROJECT_
{
    public class ToDoList
    {
        private ArrayQueue<(int, string, bool)> _tasks;
        private int taskID;

        public ToDoList()
        {
            _tasks = new ArrayQueue<(int, string, bool)>();
            taskID = 1;
        }

        public void AddTask(string desc)
        {
            _tasks.Enqueue(taskID, desc, false);
            taskID++;
            Console.WriteLine("Task has been added");
            Console.WriteLine("");
        }

        public void RemoveTask()
        {
            if (_tasks.IsEmpty())
            {
                Console.WriteLine("No tasks to remove!");
                Console.WriteLine("");
                return;
            }

            _tasks.Dequeue();
            RefreshTaskIDs();
            Console.WriteLine("Task has been deleted");
            Console.WriteLine("");
        }

        public void RemoveCompletedTasks()
        {
            if (_tasks.IsEmpty())
            {
                Console.WriteLine("No tasks to remove");
                return;
            }

            int cnt = _tasks.Count;
            for (int i = 0; i < cnt; i++)
            {
                var task = _tasks.Dequeue();
                if (!task.Item3) 
                {
                    _tasks.Enqueue(task.Item1, task.Item2, task.Item3);
                }
            }

            RefreshTaskIDs();
            Console.WriteLine("Completed tasks have been deleted");
        }

        public void RemoveTaskByID(int ID)
        {
            if (_tasks.IsEmpty())
            {
                Console.WriteLine("No tasks to remove");
                return;
            }

            bool found = false;
            int cnt = _tasks.Count;
            for (int i = 0; i < cnt; i++)
            {
                var task = _tasks.Dequeue();
                if (task.Item1 != ID) 
                {
                    _tasks.Enqueue(task.Item1, task.Item2, task.Item3);
                }
                else
                {
                    found = true;
                }
            }

            RefreshTaskIDs();
            if (found)
            {
                RefreshTaskIDs();
                Console.WriteLine($"Task {ID} has been deleted");
            }
            else
            {
                Console.WriteLine($"Task {ID} not found");
            }
            Console.WriteLine("");
        }

        public void PrintAllTasks()
        {
            if (_tasks.IsEmpty())
            {
                Console.WriteLine("No tasks in the list!");
                return;
            }

            Console.WriteLine("All Tasks:");
            Console.WriteLine("");
            _tasks.Display();
        }

        public void MarkTask(int ID)
        {
            if (_tasks.IsEmpty())
            {
                Console.WriteLine("No tasks in the list!");
                Console.WriteLine("");
                return;
            }

            bool found = false;
            for (int i = 0; i < _tasks.Count; i++)
            {
                var task = _tasks.Dequeue();
                if (task.Item1 == ID)
                {
                    task = (task.Item1, task.Item2, true);
                    found = true;
                }
                _tasks.Enqueue(task.Item1, task.Item2, task.Item3);
            }

            if (found)
            {
                Console.WriteLine($"Task {ID} has been marked!");
            }
            else
            {
                Console.WriteLine($"Task {ID} has not been found!");
            }
            Console.WriteLine("");
        }

        public void EditTaskDesc(int ID, string desc)
        {
            if (_tasks.IsEmpty())
            {
                Console.WriteLine("No tasks in the list!");
                Console.WriteLine("");
                return;
            }

            bool changed = false;
            for (int i = 0; i < _tasks.Count; i++)
            {
                var task = _tasks.Dequeue();
                if (task.Item1 == ID)
                {
                    task = (task.Item1, desc, task.Item3);
                    changed = true;
                }
                _tasks.Enqueue(task.Item1, task.Item2, task.Item3);
            }

            if (changed)
            {
                Console.WriteLine($"Description of task {ID} has been changed!");
            }
            else
            {
                Console.WriteLine($"Task {ID} has not been found!");
            }
            Console.WriteLine("");
        }

        public void ClearTasks()
        {
            while (!_tasks.IsEmpty())
            {
                _tasks.Dequeue();
            }

            Console.WriteLine("All tasks have been removed!!");
            Console.WriteLine("");
        }

        private void RefreshTaskIDs()
        {
            int newID = 1;
            for (int i = 0; i < _tasks.Count; i++)
            {
                var task = _tasks.Dequeue();
                _tasks.Enqueue(newID, task.Item2, task.Item3);
                newID++;
            }
        }
    }
}

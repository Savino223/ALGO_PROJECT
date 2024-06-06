- Group: SEST 2-22
- Subject: Algorithms and data structures 2
- Console Application Using Data Structures
- Project Theme: To-Do List application using Queue

- Overview
This is a console-based task management application that allows users to add, remove, edit, and manage their tasks. It uses a custom queue implementation to manage tasks.

- Code Structure
- Files:
- 
1. ToDoList.cs: Contains the main class for managing the to-do list and task operations.
2. queue.cs: Contains the ArrayQueue<T> class, a custom queue used by the ToDoList.
3. Program.cs: Contains the main program that interacts with the user via the console.

- Classes:

ToDoList:

- _tasks: An instance of ArrayQueue<(int, string, bool)> to hold the tasks.
- taskID: A counter for generating unique task IDs.
 
Methods:

- AddTask(string desc): Adds a new task with the given description.
- RemoveTask(): Removes the task at the front of the queue.
- RemoveCompletedTasks(): Removes all tasks that are marked as completed.
- RemoveTaskByID(int ID): Removes a task by its ID.
- PrintAllTasks(): Prints all tasks in the list.
- MarkTask(int ID): Marks a task as completed by its ID.
- EditTaskDesc(int ID, string desc): Edits the description of a task by its ID.
- ClearTasks(): Removes all tasks from the list.
- RefreshTaskIDs(): Refreshes task IDs to ensure they are sequential after deletions.

ArrayQueue:

- items: An array to store queue items.
- front, back, capacity, count: Variables to manage the queue state.
initCap: Initial capacity of the queue.

Methods:

- Enqueue(int value, string txt, bool bl): Adds an item to the queue.
- Dequeue(): Removes and returns the item at the front of the queue.
- Peek(): Returns the item at the front without removing it.
- IsEmpty(): Checks if the queue is empty.
- MakeBigger(): Increases the capacity of the queue.
- Display(): Displays all items in the queue.

Available Commands:

- Add Task: Prompts for a task description and adds it to the list.
- Remove Task: Prompts for a task ID and removes the corresponding task.
- Remove Completed Tasks: Removes all tasks marked as completed.
- Print All: Displays all tasks with their statuses.
- Complete Task: Prompts for a task ID and marks it as completed.
- Edit Task Description: Prompts for a task ID and a new description, then updates the task.
- Clear Tasks: Removes all tasks from the list.
- All Commands: Displays all available commands.
- Stop: Exits the application.

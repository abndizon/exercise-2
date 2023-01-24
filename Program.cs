using ExerciseTwo.Models;

namespace ExerciseTwo
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<ToDoList> myLists = new List<ToDoList>();
            bool displayMenu = true;

            while (displayMenu)
            {
                Console.WriteLine("============ MAIN MENU ============");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1 - Display All Lists");
                Console.WriteLine("2 - Show Items");
                Console.WriteLine("3 - Create New List");
                Console.WriteLine("4 - Select List");
                Console.WriteLine("5 - Quit");
                Console.WriteLine("==============================");
                Console.Write("Enter number: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                int listId = 0;

                if (choice == 1)
                {
                    if (myLists.Count > 0)
                    {
                        Console.WriteLine("DISPLAYING LIST..");
                        for (int i = 0; i < myLists.Count; i++)
                        {
                            ToDoList tdl = myLists[i];
                            Console.WriteLine($"======== List ID: {tdl.Id} ========");
                            Console.WriteLine($"Name: {tdl.Name}");
                            Console.WriteLine($"Number of items: {tdl.ToDoItems.Count}");
                        }
                    }
                    else {
                        Console.WriteLine("List is currently empty");
                    }
                }
                else if (choice == 2)
                {
                    Console.Write("Enter ID of List: ");
                    listId = Convert.ToInt32(Console.ReadLine());

                    ToDoList tdl = myLists.SingleOrDefault(x => x.Id == listId);

                    if (tdl == null)
                    {
                        Console.WriteLine($"ERROR. List ID {listId} not found.");
                    }
                    else
                    {
                        ShowItems(tdl);
                    }
                }
                else if (choice == 3)
                {
                    Console.Write("Enter Name of List: ");
                    string listName = Console.ReadLine();

                    int id = myLists.Count + 1;
                    ToDoList tdl = new ToDoList(id, listName);
                    myLists.Add(tdl);
                    Console.WriteLine($"LIST {tdl.Name} CREATED");
                }
                else if (choice == 4)
                {
                    Console.Write("Enter ID of List: ");
                    listId = Convert.ToInt32(Console.ReadLine());

                    ToDoList tdl = myLists.SingleOrDefault(x => x.Id == listId);

                    if (tdl == null)
                    {
                        Console.WriteLine($"ERROR. List ID {listId} not found.");
                    }
                    else
                    {
                        bool displaySecondMenu = true;

                        while (displaySecondMenu)
                        {
                            Console.WriteLine("============ LIST MENU ============");
                            Console.WriteLine($"======== List ID: {tdl.Id} ========");
                            Console.WriteLine("What would you like to do to this list?");
                            Console.WriteLine("1 - Display All Items");
                            Console.WriteLine("2 - Create New Item");
                            Console.WriteLine("3 - Delete Item");
                            Console.WriteLine("4 - Update Item");
                            Console.WriteLine("5  - Go Back");
                            Console.WriteLine("==============================");
                            Console.Write("Enter number: ");
                            int secondMenuChoice = Convert.ToInt32(Console.ReadLine());

                            if (secondMenuChoice == 1)
                            {
                                ShowItems(tdl);
                            }
                            else if (secondMenuChoice == 2)
                            {
                                Console.Write("Enter Item content: ");
                                string content = Console.ReadLine();
                                int id = tdl.ToDoItems.Count + 1;

                                TodoItem item = new TodoItem(id, content);
                                tdl.AddTodoItem(item);
                                Console.WriteLine($"ITEM {item.Content} CREATED");
                            }
                            else if (secondMenuChoice == 3)
                            {
                                Console.Write("Enter ID of Item to delete: ");
                                int id = Convert.ToInt32(Console.ReadLine());

                                if (FindItem(tdl, id) != null)
                                {
                                    tdl.RemoveTodoItem(id);
                                    Console.WriteLine($"ITEM ID {id} DELETED");
                                }
                            }
                            else if (secondMenuChoice == 4)
                            {
                                Console.Write("Enter ID of Item to update: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                TodoItem item = FindItem(tdl, id);

                                if (item != null)
                                {
                                    item.Update();
                                    Console.WriteLine($"ITEM ID {id} UPDATED");
                                }
                            }
                            else if (secondMenuChoice == 5)
                            {
                                displaySecondMenu = false;
                            }
                            else
                            {
                                Console.WriteLine("ERROR. Invalid Choice.");
                            }
                        }
                    }
                }
                else if (choice == 5)
                {
                    displayMenu = false;
                }
                else
                {
                    Console.WriteLine("ERROR. Invalid Choice");
                }
            }
        }

        public static void ShowItems(ToDoList tdl)
        {
            if (tdl.ToDoItems.Count > 0)
            {
                Console.WriteLine($"DISPLAYING ITEMS FOR LIST ID {tdl.Id}..");
                foreach (TodoItem item in tdl.ToDoItems)
                {
                    Console.WriteLine($"======== Item ID: {item.Id} ========");
                    Console.WriteLine($"Content: {item.Content}");
                    Console.WriteLine($"Status: {item.Status}");
                }
            }
            else
            {
                Console.WriteLine($"No items found for list {tdl.Name}");
            }
        }

        public static TodoItem FindItem(ToDoList tdl, int id)
        {
            TodoItem item = tdl.ToDoItems.SingleOrDefault(x => x.Id == id);

            if (item == null)
            {
                Console.WriteLine($"ERROR. Item ID {id} is Invalid.");
            }

            return item;
        }
    }
}
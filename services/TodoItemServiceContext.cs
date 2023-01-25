using ExerciseTwo.Interfaces;
using ExerciseTwo.Models;
using ExerciseTwo.Conf;

namespace ExerciseTwo.Services {
    public class TodoItemServiceContext : ITodoItemService
    {   
        private TodoListServiceContext todoListServiceContext;
        public TodoItemServiceContext() {
            todoListServiceContext = new TodoListServiceContext();
        }
        
        public void Delete(int listId, TodoItem item)
        {
            ToDoList tdl = todoListServiceContext.FindById(listId);
            tdl.RemoveTodoItem(item.Id);
        }

        public TodoItem FindById(int listId, int id)
        {
            ToDoList tdl = todoListServiceContext.FindById(listId);
            TodoItem item = tdl.ToDoItems.SingleOrDefault(x => x.Id == id);

            return item;
        }

        public List<TodoItem> GetAll(int listId)
        {
            ToDoList tdl = todoListServiceContext.FindById(listId);
            return tdl.ToDoItems;
        }

        public TodoItem Save(int listId, TodoItem item)
        {
            ToDoList tdl = todoListServiceContext.FindById(listId);
            tdl.AddTodoItem(item);

            return item;
        }
    }
}
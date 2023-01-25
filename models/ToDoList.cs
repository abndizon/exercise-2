namespace ExerciseTwo.Models {
    public class ToDoList {
        public int Id {
            get; private set;
        }

        public string Name {
           get; private set;
        }

        public List<TodoItem> ToDoItems {
            get; private set;
        }

        public ToDoList(int id, string name) {
            Id = id;
            Name = name;

            ToDoItems = new List<TodoItem>();
        }

        public void AddTodoItem(TodoItem item) {
            ToDoItems.Add(item);
        }

        public void RemoveTodoItem(int id) {
            TodoItem toDoMatch = ToDoItems.Single(x => x.Id == id);
            ToDoItems.Remove(toDoMatch);
        }
    }
}
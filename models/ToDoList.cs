namespace ExerciseTwo.Models {
    public class ToDoList {
        private int id;
        private string name;
        private List<TodoItem> todoItems;

        public int Id {
            get {
                return this.id;
            }
        }

        public string Name {
            get {
                return this.name;
            }
        }

        public List<TodoItem> ToDoItems {
            get {
                return this.todoItems;
            }
        }

        public ToDoList(int id, string name) {
            this.id = id;
            this.name = name;

            todoItems = new List<TodoItem>();
        }

        public void AddTodoItem(TodoItem item) {
            todoItems.Add(item);
        }

        public void RemoveTodoItem(int id) {
            TodoItem toDoMatch = todoItems.Single(x => x.Id == id);
            todoItems.Remove(toDoMatch);
        }
    }
}
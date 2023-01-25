using ExerciseTwo.Models;

namespace ExerciseTwo.Interfaces {
    public interface ITodoItemService {
        public List<TodoItem> GetAll(int listId);
        public TodoItem FindById(int listId, int id);
        public TodoItem Save(int listId, TodoItem item);
        public void Delete(int listId, TodoItem item);
    }
}
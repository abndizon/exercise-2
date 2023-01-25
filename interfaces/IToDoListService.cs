using ExerciseTwo.Models;

namespace ExerciseTwo.Interfaces {
    public interface IToDoListService {
        public List<ToDoList> GetAll();
        public ToDoList FindById(int id);
        public ToDoList Save(ToDoList list);
        public void Delete(int id);
    }
}
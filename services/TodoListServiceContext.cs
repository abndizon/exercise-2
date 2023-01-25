using ExerciseTwo.Interfaces;
using ExerciseTwo.Models;
using ExerciseTwo.Conf;

namespace ExerciseTwo.Services {
    public class TodoListServiceContext : IToDoListService
    {
        private ApplicationContext appInstance;
        private List<ToDoList> toDoLists;

        public TodoListServiceContext() {
            appInstance = ApplicationContext.Instance;
            toDoLists = appInstance.GetToDoLists();
        }

        public void Delete(int id)
        {
            ToDoList toDoListMatch = toDoLists.SingleOrDefault(x => x.Id == id);
            toDoLists.Remove(toDoListMatch);
        }

        public ToDoList FindById(int id)
        {
            ToDoList tdl = toDoLists.SingleOrDefault(x => x.Id == id);

            return tdl;
        }

        public List<ToDoList> GetAll()
        {
            return this.toDoLists;
        }

        public ToDoList Save(ToDoList list)
        {
            toDoLists.Add(list);
            return list;
        }
    }
}
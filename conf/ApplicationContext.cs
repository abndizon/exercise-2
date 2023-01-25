using ExerciseTwo.Models;

namespace ExerciseTwo.Conf
{
    public class ApplicationContext
    {
        private List<ToDoList> myLists;
        
        private static ApplicationContext instance = null;

        public static ApplicationContext Instance
        {
            get {
                if (instance == null) {
                    instance = new ApplicationContext();
                }
                return instance;
            }
        }

        public ApplicationContext()
        {
            this.myLists = new List<ToDoList>();
        }

        public List<ToDoList> GetToDoLists()
        {
            return this.myLists;
        }
    }
}
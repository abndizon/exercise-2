namespace ExerciseTwo.Models {
    public class TodoItem {
        public int Id {
            get; private set;
        }

        public string Content {
            get; private set;
        }

        public string Status {
            get; private set;
        }

        public TodoItem(int id, string content) {
            Id = id;
            Content = content;
            Status = "pending";
        }

        public bool Update() {
            if (Status == "pending") {
                Status = "active";
                return true;
            }
            else if (Status == "active") {
                Status = "done";
                return true;
            }
            else {
                return false;
            }
        }
    }
}
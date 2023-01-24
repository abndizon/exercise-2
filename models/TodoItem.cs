namespace ExerciseTwo.Models {
    public class TodoItem {
        private int id;
        private string content;
        private string status;

        public int Id {
            get {
                return this.id;
            }
        }

        public string Content {
            get {
                return this.content;
            }
        }

        public string Status {
            get {
                return this.status;
            }
        }

        public TodoItem(int id, string content) {
            this.id = id;
            this.content = content;
            this.status = "pending";
        }

        public bool Update() {
            if (status == "pending") {
                status = "active";
                return true;
            }
            else if (status == "active") {
                status = "done";
                return true;
            }
            else {
                return false;
            }
        }
    }
}
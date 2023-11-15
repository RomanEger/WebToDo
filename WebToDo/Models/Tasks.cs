namespace WebToDo.Models
{
    public class Tasks
    {
        private static int id;
        public int Id { get { return id; } set { if (value > 0) id = value; } }

        private int id_User;
        public int UserId { get { return id_User; } set {if(value>0) id_User=value; } }

        private string title = string.Empty;
        public string Title { 
            get { return title; } 
            set { if (string.IsNullOrEmpty(value))
                    if (content.Length >= 100)
                        title = content.Substring(0, 99);
                    else
                        title = content;
                  else
                    title = value;
            } }

        private string content = string.Empty;
        public string Content { get { return content; } set { if(!string.IsNullOrEmpty(value))content = value;} }

        private static bool isCompleted;
        public bool IsCompleted { get { return isCompleted; } 
            set { isCompleted = value; } }
    }
}

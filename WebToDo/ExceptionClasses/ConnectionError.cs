namespace WebToDo.ExceptionClasses
{
    public class ConnectionError : Exception
    {
        public ConnectionError(string message = "Проблема с подключением к БД")
       : base(message) { }
    }
}

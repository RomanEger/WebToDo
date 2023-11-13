namespace WebToDo.ExceptionClasses
{
    public class EmailException : Exception
    {
        public EmailException(string message = "Некорректный email адрес")
       : base(message) { }
    }
}

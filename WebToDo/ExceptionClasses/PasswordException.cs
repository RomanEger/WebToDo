namespace WebToDo.ExceptionClasses
{
    public class PasswordException : Exception
    {
        public PasswordException(string message = "Пароль должен включать не менее 4 символов, включать символы латинского алфавита и числа")
       : base(message) { }
    }
}

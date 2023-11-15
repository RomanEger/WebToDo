using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using WebToDo.ExceptionClasses;
namespace WebToDo.Models
{
    public class Users
    {
        public Users() { }

        public Users(string email, string password)
        {
            Email = email;
            Password = password;
        }

        private bool IsValidEmail(string email)
        {
            Regex regex = new Regex("^([\\w.-]+)([@][a-z.-]+)([.]+[a-z]{2,6})$");
            if (regex.IsMatch(email))
                return true;
            return false;
        }

        private bool IsValidPasword(string password)
        {
            Regex regex = new Regex("^(?=.*[a-zA-Z])(?=.*\\d)(?!.*\\s).*.{4,20}$");
            if (regex.IsMatch(password))
                return true;
            return false;
        }
        int id;
        public int Id { get { return id; } set { if(value>0)id = value; } }

        string email = string.Empty;
        public string Email
        {
            get { return email; }
            set
            {
                if (IsValidEmail(value))
                    email = value;
                else
                    throw new EmailException();
            }
        }

        string password = string.Empty;
        [StringLength(20, ErrorMessage = "Минимум {2}, максимум {1}", MinimumLength = 4)]
        public string Password
        {
            get { return password; }
            set
            {
                if (IsValidPasword(value))
                    password = value;
                else
                    throw new PasswordException();
            }
        }
    }
}

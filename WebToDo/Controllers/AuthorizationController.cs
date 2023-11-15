using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebToDo.Models;
using WebToDo.Services;

namespace WebToDo.Controllers
{
    public class AuthorizationController : Controller
    {
        private IUserData users;

        public AuthorizationController(IUserData users)
        {
            this.users = users;
        }

        [Route("[action]")]
        public IActionResult Login()
        {
            return View();
        }

        //[Route("[action]")]
        //public async Task<IActionResult> Auth(string email, string password)
        //{
        //    try
        //    {
        //        var users = await this.users.Select(email, password);
        //        if (users > 0)
        //            return View("~/Views/Main/TaskList.cshtml", await this.users.SelectUserTasks(users));
        //        else
        //            return View("Login");
        //    }
        //    catch
        //    {
        //        return View("Login");
        //    }
            
        //}

        [Route("[action]")]
        public IActionResult Registration()
        {
            return View();
        }

        [Route("[action]")]
        public async Task<IActionResult> Reg(string email, string password, string passwordRepeat)
        {
            if(password != passwordRepeat)
            {
                var regError = new RegistrationError();
                regError.Description = "Пароли не совпадают";
                return View("Registration", regError);
            }
            try
            {
                Users user = new(email, password);
                var userId = await users.Add(user);
                if (userId > 0)
                    return View("Login");
                var regError = new RegistrationError();
                regError.Description = "Этот логин уже занят";
                return View("Registration", regError);
            }
            catch (SqlException)
            {
                var regError = new RegistrationError();
                regError.Description = "Этот логин уже занят";
                return View("Registration", regError);
            }
            catch (Exception ex) 
            {
                var regError = new RegistrationError();
                regError.Description = ex.Message;
                return View("Registration", regError);
            }            
        }
    }
}

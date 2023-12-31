﻿using Microsoft.AspNetCore.Mvc;
using WebToDo.Models;
using WebToDo.Services;

namespace WebToDo.Controllers
{
    public class MainController : Controller
    {
        private ITaskData tasks;
        public MainController(ITaskData tasks)
        {
            this.tasks = tasks;
        }
        [NonAction]
        public static void SetData(string email, string password)
        {
            _email = email;
            _password = password;
        }
        private static int _userId;
        private static string _email;
        private static string _password;
        [Route("[action]")]
        public async Task<IActionResult> TaskList(string email=null, string password=null)
        {
            if(email!= null &&  password!= null)
            {
                SetData(email, password);
            }
            int idUser = await tasks.GetUserId(_email, _password);
            if (idUser == 0)
            {
                return View("/Views/Authorization/Login.cshtml");
            }
            var list = await tasks.GetAll(idUser);
            _userId = idUser;
            return View(list);
        }

        [Route("[action]")]
        public async Task<IActionResult> EditTask(int id)
        {
            var task = await tasks.Get(id);
            task.IdUser = _userId;
            return View("EditTask", task);
        }


        [Route("[action]")]
        public async Task<IActionResult> UpdateTask(int id, int idUser, string title, string content, bool isCompleted)
        {

            var task = new Tasks()
            {
                Id = id,
                IdUser = _userId,
                Title = title,
                Content = content,
                IsCompleted = isCompleted
            };
            await tasks.Update(task);
            var list = await tasks.GetAll(_userId);
            return View("TaskList", list);
        }

        [Route("[action]")]
        public async Task<IActionResult> DelTask(int id)
        {

            var task = await tasks.Get(id);
            bool isComleted = task.IsCompleted;
            if (isComleted)
                await tasks.Delete(task);
            var list = await tasks.GetAll(_userId);
            return View("TaskList", list);
        }

        [Route("[action]")]
        public IActionResult GetPageAddTask()
        {
            return View("AddTask");
        }

        [Route("[action]")]
        public async Task<IActionResult> AddTask(string title, string content, bool isCompleted)
        {
            var task = new Tasks()
            {
                IdUser = _userId,
                Title = title,
                Content = content,
                IsCompleted = isCompleted
            };
            await tasks.Add(task);
            var list = await tasks.GetAll(_userId);
            return View("TaskList", list);
        }
    }
}

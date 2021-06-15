using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TM__TaskManager.Models;
using TM__TaskManager.Repositories;

namespace TM__TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private UserManager<IdentityUser> userManager;
        public TaskController(ITaskRepository taskRepository, UserManager<IdentityUser> usrMgr)
        {
            this.userManager = usrMgr;
            _taskRepository = taskRepository;
        }
        // GET: TaskController
        [Authorize]
        public ActionResult Index()
        {
            return View(_taskRepository.GetUserActiveTasks(userManager.GetUserId(User)));
        }
        // GET: TaskController/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View(_taskRepository.Get(id));
        }
        // GET: TaskController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View(new TaskModel());
        }
        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel taskModel)
        {   
            taskModel.UserID = userManager.GetUserId(User);
            _taskRepository.Add(taskModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: TaskController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_taskRepository.Get(id));
        }

        // POST: TaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel taskModel)
        {
            _taskRepository.Update(id, taskModel);
            return RedirectToAction(nameof(Index));

        }

        // GET: TaskController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_taskRepository.Get(id));
        }

        // POST: TaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskModel taskModel)
        {
            _taskRepository.Delete(id);
            return RedirectToAction(nameof(Index));


        }
    }
}

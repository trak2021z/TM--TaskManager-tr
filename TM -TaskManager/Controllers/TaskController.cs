using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TM__TaskManager.Models;

namespace TM__TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private static IList<TaskModel> tasks = new List<TaskModel>()
    {
         new TaskModel(){ TaskID = 1, TaskName= " Wizyta u lekarza",Description = " Sróda godzina 15:00" },
         new TaskModel(){ TaskID = 2, TaskName= " Siłownia",Description = " Sróda godzina 16:00" }
    };


        // GET: TaskController
        public ActionResult Index()
        {
            return View(tasks);
        }

        // GET: TaskController/Details/5
        public ActionResult Details(int id)
        {
            return View(tasks.FirstOrDefault(x => x.TaskID == id));
        }

        // GET: TaskController/Create
        public ActionResult Create()
        {
            return View(new TaskModel()) ;
        }

        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel taskModel)
        {
            taskModel.TaskID = tasks.Count + 1;
            tasks.Add(taskModel);

            return RedirectToAction(nameof(Index));

        }

        // GET: TaskController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(tasks.FirstOrDefault(x => x.TaskID == id));
        }

        // POST: TaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel taskModel)
        {
            TaskModel task = tasks.FirstOrDefault(x => x.TaskID == id);
            task.TaskName = taskModel.TaskName;
            task.Description = taskModel.Description;
            return RedirectToAction(nameof(Index));

        }

        // GET: TaskController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(tasks.FirstOrDefault(x => x.TaskID == id));
        }

        // POST: TaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskModel taskModel)
        {
            TaskModel task = tasks.FirstOrDefault(x => x.TaskID == id);
            tasks.Remove(task);
            return RedirectToAction(nameof(Index));


        }
    }
}

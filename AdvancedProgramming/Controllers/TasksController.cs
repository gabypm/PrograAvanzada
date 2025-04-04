using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Data.Entity;
using System.Net;
using System.Linq;
using System.Web.Mvc;
using AdvancedProgramming.Data;
using AdvancedProgramming.Helpers;
using AdvancedProgramming.Service;
using AdvancedProgramming.ViewModels;
using Microsoft.Ajax.Utilities;

namespace AdvancedProgramming.Controllers
{
    public class TasksController : Controller
    {
        private EntitiesDB db = new EntitiesDB();
        private readonly NotificationService _notificationService;

        public TasksController()
        {
            _notificationService = new NotificationService();

        }
        // GET: Tasks
        //  public ActionResult Index()
        //{
        //  var taskViewModels = new List<TaskViewModel>();
        //_notificationService.GetAllNotificationTasks()
        //  .ForEach(x => taskViewModels.Add(TaskConverter.ToTaskViewModel(x)));

        //return View(taskViewModels);
        //}
        //TODO: Single responsibility-- El controlador nos indica que es responsable de las solicitudes
        //Get que son enlazadas al index

        public ActionResult Index(int taskCount = 50)  {
            var taskGenerator = new TaskGenerator();
            // var taskViewModels = taskGenerator.GenerateRandomTasks(taskCount);
            return View();
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Status,DueDate,CreatedAt")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(task);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Status,DueDate,CreatedAt")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

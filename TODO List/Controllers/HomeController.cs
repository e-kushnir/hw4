using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TODO_List.Models;

namespace TODO_List.Controllers
{
    public class HomeController : Controller
    {
        static List<ToDoItem> TodoList = new List<ToDoItem>();

        public ActionResult Index()
        {
            return View(TodoList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ToDoItem item)
        {
            var lastItem = TodoList.LastOrDefault();
            item.Id = lastItem == null ? 0: lastItem.Id+1;
            TodoList.Add(item);
            return RedirectToAction("Details", new { item.Id });
        }

        public ActionResult Details(int id)
        {
            return View(TodoList.Find(i => i.Id == id));
        }

        public ActionResult Edit(int id)
        {
            return View(TodoList.Find(i=>i.Id == id));
        }

        [HttpPost]
        public ActionResult Edit(ToDoItem item)
        {
            var todoItem = TodoList.Find(i => i.Id == item.Id);
            todoItem.Caption = item.Caption;
            todoItem.Description = item.Description;
            todoItem.IsDone = item.IsDone;
            return RedirectToAction("Details", new { item.Id });
        }

        public ActionResult Delete(int id)
        {
            return View(TodoList.Find(i => i.Id == id));
        }

        [HttpPost]
        public ActionResult Delete(ToDoItem item)
        {
            TodoList.RemoveAll(i => i.Id == item.Id);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
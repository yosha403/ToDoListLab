using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListLab.Models;

namespace ToDoListLab.Controllers
{
    public class ToDoController : Controller
    {
        ToDoDAL tdal = new ToDoDAL();
        EmployeeDAL edal = new EmployeeDAL();
        AssignmentDAL adal = new AssignmentDAL();
        public IActionResult Index()
        {
            List<ToDo> toDos = tdal.GetToDos();
            return View(toDos);
        }
        public IActionResult Create()
        {
            //ViewData["Carowners"] = coDAL.GetCarowners();
            return View();
        }
        [HttpPost]
        public IActionResult Create(ToDo t)
        {
            tdal.AddToDo(t);           
            return RedirectToAction("Index", "ToDo");
        }
        public IActionResult Delete(int id)
        {
            tdal.DeleteToDo(id);           
            return RedirectToAction("Index", "ToDo");
        }
        public IActionResult Details(int id)
        {
            ToDo t = tdal.GetToDo(id);           
            return View(t);
        }
        public IActionResult Edit(int id)
        {
            //ViewData["Carowners"] = coDAL.GetCarowners();
            ToDo t = tdal.GetToDo(id);           
            return View(t);
        }

        [HttpPost]
        public IActionResult Edit(ToDo t)
        {
            tdal.UpdateToDo(t);         
            return RedirectToAction("Index", "ToDo");
        }
        public IActionResult AssignTask()
        {
            ViewData["employees"] = edal.GetEmployees();
            ViewData["tasks"] = tdal.GetToDos();
            return View();
        }

        [HttpPost]
        public IActionResult AssignTask(Assignment a)
        {
            adal.CreateAssignment(a);           
            return RedirectToAction("Index", "Home");
        }
    }
}

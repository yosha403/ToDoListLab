using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListLab.Models;

namespace ToDoListLab.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL dbEmployee = new EmployeeDAL();
        public IActionResult Index()
        {
            List<Employee> employees = dbEmployee.GetEmployees();
            return View(employees);
        }
        public IActionResult Create()
        {
            //ViewData["Carowners"] = coDAL.GetCarowners();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee e)
        {
            dbEmployee.AddEmployee(e);
            return RedirectToAction("Index", "Employee");
        }
        public IActionResult Delete(int id)
        {
            dbEmployee.DeleteEmployee(id);            
            return RedirectToAction("Index", "Employee");
        }
        public IActionResult Details(int id)
        {
            Employee e = dbEmployee.GetEmployee(id);
            return View(e);
        }
        public IActionResult Edit(int id)
        {
            //ViewData["Carowners"] = coDAL.GetCarowners();
            Employee e = dbEmployee.GetEmployee(id);          
            return View(e);
        }

        [HttpPost]
        public IActionResult Edit(Employee e)
        {
            dbEmployee.UpdateEmployee(e);           
            return RedirectToAction("Index", "Employee");
        }
    }
}

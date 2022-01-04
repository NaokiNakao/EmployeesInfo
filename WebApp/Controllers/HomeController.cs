using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using static BusinessLogic.Repository.EmployeeRepository;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Employee/ViewEmployeeList
        public ActionResult ViewEmployeeList()
        {
            ViewBag.Message = "Employee List";

            var data = GetEmployees();
            List<EmployeeModel> employees = new List<EmployeeModel>();
            
            foreach (var row in data)
            {
                employees.Add(new EmployeeModel
                {
                    EmployeeId = row.EmployeeId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    EmailAddress = row.EmailAddress,
                    Location = row.Location,
                });
            }

            return View(employees);
        }

        // GET: Employee/AddNewEmployee
        public ActionResult AddNewEmployee()
        {
            ViewBag.Message = "New Employee";

            return View();
        }

        // POST: Employee/AddNewEmployee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewEmployee(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateEmployee(
                    model.EmployeeId,
                    model.FirstName,
                    model.LastName,
                    model.EmailAddress,
                    model.Location);

                ViewBag.Message = "Records added successfully.";

                return RedirectToAction("ViewEmployeeList");
            }

            return View();
        }
    }
}
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
            ViewBag.Message = "Employee List.";

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
    }
}
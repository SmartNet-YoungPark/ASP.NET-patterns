using OperationsInMVC.Models;
using OperationsInMVC.DAL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OperationsInMVC.Controllers
{ 
   
    public class DepartmentsController : Controller
    {
       
        public ActionResult Index()
            {
            EmployeeDBEntities dbContext = new EmployeeDBEntities();
            List<Department> listDepartments = dbContext.Departments.ToList();
    //        List<Employee> listEmployee = dbContext.Employees.ToList();
            return View(listDepartments);
            }
        
    }
}
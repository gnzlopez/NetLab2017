using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Employees()
        {
            return View(PruebaListaEmpleados.list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Countries = PruebaListaEmpleados.countries;
            return View(new EmployeeModel());
        }

        [HttpGet]
        public ActionResult Modify(int? Id)
        {
            var emp = PruebaListaEmpleados.list.FirstOrDefault(c => c.Id == Id);
            ViewBag.Countries = PruebaListaEmpleados.countries;
            return View("Create", emp);
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            model.Id = PruebaListaEmpleados.list.Count + 1;
            PruebaListaEmpleados.list.Add(model);
            ViewBag.Countries = PruebaListaEmpleados.countries;
            return View("Employees", PruebaListaEmpleados.list);
        }

        //[HttpPost]
        //public ActionResult Add()
        //{
        //    var model = new EmployeeModel
        //    {
        //        Id = PruebaListaEmpleados.list.Count() + 1,
        //        FirstName = FirstName,
        //        LastName = LastName,
        //        Country = new CountryModel { Name = Country },
        //        EntryDate = EntryDate
        //    };

        //    PruebaListaEmpleados.list.Concat(new List<EmployeeModel> { model });
        //    return View("Employees", PruebaListaEmpleados.list);
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ShiftController : Controller
    {
        public ActionResult Shifts()
        {
            return View();
        }

        public ActionResult NightShift()
        {
            var a = PruebaListaEmpleados.list.Where(c => c.WorkShift == Shift.NightShift);

            return View("Shifts", a);
        }

        public ActionResult LateShift()
        {

            var a = PruebaListaEmpleados.list.Where(c => c.WorkShift == Shift.LateShift);
            return View("Shifts", a);
        }

        public ActionResult MorningShift()
        {

            var a = PruebaListaEmpleados.list.Where(c => c.WorkShift == Shift.MorningShift);
            return View("Shifts", a);
        }

              
    }
}
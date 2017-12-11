using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class PruebaListaEmpleados
    {

        public static List<EmployeeModel> list = new List<EmployeeModel> { new EmployeeModel()
            {
                Id = 1,
                FirstName = "Gonzalo",
                LastName = "Lopez",
                Country = "Argentina",
                WorkShift = Shift.MorningShift,
                EntryHour = DateTime.Parse("9/12/2017 9:50"),
                ExitHour = DateTime.Parse("9/12/2017 13:54")
            },
            new EmployeeModel()
            {
                Id = 1,
                FirstName = "Gonzalo",
                LastName = "Lopez",
                Country = "Argentina",
                WorkShift = Shift.NightShift,
                EntryHour = DateTime.Parse("9/12/2017 9:50"),
                ExitHour = DateTime.Parse("9/12/2017 13:54")
            },
            new EmployeeModel()
            {
                Id = 2,
                FirstName = "Sergio",
                LastName = "Lopez",
                Country ="Argentina",
                WorkShift = Shift.NightShift,
                EntryHour = DateTime.Parse("9/12/2017 9:50"),
                ExitHour = null
            },
            new EmployeeModel()
            {
                Id = 3,
                FirstName = "Sergio",
                LastName = "Lopez",
                Country = "Argentina",
                WorkShift = Shift.LateShift,
                EntryHour = DateTime.Parse("9/12/2017 9:50"),
                ExitHour = null
            },
            new EmployeeModel()
            {
                Id = 4,
                FirstName = "Silvia",
                LastName = "Carrasco",
                Country = "Argentina",
                WorkShift = Shift.MorningShift,
                EntryHour = null,
                ExitHour = null
            },
            new EmployeeModel()
            {
                Id = 5,
                FirstName = "Silvia",
                LastName = "Carrasco",
                Country = "Argentina",
                WorkShift = Shift.LateShift,
                EntryHour = null,
                ExitHour = null
            } };

        public static IEnumerable<string> countries = new List<string>
        {
            "Argentina",
            "Alemania",
            "Brasil",
            "EEUU"
        };


    }
}
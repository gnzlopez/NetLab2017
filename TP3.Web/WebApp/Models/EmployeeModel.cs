using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateTime? EntryDate { get; set; }
        public Shift WorkShift { get; set; }
        public DateTime? EntryHour { get; set; }
        public DateTime? ExitHour { get; set; }
    }

    public enum Shift
    {
        NightShift,
        LateShift,
        MorningShift
    }

}
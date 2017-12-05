using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeeController
    {
        Repository<Employee> repository;

        public EmployeeController()
        {
            repository = new Repository<Employee>();
        }

        public int IdByName(string firstName, string lastName)
        {
            int id;
            try
            {
                id = repository.Set()
                    .FirstOrDefault(c => c.FirstName == firstName || c.LastName == lastName)
                    .EmployeeID;

            } catch (NullReferenceException e)
            {
                return 0;
            }
            return id;
        }

    }
}

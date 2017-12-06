using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerController
    {
        Repository<Customer> repository;


        public CustomerController()
        {
            repository = new Repository<Customer>();
        }

        public bool Exist(string id)
        {
            return repository.Set().Any(c => c.CustomerID == id);
        }

        public string GetName(string id)
        {
            return repository.Set().FirstOrDefault(c => c.CustomerID == id).CompanyName;
        }

        
    }
}

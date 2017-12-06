using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductController
    {
        
        Repository<Product> repository;
        public ProductController()
        {
            repository = new Repository<Product>();
        }


        public ProductModel GetByName(string name)
        {
            var productModel = repository.Set()
                .Select(c => new ProductModel
                {
                    ProductID = c.ProductID,
                    ProductName = c.ProductName,
                    UnitPrice = c.UnitPrice,
                    UnitsInStock = c.UnitsInStock
                })
                .FirstOrDefault(c => c.ProductName.Contains(name));

            return productModel;
        }
    }
}


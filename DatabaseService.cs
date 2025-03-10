using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreWCF;

namespace PseudoRMI_DatabaseServer
{
    public class DatabaseService : IDatabaseService
    {
        private static List<Product> productList = new List<Product>
{
            new Product(1, "Produkt 1", 10.0, "Desc 1"),
            new Product(2, "Produkt 2", 20.0),
            new Product(3, "Produkt 3", 30.0, "")
        };

        public List<Product> GetProducts()
        {
            return productList;
        }

        public Product GetProductByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            Console.WriteLine($"Searching for product with name: {name}");

            // Search the product list
            var product = productList.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (product == null)
            {
                Console.WriteLine($"Product with name '{name}' not found.");
            }
            else
            {
                Console.WriteLine($"Found product: {product.ToString()}");
            }

            return product;
        }

    }
}

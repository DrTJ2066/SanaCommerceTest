using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Models.Models;

namespace ProductManagement.Models.DAL
{
    public class MemoryContext : IContext
    {
        private static List<Product> products = new List<Product>();

        public void AddNewProduct(Product product)
        {
            products.Add(product);
        }

        public List<Product> GetProductsList()
        {
            return products.ToList();
        }

        public void Remove(int id)
        {
            var item = products.FirstOrDefault(w => w.ProductId == id);

            if (item == null)
                return;

            products.Remove(item);
        }
    }
}

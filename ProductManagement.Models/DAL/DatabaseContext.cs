using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Models.Models;

namespace ProductManagement.Models.DAL
{
    public class DatabaseContext : IContext
    {
        private ProductManagementDataModel context = new ProductManagementDataModel();

        public void AddNewProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public List<Product> GetProductsList()
        {
            return context.Products.Include("Categories").ToList();
        }

        public void Remove(int id)
        {
            var item = context.Products.FirstOrDefault(w => w.ProductId == id);

            if (item == null)
                return;

            context.Products.Remove(item);
            context.SaveChanges();
        }
    }
}

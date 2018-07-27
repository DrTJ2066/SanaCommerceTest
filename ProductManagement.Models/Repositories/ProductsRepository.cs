using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Models.Models;
using ProductManagement.Models.DAL;

namespace ProductManagement.Models.Repositories
{
    public class ProductsRepository : RepositoryBase
    {
        public ProductsRepository(IContext context) : base(context)
        {
        }

        public void AddNewProduct(Product product)
        {
            var newId = Context.GetProductsList().Any() ? Context.GetProductsList().Max(w => w.ProductId) + 1 : 1;
            product.ProductId = newId;

            Context.AddNewProduct(product);
        }

        public List<Product> GetProductsList()
        {
            return Context.GetProductsList();
        }

        public void Remove(int id)
        {
            Context.Remove(id);
        }
    }
}

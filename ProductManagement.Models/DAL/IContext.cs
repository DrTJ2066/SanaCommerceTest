using ProductManagement.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Models.DAL
{
    public interface IContext
    {
        void AddNewProduct(Product product);
        List<Product> GetProductsList();
        void Remove(int id);
    }
}

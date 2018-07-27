using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.DAL
{
    public interface IContext
    {
        void AddNewProduct();
        List<string> GetProductsList();
    }
}

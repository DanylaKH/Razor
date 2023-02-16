using Razor.WebPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razor.WebPages.Sevices
{
    public interface IProductRepository
    {
        IEnumerable<Product> Search(string searchTerm);
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
        Product Update(Product updatedProduct);
        Product Add(Product newProduct);
        Product Delete(int id);
    }
}

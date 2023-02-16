using Razor.WebPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razor.WebPages.Sevices
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly AppDBContext _context;

        public SqlProductRepository(AppDBContext context)
        {
            _context = context;
        }
        public Product Add(Product newProduct)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return newProduct;
        }

        public Product Delete(int id)
        {
            var productToDelete = _context.Products.Find(id);

            if(productToDelete != null)
            {
                _context.Products.Remove(productToDelete);
                _context.SaveChanges();
            }
            return productToDelete;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return _context.Products;

            return _context.Products.Where(x => x.name.ToLower().Contains(searchTerm.ToLower()));
        }

        public Product Update(Product updatedProduct)
        {
            var product = _context.Products.Attach(updatedProduct);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updatedProduct;
        }
    }
}

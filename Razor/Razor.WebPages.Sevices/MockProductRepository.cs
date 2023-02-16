using Razor.WebPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razor.WebPages.Sevices
{
    public class MockProductRepository : IProductRepository
    {
        private List<Product> _products;
        public MockProductRepository()
        {
            _products = new List<Product>()
            {
                new Product()
                {
                    id = 0, name = "Tomato", price = 5, PhotoPath = "Tomato.jpg"
                },
                new Product()
                {
                    id = 1, name = "Bread", price = 10, PhotoPath = "Bread.jpg"
                },
                new Product()
                {
                    id = 2, name = "Salmon", price = 25, PhotoPath = "Salmon.jpg"
                },
                new Product()
                {
                    id = 3, name = "Meat", price = 30, PhotoPath = "Meat.jpg"
                }
            };
        }

        public Product Add(Product newProduct)
        {
            newProduct.id = _products.Max(x => x.id) + 1;
            _products.Add(newProduct);
            return newProduct;
        }

        public Product Delete(int id)
        {
            Product productToDelete = _products.FirstOrDefault(x => x.id == id);
            if(productToDelete != null)
            {
                _products.Remove(productToDelete);
            }
            return productToDelete;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProduct(int id)
        {
            return _products.FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<Product> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return _products;

            return _products.Where(x => x.name.ToLower().Contains(searchTerm.ToLower()));
        }

        public Product Update(Product updatedProduct)
        {
            Product product = _products.FirstOrDefault(x => x.id == updatedProduct.id);

            if(product != null)
            {
                product.name = updatedProduct.name;
                product.price = updatedProduct.price;
                product.PhotoPath = updatedProduct.PhotoPath;
            }
            return product;
        }
    }
}

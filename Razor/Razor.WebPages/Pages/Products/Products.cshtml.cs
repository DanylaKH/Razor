using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.WebPages.Models;
using Razor.WebPages.Sevices;

namespace Razor.WebPages.Pages.Products
{
    public class ProductsModel : PageModel
    {
        private readonly IProductRepository _db;
        public ProductsModel(IProductRepository db)
        {
            _db = db;
        }
        public IEnumerable<Product> products { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public void OnGet()
        { 
            products = _db.Search(SearchTerm);
        }
    }
}

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
    public class DeleteModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        [BindProperty]
        public Product product { get; set; }

        public DeleteModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult OnGet(int id)
        {
            product = _productRepository.GetProduct(id);

            if (product == null)
                return RedirectToPage("/NotFound");
            return Page();
        }

        public IActionResult OnPost()
        {
            Product productToDelete = _productRepository.Delete(product.id);

            if(productToDelete == null)
            {
                return RedirectToPage("/NotFound");
            }

            return RedirectToPage("Products");
        }
    }
}

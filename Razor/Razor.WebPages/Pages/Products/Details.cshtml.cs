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
    public class DetailsModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        public DetailsModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product product { get; private set; }

        public IActionResult OnGet(int id)
        {
            product = _productRepository.GetProduct(id);

            if(product == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}

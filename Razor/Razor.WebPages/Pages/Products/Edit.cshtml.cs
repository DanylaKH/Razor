using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.WebPages.Models;
using Razor.WebPages.Sevices;

namespace Razor.WebPages.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IProductRepository _db;
        private readonly IWebHostEnvironment _webHostEnvirnoment;

        public EditModel(IProductRepository db, IWebHostEnvironment webHostEnvirnoment)
        {
            _db = db;
            _webHostEnvirnoment = webHostEnvirnoment;
        }
        [BindProperty]
        public Product product { get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }
        [BindProperty]
        public bool Notify { get; set; }
        public string Message { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
                product = _db.GetProduct(id.Value);
            else
                product = new Product();
            if(product == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (product.PhotoPath != null)
                    {
                        string filePath = Path.Combine(_webHostEnvirnoment.WebRootPath, "images", product.PhotoPath);
                        System.IO.File.Delete(filePath);
                    }

                    product.PhotoPath = ProcessUploadedFile();
                }

                if (product.id > 0)
                {
                    product = _db.Update(product);

                    TempData["SeccessMessage"] = $"Update {product.name} successful";
                }
                else
                {
                    product = _db.Add(product);

                    TempData["SeccessMessage"] = $"Adding {product.name} successful";
                }
                return RedirectToPage("Products");
            }
                return Page();
        }

        public void OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify == true)
                Message = "Thank you for turning on notification";
            else
                Message = "You have turned off notification";

            product = _db.GetProduct(id);
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if(Photo != null)
            {
                string uploadsFolders = Path.Combine(_webHostEnvirnoment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolders, uniqueFileName);

                using (var fs = new FileStream(filePath, FileMode.Create)) 
                {
                    Photo.CopyTo(fs);
                }
            }
            return uniqueFileName;
        }
    }
}

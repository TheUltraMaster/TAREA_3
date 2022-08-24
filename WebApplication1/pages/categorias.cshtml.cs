using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdventureWorksNS.Data;
using System;

namespace WebApplication1.pages
{
    public class categoriasModel : PageModel
    {

        private AdventureWorksDB? db;
        public IEnumerable<ProductCategory>? categorias { get; set; }

        [BindProperty]
        public ProductCategory? categoria { get; set; }

        public categoriasModel(AdventureWorksDB injectedContext)
        {
            db = injectedContext;
        }
        public void OnGet()
        {
            ViewData["Title"] = "AdventureWorks - Clientes";
            categorias = db?.ProductCategories.OrderBy(c=>c.Name);
        }

        public IActionResult OnPost()
        {
            if (categoria is not null)
            {
                
                db?.ProductCategories.Add(categoria);
                System.Console.WriteLine(categoria.Name);
                db?.SaveChanges();
                return RedirectToAction("/categorias");
            }
            else
            {
                return Page();
            }
        }




    }
}

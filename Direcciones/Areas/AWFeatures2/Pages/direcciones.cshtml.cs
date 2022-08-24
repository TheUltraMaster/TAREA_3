using AdventureWorksNS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Direcciones.Areas.AWFeatures2.Pages
{
    public class direccionesModel : PageModel
    {
        private AdventureWorksDB db;

        public List<Address>?  direcciones {get; set; } = null;
        public direccionesModel(AdventureWorksDB injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "AdventureWorks - Direcciones";
            direcciones = db.Addresses.OrderBy(p => p.AddressId).ToList();
        }

       



    }
}

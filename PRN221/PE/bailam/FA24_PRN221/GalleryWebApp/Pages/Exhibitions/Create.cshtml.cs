using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GalleryBusiness;

namespace GalleryWebApp.Pages.Exhibitions
{
    public class CreateModel : PageModel
    {
        private readonly GalleryBusiness.AppDbContext _context;

        public CreateModel(GalleryBusiness.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Exhibition Exhibition { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Exhibitions.Add(Exhibition);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

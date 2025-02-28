using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GalleryBusiness;

namespace GalleryWebApp.Pages.Exhibitions
{
    public class DeleteModel : PageModel
    {
        private readonly GalleryBusiness.AppDbContext _context;

        public DeleteModel(GalleryBusiness.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Exhibition Exhibition { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibition = await _context.Exhibitions.FirstOrDefaultAsync(m => m.ExhibitionId == id);

            if (exhibition == null)
            {
                return NotFound();
            }
            else
            {
                Exhibition = exhibition;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibition = await _context.Exhibitions.FindAsync(id);
            if (exhibition != null)
            {
                Exhibition = exhibition;
                _context.Exhibitions.Remove(Exhibition);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

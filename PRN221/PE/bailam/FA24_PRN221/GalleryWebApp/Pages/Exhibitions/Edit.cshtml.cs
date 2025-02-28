using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GalleryBusiness;

namespace GalleryWebApp.Pages.Exhibitions
{
    public class EditModel : PageModel
    {
        private readonly GalleryBusiness.AppDbContext _context;

        public EditModel(GalleryBusiness.AppDbContext context)
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

            var exhibition =  await _context.Exhibitions.FirstOrDefaultAsync(m => m.ExhibitionId == id);
            if (exhibition == null)
            {
                return NotFound();
            }
            Exhibition = exhibition;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Exhibition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExhibitionExists(Exhibition.ExhibitionId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ExhibitionExists(int id)
        {
            return _context.Exhibitions.Any(e => e.ExhibitionId == id);
        }
    }
}

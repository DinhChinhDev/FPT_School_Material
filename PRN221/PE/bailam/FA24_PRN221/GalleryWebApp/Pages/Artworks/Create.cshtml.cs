using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GalleryBusiness;

namespace GalleryWebApp.Pages.Artworks
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
        ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "Biography");
        ViewData["ExhibitionId"] = new SelectList(_context.Exhibitions, "ExhibitionId", "ExhibitionId");
            return Page();
        }

        [BindProperty]
        public Artwork Artwork { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Artworks.Add(Artwork);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
